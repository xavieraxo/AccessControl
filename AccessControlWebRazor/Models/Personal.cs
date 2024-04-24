using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace AccessControlWebRazor.Models
{
    public class Personal
    {
        [HiddenInput(DisplayValue = false)]

        public int Id { get; set; }
        [HiddenInput(DisplayValue = false)]

        public int? IdTipoDocumento { get; set; }
        [DisplayName("Legajo")]
        public int NroLegajo { get; set; }
        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("DNI")]
        public int? NroDocumento { get; set; }
        [DisplayName("Localidad")]
        public string? Localidad { get; set; }
        [DisplayName("Email")]
        public string? Email { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Sexo { get; set; }

        public bool? Habilitado { get; set; } 

    }
}
