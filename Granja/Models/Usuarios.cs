using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Granja.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public required string Nombre {  get; set; }
        public required string Apellido { get; set; }
        public required int Edad { get; set; }
        public required int Contacto  { get; set; }
        public required DateTime Fecha_vinculacion { get; set; }
        public required float Salario { get; set; }
        public required string Password { get; set; }

        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public required Roles Rol { get; set; }
    }
}
