using AccessControlWebRazor.DTO_s.PersonalDTO_s;
using AccessControlWebRazor.Models;

using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Command
{
    public class CreatePersonalCommand : IRequest<Personal>
    {
        public PersonalDTO PersonalDTO { get; set; }

        public CreatePersonalCommand(PersonalDTO personal)
        {
            PersonalDTO = personal; 
        }

    }
}
