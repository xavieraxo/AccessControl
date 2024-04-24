using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Queries
{
    public class GetAllLecturasPatentesQuery : IRequest<List<LecturaPatente>>
    {
    }
}
