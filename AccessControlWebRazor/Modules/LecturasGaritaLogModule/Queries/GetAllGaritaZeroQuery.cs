using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries
{
    public class GetAllGaritaZeroQuery : IRequest<List<LecturasGaritaLog>>
    {
    }
}
