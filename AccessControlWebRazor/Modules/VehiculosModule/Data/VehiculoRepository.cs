using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.VehiculosModule.Data
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
