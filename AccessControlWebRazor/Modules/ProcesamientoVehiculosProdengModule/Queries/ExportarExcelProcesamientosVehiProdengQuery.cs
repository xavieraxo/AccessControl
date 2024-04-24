using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries
{
    public class ExportarExcelProcesamientosVehiProdengQuery : IRequest<byte[]>
    {
        public List<ProcesamientoVehiculoProdeng> ProcesamientoVehiculoProdeng { get; set; }

        public ExportarExcelProcesamientosVehiProdengQuery(List<ProcesamientoVehiculoProdeng> procesamientoVehiculo)
        {
            ProcesamientoVehiculoProdeng = procesamientoVehiculo;
        }
    }
}
