using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Handlers
{
    public class ExportExcelPersonalProcesamientoQueryHandler : IRequestHandler<ExportExcelPersonalProcesamientoQuery, byte[]>
    {
        private readonly IProcesamientoPersonalService _personalService;

        public ExportExcelPersonalProcesamientoQueryHandler(IProcesamientoPersonalService procesamientoPersonal)
        {
            _personalService = procesamientoPersonal;
        }
        public Task<byte[]> Handle(ExportExcelPersonalProcesamientoQuery request, CancellationToken cancellationToken)
        {
            var result = _personalService.ExportToExcel(request.Procesamientos);
            return Task.FromResult(result);
        }
    }
}
