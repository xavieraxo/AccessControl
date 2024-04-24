using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Handlers
{
    public class GetProcesamientoByIDQueryHandler : IRequestHandler<GetProcesamientoByIDQuery, Procesamiento>
    {
        private readonly IProcesamientoPersonalService _procesamientoService;

        public GetProcesamientoByIDQueryHandler(IProcesamientoPersonalService procesamientoService)
        {
            _procesamientoService = procesamientoService;
        }
        public Task<Procesamiento> Handle(GetProcesamientoByIDQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoService.GetProcesamientoByID(request.ID);
            return Task.FromResult(result);
        }
    }
}
