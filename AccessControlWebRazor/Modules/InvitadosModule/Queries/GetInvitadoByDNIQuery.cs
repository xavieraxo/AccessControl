using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Queries
{
    public class GetInvitadoByDNIQuery : IRequest<Invitado>
    {
        public string DNI { get; set; }

        public GetInvitadoByDNIQuery(string dni)
        {
            DNI = dni;
        }
    }
}
