﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Granja.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required (ErrorMessage = "Este campo es obligatorio")]
        public required string Nombre {  get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public required int Edad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public required int Contacto  { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public required DateTime Fecha_vinculacion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public required int Salario { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public required string Password { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int IdRol { get; set; }
        public required Roles Rol { get; set; }
    }
}
