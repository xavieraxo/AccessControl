using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class GetByDominioProcessVehiExtQueryHandler : IRequestHandler<GetByDominioProcessVehiExtQuery, ProcesamientoVehiculoExterno>
    {
        private readonly IProcesamientoVehiculoExternoService _procesamientoVehiculoExternoService;
        public GetByDominioProcessVehiExtQueryHandler(IProcesamientoVehiculoExternoService procesamientoVehiculoExternoService)
        {
            _procesamientoVehiculoExternoService = procesamientoVehiculoExternoService;
        }

        public Task<ProcesamientoVehiculoExterno> Handle(GetByDominioProcessVehiExtQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoVehiculoExternoService.GetByDominio(request.Dominio);
            return Task.FromResult(result);
        }
    }
}
