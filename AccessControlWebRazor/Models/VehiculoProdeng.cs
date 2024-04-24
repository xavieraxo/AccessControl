using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{

    [Table("VehiculosProdeng")]
    public class VehiculoProdeng
    {
        [Key]
        public int Id { get; set; }
        public string Dominio { get; set; }
        public string Modelo { get; set; }

        [DisplayName("Estado")]
        public int Status { get; set; }
    }
}
