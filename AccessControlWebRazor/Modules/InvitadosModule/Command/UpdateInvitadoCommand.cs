using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Command
{
    public class UpdateInvitadoCommand : IRequest<Invitado>
    {
        public Invitado Invitado { get; set; }

        public UpdateInvitadoCommand(Invitado invitado)
        {
            Invitado = invitado;
        }
    }
}
