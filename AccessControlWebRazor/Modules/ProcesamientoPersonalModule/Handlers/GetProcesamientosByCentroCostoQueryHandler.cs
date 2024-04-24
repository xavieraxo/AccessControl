using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service;
using Humanizer;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Handlers
{
    public class GetProcesamientosByCentroCostoQueryHandler : IRequestHandler<GetProcesamientosByCentroCostoQuery, List<Procesamiento>>
    {
        private readonly IProcesamientoPersonalService _procesamientoService;

        public GetProcesamientosByCentroCostoQueryHandler(IProcesamientoPersonalService procesamientoService)
        {
            _procesamientoService = procesamientoService;
        }
        public Task<List<Procesamiento>> Handle(GetProcesamientosByCentroCostoQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoService.GetProcemientoByCentroCosto(request.CentroCosto);
            
            return Task.FromResult(result);
        }
    }
}
