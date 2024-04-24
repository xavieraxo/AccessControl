using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Command
{
    public class DeletePersonalCommand : IRequest<bool>
    {
        public int ID { get; set; }

        public DeletePersonalCommand(int id)
        {
            ID = id;
        }
    }
}
