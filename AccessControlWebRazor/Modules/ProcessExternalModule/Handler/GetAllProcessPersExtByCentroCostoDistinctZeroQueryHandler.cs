using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Handler
{
    public class GetAllProcessPersExtByCentroCostoDistinctZeroQueryHandler : IRequestHandler<GetAllProcessPersExtByCentroCostoDistinctZeroQuery, List<ProcesamientoPersonalExterno>>
    {
        private readonly IProcesamientoPersonalExternoService _externoService;

        public GetAllProcessPersExtByCentroCostoDistinctZeroQueryHandler(IProcesamientoPersonalExternoService externoService)
        {
            _externoService = externoService;
        }
        public Task<List<ProcesamientoPersonalExterno>> Handle(GetAllProcessPersExtByCentroCostoDistinctZeroQuery request, CancellationToken cancellationToken)
        {
            var result = _externoService.GetAllProcessPersExtByCentroCostoDisctinctZero();
            return Task.FromResult(result); 
        }
    }
}
