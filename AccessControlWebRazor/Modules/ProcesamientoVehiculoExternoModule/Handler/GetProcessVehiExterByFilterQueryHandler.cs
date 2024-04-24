using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;


namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class GetProcessVehiExterByFilterQueryHandler : IRequestHandler<GetProcessVehiExterByFilterQuery, List<ProcesamientoVehiculoExterno>>
    {
        private readonly IProcesamientoVehiculoExternoService _service;
        public GetProcessVehiExterByFilterQueryHandler(IProcesamientoVehiculoExternoService vehiculoExternoService)
        {
            _service = vehiculoExternoService;
        }
        public Task<List<ProcesamientoVehiculoExterno>> Handle(GetProcessVehiExterByFilterQuery request, CancellationToken cancellationToken)
        {
            var cadena = string.Empty;
            if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde == null && request.Hasta == null)
            {
                cadena = request.Filter.ToUpper().Trim();
                var result = _service.GetAll();
                var listaDepurada = result.Where(x => x.Dominio.ToUpper() == cadena.ToUpper()).ToList();
                return Task.FromResult(listaDepurada);
            }          
            else if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde != null && request.Hasta != null)
            {
                cadena = request.Filter.ToUpper().Trim();
                var result = _service.GetAll();
                var listaDepurada = result.Where(x => x.Dominio == cadena || Convert.ToDateTime(x.Fecha) >= request.Desde && Convert.ToDateTime(x.Fecha) <= request.Hasta).ToList();
                return Task.FromResult(listaDepurada);
            }
            else if (string.IsNullOrWhiteSpace(request.Filter) && request.Desde != null && request.Hasta != null)
            {
                var result = _service.GetAll();
                var listaDepurada = result.Where(x => Convert.ToDateTime(x.Fecha) >= request.Desde && Convert.ToDateTime(x.Fecha) <= request.Hasta).ToList();
                return Task.FromResult(listaDepurada);
            }
            else
            {
                var result = _service.GetAll();
                return Task.FromResult(result);
            }
        }
    }
}
