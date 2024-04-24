namespace AccessControlWebRazor.DTO_s.LogInDTO_s
{
    public class LogInResponse
    {
        public string User { get; set; }
        public int Permiso { get; set; }
        public LogInResponse(string user, int permiso)
        {
            User = user;
            Permiso = permiso;
        }
    }
}
