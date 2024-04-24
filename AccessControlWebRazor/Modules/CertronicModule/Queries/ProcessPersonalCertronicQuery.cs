using AccessControlWebRazor.DTO_s.CertronicDTO_s;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Queries
{
    public class ProcessPersonalCertronicQuery : IRequest<bool>
    {
        public PersonalExternoDTO  Personal { get; set; }

        public ProcessPersonalCertronicQuery(PersonalExternoDTO persona)
        {
            Personal = persona;
        }
    }
}
