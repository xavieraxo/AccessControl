using AccessControlWebRazor.DTO_s.LogInDTO_s;
using AccessControlWebRazor.Modules.LogInModule.Queries;
using AccessControlWebRazor.Modules.UsuarioModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.UsuarioModule.Handler
{
    public class LogInQueryHandler : IRequestHandler<LogInQuery, LogInResponse>
    {   
        private readonly IUsuarioService _usuarioService;

        public LogInQueryHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public Task<LogInResponse> Handle(LogInQuery request, CancellationToken cancellationToken)
        {
            var usuario = _usuarioService.LogIn(request.User, request.Password);
            var result = new LogInResponse(usuario.User, usuario.PermisoID);
            return Task.FromResult(result);
        }
    }
}
