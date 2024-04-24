using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.DTO_s.PersonalDTO
{
    public class PersonaUserToCreateDTO
    {
        public int? Id { get; set; }
        public int NroLegajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int? NroDocumento { get; set; }
        public string? Localidad { get; set; }
        public string? Email { get; set; }
        public string Sexo { get; set; }
        public bool? Habilitado { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Permiso
        {
            get
            {
                return (Permiso == "1") ? "Admin" : "Lacayo";
            }
            set
            {
                Permiso = value;
            }
        }
    }
}
