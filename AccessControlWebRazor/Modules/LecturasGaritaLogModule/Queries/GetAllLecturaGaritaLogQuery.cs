using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries
{
    public class GetAllLecturaGaritaLogQuery : IRequest<List<LecturasGaritaLog>>
    {
    }
}
