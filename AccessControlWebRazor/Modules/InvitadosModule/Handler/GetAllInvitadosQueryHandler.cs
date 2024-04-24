using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.InvitadosModule.Queries;
using AccessControlWebRazor.Modules.InvitadosModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Handler
{
    public class GetAllInvitadosQueryHandler : IRequestHandler<GetAllInvitadosQuery, List<Invitado>>
    {
        private readonly IInvitadosServices _invitadosServices;
        public GetAllInvitadosQueryHandler(IInvitadosServices invitadosServices)
        {
            _invitadosServices = invitadosServices;
        }
        public Task<List<Invitado>> Handle(GetAllInvitadosQuery request, CancellationToken cancellationToken)
        {
            var result = _invitadosServices.GetAllInvitado();
            return Task.FromResult(result);
        }
    }
}
