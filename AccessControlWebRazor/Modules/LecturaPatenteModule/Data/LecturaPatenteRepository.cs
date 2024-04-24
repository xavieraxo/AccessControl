using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Data
{
    public class LecturaPatenteRepository : GenericRepository<LecturaPatente>, ILecturaPatenteRepository
    {
        public LecturaPatenteRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
