namespace AccessControlWebRazor.DTO_s.PersonalDTO
{
    public class PersonalABMDTO
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
    }
}
