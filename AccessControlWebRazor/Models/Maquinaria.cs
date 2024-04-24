using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{
    [Table("Maquinarias")]
    public class Maquinaria
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Numeración")]
        public string Number { get; set; }

        [DisplayName("Marca")]
        public string Brand { get; set; }

        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DisplayName("Estado")]
        public int IsActive { get; set; }
    }
}
