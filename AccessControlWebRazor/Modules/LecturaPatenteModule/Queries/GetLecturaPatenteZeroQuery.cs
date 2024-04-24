using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Queries
{
    public class GetLecturaPatenteZeroQuery : IRequest<List<LecturaPatente>>
    {
    }
}
