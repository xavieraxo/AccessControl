using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries
{
    public class GetProcessVehiculoExtByCostoNoZeroQuery : IRequest<List<ProcesamientoVehiculoExterno>>
    {

        public GetProcessVehiculoExtByCostoNoZeroQuery()
        {
        }

    }
}
