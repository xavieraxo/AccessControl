using AccessControlWebRazor.Modules.InvitadosModule.Command;
using AccessControlWebRazor.Modules.InvitadosModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.InvitadosModule.Handler
{
    public class DeleteInvitadoCommandHandler : IRequestHandler<DeleteInvitadoCommand, bool>
    {
        private readonly IInvitadosServices _invitadosServices;

        public DeleteInvitadoCommandHandler(IInvitadosServices invitadosServices)
        {
            _invitadosServices = invitadosServices;
        }
        public Task<bool> Handle(DeleteInvitadoCommand request, CancellationToken cancellationToken)
        {
            if (request.Id > 0)
            {
                _invitadosServices.DeleteInvitado(request.Id);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
