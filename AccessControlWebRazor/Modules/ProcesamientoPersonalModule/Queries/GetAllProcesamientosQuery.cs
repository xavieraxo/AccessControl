using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries
{
    public class GetAllProcesamientosQuery : IRequest<List<Procesamiento>>
    {
    }
}
