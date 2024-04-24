using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.UsuarioModule.Command
{
    public class ResetPasswordCommand : IRequest<Usuario>
    {
        public int UsuarioID { get; set; }
        public ResetPasswordCommand(int ID)
        {
            UsuarioID = ID;
        }
    }
}
