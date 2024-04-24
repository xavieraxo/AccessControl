using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries
{
    public class GetByCCostoVehiProNoZeroQuery : IRequest<List<ProcesamientoVehiculoProdeng>>
    {
    }
}
