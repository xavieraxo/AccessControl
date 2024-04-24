using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AccessControlWebRazor.DTO_s.CertronicDTO_s
{
    public class PersonalExternoDTO
    {

        public string Id { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public Company Company { get; set; }
        public List<Access> Access { get; set; }


    }
}
