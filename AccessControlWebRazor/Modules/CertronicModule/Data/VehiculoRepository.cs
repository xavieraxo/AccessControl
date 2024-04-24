using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.CertronicModule.Data
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculosRepository
    {
        public VehiculoRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
