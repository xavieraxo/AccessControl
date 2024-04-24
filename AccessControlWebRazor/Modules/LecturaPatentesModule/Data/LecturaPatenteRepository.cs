using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.LecturaPatentesModule.Data
{
    public class LecturaPatenteRepository : GenericRepository<LecturaPatente>, ILecturaPatenteRepository
    {
        public LecturaPatenteRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
