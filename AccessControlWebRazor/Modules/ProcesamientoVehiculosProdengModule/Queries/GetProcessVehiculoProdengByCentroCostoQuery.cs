using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries
{
    public class GetProcessVehiculoProdengByCentroCostoQuery : IRequest<List<ProcesamientoVehiculoProdeng>>
    {
        public int CentroCosto { get; set; }
        public GetProcessVehiculoProdengByCentroCostoQuery(int centroCosto)
        {
            CentroCosto = centroCosto;
        }
    }
}
