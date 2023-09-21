using Granja.Datos;
using Granja.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Granja.Controllers
{
    public class InicioController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public InicioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Usuarios.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuarios usuarios)
        {
            // Generar una contraseña aleatoria
            string contraseñaAleatoria = GenerarPasswordAleatoria();

            // Asignar la contraseña aleatoria al usuario
            usuarios.Password = contraseñaAleatoria;

            if (ModelState.IsValid) 
            {
                _contexto.Usuarios.Add(usuarios);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GenerarPasswordAleatoria()
        {
            // Longitud de la contraseña aleatoria (en este caso, 6 dígitos hexadecimales)
            int longitud = 6;

            // Caracteres permitidos en la contraseña
            const string caracteresPermitidos = "0123456789ABCDEF";

            // Crear un generador de números aleatorios seguro
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytesAleatorios = new byte[longitud];
                rng.GetBytes(bytesAleatorios);

                StringBuilder contraseñaAleatoria = new StringBuilder(longitud);

                foreach (byte byteAleatorio in bytesAleatorios)
                {
                    // Obtener un índice válido en función de la longitud de los caracteres permitidos
                    int indiceCaracter = byteAleatorio % caracteresPermitidos.Length;

                    // Agregar el carácter aleatorio a la contraseña
                    contraseñaAleatoria.Append(caracteresPermitidos[indiceCaracter]);
                }

                return contraseñaAleatoria.ToString();
            }
        }
    }
}