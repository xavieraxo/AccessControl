using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Handler
{
    public class GetProcesamientoExternoByIdHandler: IRequestHandler<GetProcesamientoExternoByIdQuery, ProcesamientoPersonalExterno>
    {
        private readonly IProcesamientoPersonalExternoService _procesamientoService;

        public GetProcesamientoExternoByIdHandler(IProcesamientoPersonalExternoService procesamientoService)
        {
            _procesamientoService = procesamientoService;
        }

        public Task<ProcesamientoPersonalExterno> Handle(GetProcesamientoExternoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoService.GetProcesamientoExternoById(request.ID);
            return Task.FromResult(result);
        }
    }
}
