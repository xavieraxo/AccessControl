using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Command
{
    public class CreateInvitadoCommand : IRequest<Invitado>
    {
        public Invitado Invitado { get; set; }

        public CreateInvitadoCommand(Invitado invitado)
        {
            Invitado = invitado;
        }
    }
}
