using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Data
{
    public class LecturasGaritaLogRepository : GenericRepository<LecturasGaritaLog>, ILecturasGaritaLogRepository
    {
        
        public LecturasGaritaLogRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
