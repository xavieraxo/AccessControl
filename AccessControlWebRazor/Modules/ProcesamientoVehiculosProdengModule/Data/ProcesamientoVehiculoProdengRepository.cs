using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Data
{
    public class ProcesamientoVehiculoProdengRepository : GenericRepository<ProcesamientoVehiculoProdeng>, IProcesamientoVehiculoProdengRepository
    {
        public ProcesamientoVehiculoProdengRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
