using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Infraestructura.Repositories
{
    public class CentroCostoModelsRepository : GenericRepository<CentroCosto>, ICentroCostoModelsRepository
    {
        public CentroCostoModelsRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
