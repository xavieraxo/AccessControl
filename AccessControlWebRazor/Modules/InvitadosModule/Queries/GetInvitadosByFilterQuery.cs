using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Queries
{
    public class GetInvitadosByFilterQuery : IRequest<List<Invitado>>
    {
        public string Filter { get; set; }
        public GetInvitadosByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
}
