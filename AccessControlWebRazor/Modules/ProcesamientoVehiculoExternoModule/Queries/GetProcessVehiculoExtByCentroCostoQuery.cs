using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries
{
    public class GetProcessVehiculoExtByCentroCostoQuery : IRequest<List<ProcesamientoVehiculoExterno>>
    {
        public int CentroCosto { get; set; }

        public GetProcessVehiculoExtByCentroCostoQuery(int centroCosto)
        {
            CentroCosto = centroCosto;
        }
    }
}
