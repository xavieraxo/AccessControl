using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.UsuarioModule.Command;
using AccessControlWebRazor.Modules.UsuarioModule.Data;
using AccessControlWebRazor.Modules.UsuarioModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Handler
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, Usuario>
    {
        private readonly IUsuarioService _usuarioService;

        public CreateUsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public  Task<Usuario> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario() 
            {
                User = request.UserName,
                Password = request.Password,
                PermisoID = request.PermisoID,
                PersonalID = request.PersonalID,
            };
            var result = _usuarioService.Createuser(usuario);
            return Task.FromResult(result);
        }
    }
}
