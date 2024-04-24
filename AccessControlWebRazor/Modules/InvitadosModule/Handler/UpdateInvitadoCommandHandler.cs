using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.InvitadosModule.Command;
using AccessControlWebRazor.Modules.InvitadosModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.InvitadosModule.Handler
{
    public class UpdateInvitadoCommandHandler : IRequestHandler<UpdateInvitadoCommand, Invitado>
    {
        private readonly IInvitadosServices _invitadosServices;

        public UpdateInvitadoCommandHandler(IInvitadosServices invitadosServices)
        {
            _invitadosServices = invitadosServices;
        }
        public Task<Invitado> Handle(UpdateInvitadoCommand request, CancellationToken cancellationToken)
        {
            var result = _invitadosServices.UpdateInvitado(request.Invitado);
            return Task.FromResult(result);
        }
    }
}
