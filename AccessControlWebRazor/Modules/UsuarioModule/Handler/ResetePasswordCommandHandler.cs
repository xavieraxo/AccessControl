using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.UsuarioModule.Command;
using AccessControlWebRazor.Modules.UsuarioModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.UsuarioModule.Handler
{
    public class ResetePasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Usuario>
    {
        private readonly IUsuarioService _usuarioService;

        public ResetePasswordCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public Task<Usuario> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = _usuarioService.ResetPassword(request.UsuarioID);
            return Task.FromResult(result);
        }
    }
}
