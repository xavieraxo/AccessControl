namespace AccessControlWebRazor.DTO_s.PersonalDTO
{
    public class PersonalUserDTO
    {
        public int? Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int PermisoID { get; set; }
        public int PersonaID { get; set; }
    }
}
