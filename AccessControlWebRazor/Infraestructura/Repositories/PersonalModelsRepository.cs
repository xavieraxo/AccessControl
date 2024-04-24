using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Infraestructura.Repositories
{
    public class PersonalModelsRepository : GenericRepository<Personal>, IPersonalModelsRepository
    {
        public PersonalModelsRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
