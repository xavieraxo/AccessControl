using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AccessControlWebRazor.DTO_s.LogInDTO_s
{
    public class UsuarioDTO
    {
        [DisplayName("Usuario")]
        public string  UsuarioName { get; set; }

        [DisplayName("Apellido y Nombre")]
        public string Persona { get; set; }
        public string Permiso { get; set; }
    }
}
