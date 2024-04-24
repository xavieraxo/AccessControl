using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{
    [Table("Invitado")]
    public class Invitado
    {
        [Key]
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Observacion { get; set; }
    }
}
