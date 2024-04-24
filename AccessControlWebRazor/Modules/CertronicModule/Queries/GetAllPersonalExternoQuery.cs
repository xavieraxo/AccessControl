using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Queries
{
    public class GetAllPersonalExternoQuery : IRequest<List<PersonalExterno>>
    {
    }
}
