using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.InvitadosModule.Queries;
using AccessControlWebRazor.Modules.InvitadosModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Handler
{
    public class GetInvitadosByFilterQueryHandler : IRequestHandler<GetInvitadosByFilterQuery, List<Invitado>>
    {
        private readonly IInvitadosServices _invitadosServices;

        public GetInvitadosByFilterQueryHandler(IInvitadosServices invitadosServices)
        {
            _invitadosServices = invitadosServices;
        }
        public Task<List<Invitado>> Handle(GetInvitadosByFilterQuery request, CancellationToken cancellationToken)
        {
            var cadena = request.Filter.ToUpper().Trim();
            var result = _invitadosServices.GetAllInvitado();
            var listaDepurada = result.Where(x=> x.DNI == cadena || x.Nombre.ToUpper().Trim().Contains(cadena) || x.Apellido.ToUpper().Trim().Contains(cadena)).ToList();
            return Task.FromResult(listaDepurada);
        }
    }
}
