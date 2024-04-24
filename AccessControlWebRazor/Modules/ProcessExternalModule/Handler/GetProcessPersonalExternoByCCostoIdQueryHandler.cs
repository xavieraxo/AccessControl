using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Handler
{
    public class GetProcessPersonalExternoByCCostoIdQueryHandler : IRequestHandler<GetProcessPersonalExternoByCCostoIdQuery, List<ProcesamientoPersonalExterno>>
    {
        private readonly IProcesamientoPersonalExternoService _servicePersonalE;
        public GetProcessPersonalExternoByCCostoIdQueryHandler(IProcesamientoPersonalExternoService service)
        {
            _servicePersonalE = service;
        }
        public Task<List<ProcesamientoPersonalExterno>> Handle(GetProcessPersonalExternoByCCostoIdQuery request, CancellationToken cancellationToken)
        {
            var result = _servicePersonalE.GetAllByCentroCosto(request.CentroCosto);
            return Task.FromResult(result);
        }
    }
}
