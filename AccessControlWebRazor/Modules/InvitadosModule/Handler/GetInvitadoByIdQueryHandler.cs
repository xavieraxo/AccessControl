using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.InvitadosModule.Queries;
using AccessControlWebRazor.Modules.InvitadosModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Handler
{
    public class GetInvitadoByIdQueryHandler : IRequestHandler<GetInvitadoByIdQuery, Invitado>
    {
        private readonly IInvitadosServices _invitadosServices;

        public GetInvitadoByIdQueryHandler(IInvitadosServices invitadosServices)
        {
            _invitadosServices = invitadosServices;
        }
        public Task<Invitado> Handle(GetInvitadoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _invitadosServices.GetInvitadoByID(request.Id);
            return Task.FromResult(result);
        }
    }
}
