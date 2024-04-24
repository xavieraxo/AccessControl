using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.UsuarioModule.Queries;
using AccessControlWebRazor.Modules.UsuarioModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.UsuarioModule.Handler
{
    public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, Usuario>
    {
        private readonly IUsuarioService _usuarioService;

        public GetUserByIDQueryHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public Task<Usuario> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var result = _usuarioService.GetUserByID(request.ID);
            return Task.FromResult(result);
        }
    }
}
