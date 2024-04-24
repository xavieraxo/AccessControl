using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Data
{
    public class ProcesamientoPersonalRepository : GenericRepository<Procesamiento>, IProcesamientoPersonalRepository
    {
        public ProcesamientoPersonalRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
