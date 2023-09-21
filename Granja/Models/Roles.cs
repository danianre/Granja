using System.ComponentModel.DataAnnotations;

namespace Granja.Models
{
    public class Roles
    {
        [Key]
        public int IdRol { get; set; }
        public required string Rol { get; set; }
    }
}
