using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Queries
{
    public class GetUserByPersonalIDQuery : IRequest<Usuario>
    {
        public int PersonalID { get; set; }

        public GetUserByPersonalIDQuery(int id)
        {
            PersonalID = id;
        }
    }
}
