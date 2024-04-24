using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Infraestructura.Repositories
{
    public class LecturasGaritaLogModelsRepository : GenericRepository<LecturasGaritaLog>, ILecturasGaritaLogModelsRepository
    {
        public LecturasGaritaLogModelsRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
