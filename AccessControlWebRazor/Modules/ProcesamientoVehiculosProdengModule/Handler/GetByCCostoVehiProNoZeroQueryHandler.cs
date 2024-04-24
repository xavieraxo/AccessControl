using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Data;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Handler
{
    public class GetByCCostoVehiProNoZeroQueryHandler : IRequestHandler<GetByCCostoVehiProNoZeroQuery, List<ProcesamientoVehiculoProdeng>>
    {
        private readonly IProcessVehiculoProdengService _processVehiculoProdengService;
        public GetByCCostoVehiProNoZeroQueryHandler(IProcessVehiculoProdengService processVehiculoProdengService)
        {
            _processVehiculoProdengService = processVehiculoProdengService;
        }
        public Task<List<ProcesamientoVehiculoProdeng>> Handle(GetByCCostoVehiProNoZeroQuery request, CancellationToken cancellationToken)
        {
            var result = _processVehiculoProdengService.GetAllByCentroCostoNoCZero();
            return Task.FromResult(result);
        }
    }
}
