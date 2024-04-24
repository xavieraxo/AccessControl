using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Handler
{
    public class GetProcessVehiProByFilterQueryHandler : IRequestHandler<GetProcessVehiProByFilterQuery, List<ProcesamientoVehiculoProdeng>>
    {
        private readonly IProcessVehiculoProdengService _vehiculoProdengService;

        public GetProcessVehiProByFilterQueryHandler(IProcessVehiculoProdengService processVehiculoProdengService)
        {
            _vehiculoProdengService = processVehiculoProdengService;
        }
        public Task<List<ProcesamientoVehiculoProdeng>> Handle(GetProcessVehiProByFilterQuery request, CancellationToken cancellationToken)
        {
            var cadena = string.Empty;
            if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde == null && request.Hasta == null)
            {
                cadena = request.Filter.ToUpper().Trim();
                var result = _vehiculoProdengService.GetAllVehiculoProdengProcesado();
                var listaDepurada = result.Where(x => x.Dominio.ToUpper() == cadena.ToUpper()).ToList();
                return Task.FromResult(listaDepurada);
            }
            else if (string.IsNullOrWhiteSpace(request.Filter) && request.Desde != null && request.Hasta != null)
            {
                var result = _vehiculoProdengService.GetAllVehiculoProdengProcesado();
                var listaDepurada = result.Where(x => Convert.ToDateTime(x.Fecha) >= request.Desde && Convert.ToDateTime(x.Fecha) <= request.Hasta).ToList();
                return Task.FromResult(listaDepurada);
            }
            else if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde != null && request.Hasta != null)
            {
                cadena = request.Filter.ToUpper().Trim();
                var result = _vehiculoProdengService.GetAllVehiculoProdengProcesado();
                var listaDepurada = result.Where(x => x.Dominio.ToUpper() == cadena.ToUpper() || Convert.ToDateTime(x.Fecha) >= request.Desde && Convert.ToDateTime(x.Fecha) <= request.Hasta).ToList();
                return Task.FromResult(listaDepurada);
            }
            else
            {
                var result = _vehiculoProdengService.GetAllVehiculoProdengProcesado();
                return Task.FromResult(result);
            }
        }
    }
}
