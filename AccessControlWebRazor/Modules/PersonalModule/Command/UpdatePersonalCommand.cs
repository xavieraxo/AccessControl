using AccessControlWebRazor.DTO_s.PersonalDTO_s;
using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Command
{
    public class UpdatePersonalCommand : IRequest<Personal>
    {
        public PersonalDTOs PersonalDTO { get; set; }

        public UpdatePersonalCommand(PersonalDTOs persona)
        {
            PersonalDTO = persona;
        }
    }
}
