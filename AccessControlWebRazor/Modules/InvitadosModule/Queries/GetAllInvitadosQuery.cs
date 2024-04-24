using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Queries
{
    public class GetAllInvitadosQuery : IRequest<List<Invitado>>
    {
    }
}
