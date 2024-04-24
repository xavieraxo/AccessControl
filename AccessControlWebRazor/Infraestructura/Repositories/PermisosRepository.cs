using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Infraestructura.Repositories
{
    public class PermisosRepository : GenericRepository<Permiso>, IPermisosRepository
    {
        public PermisosRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
