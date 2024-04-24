using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturaPatentesModule.Queries
{
    public class GetAllLecturaPatenteQuery : IRequest<List<LecturaPatente>>
    {
    }
}
