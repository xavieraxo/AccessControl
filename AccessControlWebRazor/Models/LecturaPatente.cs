using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{
    [Table("LecturaPatente")]
    public class LecturaPatente
    {
        [Key]
        public int Id { get; set; }
        public string Patente { get; set; }
        public string Camara { get; set; }
        public string FechaLectura { get; set; }
        public DateTime FechaLectura_datetime { get; set; }
        public int Procesado { get; set; }

    }
}
