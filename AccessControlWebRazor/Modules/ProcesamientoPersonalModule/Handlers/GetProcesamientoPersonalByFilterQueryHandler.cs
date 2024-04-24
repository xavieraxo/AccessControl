using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Handlers
{
    public class GetProcesamientoPersonalByFilterQueryHandler : IRequestHandler<GetProcesamientoPersonalByFilterQuery, List<Procesamiento>>
    {
        private readonly IProcesamientoPersonalService _procesamientoPersonalService;
        public GetProcesamientoPersonalByFilterQueryHandler(IProcesamientoPersonalService procesamientoPersonalService)
        {
            _procesamientoPersonalService = procesamientoPersonalService;
        }
        public Task<List<Procesamiento>> Handle(GetProcesamientoPersonalByFilterQuery request, CancellationToken cancellationToken)
        {
            var cadena = string.Empty;
            if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde == null && request.Hasta == null)
            {
                cadena = request.Filter.ToUpper().Trim();
                var result = _procesamientoPersonalService.GetAllProcesamiento();
                var listaDepurada = result.Where(x => x.DNI == cadena || x.Legajo == cadena).ToList();
                return Task.FromResult(listaDepurada);
            }
            else if (string.IsNullOrWhiteSpace(request.Filter) && request.Desde != null && request.Hasta != null)
            {
                var result = _procesamientoPersonalService.GetAllProcesamiento();
                var listaDepurada = result.Where(x => Convert.ToDateTime(x.Fecha) >= request.Desde && Convert.ToDateTime(x.Fecha) <= request.Hasta).ToList();
                return Task.FromResult(listaDepurada);
            }
            else if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde != null && request.Hasta != null)
            {
                var result = _procesamientoPersonalService.GetAllProcesamiento();
                var listaDepurada = result.Where(x => x.DNI == cadena || x.Legajo == cadena || Convert.ToDateTime(x.Fecha) >= request.Desde && Convert.ToDateTime(x.Fecha) <= request.Hasta).ToList();
                return Task.FromResult(listaDepurada);
            }
            else
            {   
                var result = _procesamientoPersonalService.GetAllProcesamiento();
                return Task.FromResult(result);
            }
        }
    }
}
