using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.IRepositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Infraestructura.Repositories
{
    public class TipoPersonasRepository : GenericRepository<TipoPersona>, ITipoPersonasRepository
    {
        public TipoPersonasRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
