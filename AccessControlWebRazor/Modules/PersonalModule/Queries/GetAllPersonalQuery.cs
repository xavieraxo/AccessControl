using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Queries
{
    public class GetAllPersonalQuery : IRequest<List<Personal>>
    {
    }
}
