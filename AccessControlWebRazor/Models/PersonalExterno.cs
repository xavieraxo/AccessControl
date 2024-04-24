using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{
    [Table("PersonalExterno")]
    public class PersonalExterno
    {
        [Key]
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }

        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [DisplayName("Nombres")]
        public string FirstName { get; set; }

        [DisplayName("Estado")]
        public int IsActive { get; set; }
    }
}
