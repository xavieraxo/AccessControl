using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Queries
{
    public class GetInvitadoByIdQuery : IRequest<Invitado>
    {
        public int Id { get; set; }

        public GetInvitadoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
