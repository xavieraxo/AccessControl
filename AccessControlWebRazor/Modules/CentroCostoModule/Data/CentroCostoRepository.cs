using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Data
{
    public class CentroCostoRepository : GenericRepository<CentroCosto>, ICentroCostoRepository
    {
        public CentroCostoRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
