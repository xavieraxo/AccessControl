using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.UsuarioModule.Queries;
using AccessControlWebRazor.Modules.UsuarioModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.UsuarioModule.Handler
{
    public class GetUserByPersonalIDQueryHandler : IRequestHandler<GetUserByPersonalIDQuery, Usuario>
    {
        private readonly IUsuarioService _userService;

        public GetUserByPersonalIDQueryHandler(IUsuarioService usuarioService)
        {
            _userService = usuarioService;
        }
        public Task<Usuario> Handle(GetUserByPersonalIDQuery request, CancellationToken cancellationToken)
        {
            var resuilt = _userService.GetUserByPersonalID(request.PersonalID);
            return Task.FromResult(resuilt);
        }
    }
}
