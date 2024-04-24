using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;


namespace AccessControlWebRazor.Modules.PersonalModule.Data
{
    public class PersonalRepository : GenericRepository<Personal>, IPersonalRepository
    {
        public PersonalRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
