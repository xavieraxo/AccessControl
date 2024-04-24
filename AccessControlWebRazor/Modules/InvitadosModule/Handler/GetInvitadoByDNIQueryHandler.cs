using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.InvitadosModule.Queries;
using AccessControlWebRazor.Modules.InvitadosModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.InvitadosModule.Handler
{
    public class GetInvitadoByDNIQueryHandler : IRequestHandler<GetInvitadoByDNIQuery, Invitado>
    {
        private readonly IInvitadosServices _invitadosServices;

        public GetInvitadoByDNIQueryHandler(IInvitadosServices invitadosServices)
        {
            _invitadosServices = invitadosServices;   
        }
        public Task<Invitado> Handle(GetInvitadoByDNIQuery request, CancellationToken cancellationToken)
        {
            var result = _invitadosServices.GetInvitadoByDNI(request.DNI);
            return Task.FromResult(result);
        }
    }
}
