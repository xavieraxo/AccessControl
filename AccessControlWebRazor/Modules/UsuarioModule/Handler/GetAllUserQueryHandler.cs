using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.UsuarioModule.Queries;
using AccessControlWebRazor.Modules.UsuarioModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Handler
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<Usuario>>
    {
        private readonly IUsuarioService _usuarioService;

        public GetAllUserQueryHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public Task<List<Usuario>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result = _usuarioService.GetAllUsers();
            return Task.FromResult(result);
        }
    }
}
