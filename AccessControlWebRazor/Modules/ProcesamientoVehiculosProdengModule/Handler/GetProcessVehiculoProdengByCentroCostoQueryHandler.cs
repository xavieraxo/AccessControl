using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Handler
{
    public class GetProcessVehiculoProdengByCentroCostoQueryHandler : IRequestHandler<GetProcessVehiculoProdengByCentroCostoQuery, List<ProcesamientoVehiculoProdeng>>
    {
        private readonly IProcessVehiculoProdengService _service;
        public GetProcessVehiculoProdengByCentroCostoQueryHandler(IProcessVehiculoProdengService service)
        {
            _service = service;
        }

        public Task<List<ProcesamientoVehiculoProdeng>> Handle(GetProcessVehiculoProdengByCentroCostoQuery request, CancellationToken cancellationToken)
        {
            var result = _service.GetAllByCentroCosto(request.CentroCosto);
            return Task.FromResult(result);
        }
    }
}
