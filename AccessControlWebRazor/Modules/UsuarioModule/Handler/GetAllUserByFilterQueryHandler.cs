using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.UsuarioModule.Queries;
using AccessControlWebRazor.Modules.UsuarioModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Handler
{
    public class GetAllUserByFilterQueryHandler : IRequestHandler<GetAllUserByFilterQuery, List<Usuario>>
    {
        private readonly IUsuarioService _userService;
        public GetAllUserByFilterQueryHandler(IUsuarioService userService)
        {
            _userService = userService;
        }

        public Task<List<Usuario>> Handle(GetAllUserByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _userService.GetUserByFilter(request.Filter);
            return Task.FromResult(result); 
            
        }
    }
}
