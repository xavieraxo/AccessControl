using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries
{
    public class GetAllProcesamientoVehiExtQuery : IRequest<List<ProcesamientoVehiculoExterno>>
    {
    }
}
