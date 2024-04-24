using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Handlers
{
    public class GetAllProcesamientosQueryHandler : IRequestHandler<GetAllProcesamientosQuery, List<Procesamiento>>
    {
        private readonly IProcesamientoPersonalService _procesamientoService;

        public GetAllProcesamientosQueryHandler(IProcesamientoPersonalService procesamientoService)
        {
            _procesamientoService = procesamientoService;
        }
        public Task<List<Procesamiento>> Handle(GetAllProcesamientosQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoService.GetAllProcesamiento();
            return Task.FromResult(result);
        }
    }
}
