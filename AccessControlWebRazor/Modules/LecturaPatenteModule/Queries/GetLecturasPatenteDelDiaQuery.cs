using AccessControlWebRazor.Models;
using MediatR;


namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Queries
{
    public class GetLecturasPatenteDelDiaQuery : IRequest<List<LecturaPatente>>
    {
    }
}
