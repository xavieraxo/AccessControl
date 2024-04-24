using AccessControlWebRazor.Data;
using AccessControlWebRazor.Infraestructura.Repositories;
using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.InvitadosModule.Data
{
    public class InvitadosRepository : GenericRepository<Invitado>, IInvitadosRepository
    {
        public InvitadosRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
