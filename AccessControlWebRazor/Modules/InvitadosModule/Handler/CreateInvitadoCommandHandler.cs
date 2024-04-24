using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.InvitadosModule.Command;
using AccessControlWebRazor.Modules.InvitadosModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Handler
{
    public class CreateInvitadoCommandHandler : IRequestHandler<CreateInvitadoCommand, Invitado>
    {
        private readonly IInvitadosServices _invitadosServices;

        public CreateInvitadoCommandHandler(IInvitadosServices invitadosServices)
        {
            _invitadosServices = invitadosServices;
        }
        public Task<Invitado> Handle(CreateInvitadoCommand request, CancellationToken cancellationToken)
        {
            var result = _invitadosServices.CreateInvitado(request.Invitado);
            return Task.FromResult(result);
        }
    }
}
