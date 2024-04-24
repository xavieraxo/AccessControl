using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class ExportarProcessVehiExternoToExcelQueryHandler : IRequestHandler<ExportarProcessVehiExternoToExcelQuery, byte[]>
    {
        private readonly IProcesamientoVehiculoExternoService _procesamientoVehiculoExternoService;
        public ExportarProcessVehiExternoToExcelQueryHandler(IProcesamientoVehiculoExternoService procesamientoVehiculoExternoService)
        {
            _procesamientoVehiculoExternoService = procesamientoVehiculoExternoService;
        }
        public Task<byte[]> Handle(ExportarProcessVehiExternoToExcelQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoVehiculoExternoService.ExportToExcel(request.Procesamientos);
            return Task.FromResult(result);
        }
    }
}
