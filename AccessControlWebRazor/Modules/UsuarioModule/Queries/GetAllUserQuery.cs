using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Queries
{
    public class GetAllUserQuery : IRequest<List<Usuario>>
    {
    }
}
