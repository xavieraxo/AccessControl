using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Handler
{
    public class ExportarExcelPersonalExternoQueryHandler : IRequestHandler<ExportarExcelPersonalExternoQuery, byte[]>
    {
        private readonly IProcesamientoPersonalExternoService _procesamientoPersonalExterno;

        public ExportarExcelPersonalExternoQueryHandler(IProcesamientoPersonalExternoService procesamientoPersonal)
        {
            _procesamientoPersonalExterno = procesamientoPersonal;
        }
        public Task<byte[]> Handle(ExportarExcelPersonalExternoQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoPersonalExterno.ExportToExcel(request.PersonalExternos);
            return Task.FromResult(result);
        }
    }
}
