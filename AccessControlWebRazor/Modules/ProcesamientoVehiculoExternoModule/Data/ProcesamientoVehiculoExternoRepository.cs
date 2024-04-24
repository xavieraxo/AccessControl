using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Data
{
    public class ProcesamientoVehiculoExternoRepository : GenericRepository<ProcesamientoVehiculoExterno>, IProcesamientoVehiculoExternoRepository
    {
        public ProcesamientoVehiculoExternoRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
