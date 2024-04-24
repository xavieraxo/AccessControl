using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class GetProcessVehiculoExtByCostoNoZeroQueryHandler : IRequestHandler<GetProcessVehiculoExtByCostoNoZeroQuery, List<ProcesamientoVehiculoExterno>>
    {
        private readonly IProcesamientoVehiculoExternoService _vehiculoExtService;
        public GetProcessVehiculoExtByCostoNoZeroQueryHandler(IProcesamientoVehiculoExternoService vehiculoExtService)
        {
            _vehiculoExtService = vehiculoExtService;
        }
        public Task<List<ProcesamientoVehiculoExterno>> Handle(GetProcessVehiculoExtByCostoNoZeroQuery request, CancellationToken cancellationToken)
        {
            var result = _vehiculoExtService.GetAllByCentroCostoNoCZero();
            return Task.FromResult(result);
        }

    }
}
