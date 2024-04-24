using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries
{
    public class GetLecturasGaritaDelDiaQuery : IRequest<List<LecturasGaritaLog>>
    {
    }
}
