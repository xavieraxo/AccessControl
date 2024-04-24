using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Infraestructura.Repositories
{
    public class ProcesamientoModelsRepository : GenericRepository<Procesamiento>, IProcesamientoModelsRepository
    {
        public ProcesamientoModelsRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
