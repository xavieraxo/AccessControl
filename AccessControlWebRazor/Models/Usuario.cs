using AccessControlWebRazor.Infraestructura.Repositories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccessControlWebRazor.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int ID { get; set; }

        [DisplayName("Usuario")]
        public string User { get; set; }

        [DisplayName("Contraseña")]
        public string Password { get; set; }
        public int PersonalID { get; set; }
        public int PermisoID { get; set; }

        public static implicit operator Usuario(UsuariosRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
