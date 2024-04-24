using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Data
{
    public class ProcesamientoPersonalExternoRepository : GenericRepository<ProcesamientoPersonalExterno>, IProcesamientoPersonalExternoRepository
    {
        public ProcesamientoPersonalExternoRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
