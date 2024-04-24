using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Command
{
    public class CreateUsuarioCommand : IRequest<Usuario>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonalID { get; set; }
        public int PermisoID { get; set; }

        public CreateUsuarioCommand(string user, string password, int personalID, int permisoID)
        {
            UserName = user;
            Password = password;
            PersonalID = personalID;
            PermisoID = permisoID;
        }
    }
}
