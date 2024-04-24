using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries
{
    public class ExportarProcessVehiExternoToExcelQuery : IRequest<byte[]>
    {
        public List<ProcesamientoVehiculoExterno> Procesamientos { get; set; }

        public ExportarProcessVehiExternoToExcelQuery(List<ProcesamientoVehiculoExterno> procesamientoVehiculoExternoByte)
        {
            Procesamientos = procesamientoVehiculoExternoByte;
        }
    }
}
