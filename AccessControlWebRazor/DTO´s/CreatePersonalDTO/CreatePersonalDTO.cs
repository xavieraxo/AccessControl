using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.DTO_s.CreatePersonalDTO
{
    public class CreatePersonalDTO
    {
        public Personal personal;
        public Models.LecturasGaritaLog lecturasGaritaLog;
        public CreatePersonalDTO() 
        {
            personal = new Personal();
            lecturasGaritaLog = new LecturasGaritaLog();
        }
    }
}
