using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.CertronicModule.Data
{
    public class PersonalExtrenoRepository : GenericRepository<PersonalExterno>, IPersonalExtrenoRepository
    {
        public PersonalExtrenoRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
