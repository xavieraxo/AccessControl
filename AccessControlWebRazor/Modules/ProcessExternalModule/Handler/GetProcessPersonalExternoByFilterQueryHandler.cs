using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Handler
{
    public class GetProcessPersonalExternoByFilterQueryHandler : IRequestHandler<GetProcessPersonalExternoByFilterQuery, List<ProcesamientoPersonalExterno>>
    {
        private readonly IProcesamientoPersonalExternoService _personalExternoService;

        public GetProcessPersonalExternoByFilterQueryHandler(IProcesamientoPersonalExternoService externoService)
        {
            _personalExternoService = externoService;
        }
        public Task<List<ProcesamientoPersonalExterno>> Handle(GetProcessPersonalExternoByFilterQuery request, CancellationToken cancellationToken)
        {
            var cadena = string.Empty;
            if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde == null && request.Hasta == null)
            {
                cadena = request.Filter.ToUpper().Trim();
                var result = _personalExternoService.GetAll();
                var listaDepurada = result.Where(x => x.DNI == cadena).ToList();
                return Task.FromResult(listaDepurada);
            }
            else if (string.IsNullOrWhiteSpace(request.Filter) && request.Desde != null && request.Hasta != null)
            {
                var result = _personalExternoService.GetAll();
                var listaDepurada = result.Where(x => Convert.ToDateTime(x.Fecha) >= request.Desde && Convert.ToDateTime(x.Fecha) <= request.Hasta).ToList();
                return Task.FromResult(listaDepurada);
            }
            else if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde != null && request.Hasta != null)
            {
                cadena = request.Filter.ToUpper().Trim();
                var result = _personalExternoService.GetAll();
                var listaDepurada = result.Where(x => x.DNI == cadena && Convert.ToDateTime(x.Fecha) >= request.Desde && Convert.ToDateTime(x.Fecha) <= request.Hasta).ToList();
                return Task.FromResult(listaDepurada);
            }
            else
            {
                var result = _personalExternoService.GetAll();
                return Task.FromResult(result);
            }
        }
    }
}
