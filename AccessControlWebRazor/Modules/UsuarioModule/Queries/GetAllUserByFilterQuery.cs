using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Queries
{
    public class GetAllUserByFilterQuery : IRequest<List<Usuario>>
    {
        public string Filter { get; set; }
        public GetAllUserByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
}
