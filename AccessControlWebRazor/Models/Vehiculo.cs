using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{
    [Table("Vehiculo")]
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Patente")]
        public string Dominio { get; set; }
        [DisplayName("Marca")]
        public string Brand { get; set; }
        [DisplayName("Modelo")]
        public string Model { get; set; }
        [DisplayName("Estado")]
        public int IsActive { get; set; }
    }
}
