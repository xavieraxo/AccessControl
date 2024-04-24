using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Handler
{
    public class ExportarExcelProcesamientosVehiProdengQueryHandler : IRequestHandler<ExportarExcelProcesamientosVehiProdengQuery, byte[]>
    {
        private readonly IProcessVehiculoProdengService _service;

        public ExportarExcelProcesamientosVehiProdengQueryHandler(IProcessVehiculoProdengService processVehiculoProdengService)
        {
            _service = processVehiculoProdengService;
        }
        public Task<byte[]> Handle(ExportarExcelProcesamientosVehiProdengQuery request, CancellationToken cancellationToken)
        {
            var result = _service.ExportToExcel(request.ProcesamientoVehiculoProdeng);
            return Task.FromResult(result);
        }
    }
}
