using MediatR;

namespace AccessControlWebRazor.Modules.InvitadosModule.Command
{
    public class DeleteInvitadoCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteInvitadoCommand(int id)
        {
            Id = id;
        }
    }
}
