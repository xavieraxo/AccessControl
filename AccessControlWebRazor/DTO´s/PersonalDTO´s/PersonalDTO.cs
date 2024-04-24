using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.DTO_s.PersonalDTO_s
{
    public class PersonalDTO
    {
        public int? IdTipoDocumento { get; set; }
        public int NroLegajo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int? NroDocumento { get; set; }
        public string? Localidad { get; set; }
        public string? Email { get; set; }
        public string Sexo { get; set; }
        public bool? Habilitado { get; set; }
        public string Observaciones { get; set; }

        internal Personal ToPersonal()
        {
            return new Personal
            {
                IdTipoDocumento = IdTipoDocumento,
                NroDocumento = NroDocumento,
                Localidad = Localidad,
                Email = Email,
                Sexo = Sexo,
                Habilitado = Habilitado,
                Apellido = Apellido,
                Nombre = Nombre,
                NroLegajo = NroLegajo,

            };
        }
    }
}
