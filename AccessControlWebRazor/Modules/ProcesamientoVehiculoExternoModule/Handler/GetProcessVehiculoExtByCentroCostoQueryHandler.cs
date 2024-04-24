using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Data;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class GetProcessVehiculoExtByCentroCostoQueryHandler : IRequestHandler<GetProcessVehiculoExtByCentroCostoQuery, List<ProcesamientoVehiculoExterno>>
    {
        private readonly IProcesamientoVehiculoExternoService _vehiculoExtService;
        public GetProcessVehiculoExtByCentroCostoQueryHandler(IProcesamientoVehiculoExternoService vehiculoExtService)
        {
            _vehiculoExtService = vehiculoExtService;
        }
        public Task<List<ProcesamientoVehiculoExterno>> Handle(GetProcessVehiculoExtByCentroCostoQuery request, CancellationToken cancellationToken)
        {
            var result = _vehiculoExtService.GetAllByCentroCosto(request.CentroCosto);
            return Task.FromResult(result);
        }
    }
}
