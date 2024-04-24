using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Queries
{
    public class GetUserByIDQuery : IRequest<Usuario>
    {

        public int ID { get; set; }

        public GetUserByIDQuery(int id)
        {
            ID = id;
        }
    }
}
