using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.VehiculosModule.Queries;
using AccessControlWebRazor.Modules.VehiculosModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Handlers
{
    public class GetVehiculosByFilterQueryHandler : IRequestHandler<GetVehiculosByFilterQuery, List<Vehiculo>>
    {
        private readonly IVehiculoService _service;
        public GetVehiculosByFilterQueryHandler(IVehiculoService vehiculoService)
        {
            _service = vehiculoService;
        }
        public Task<List<Vehiculo>> Handle(GetVehiculosByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _service.GetAll();
            var listaDepurada = result.Where(x => x.Dominio.ToUpper().Trim().Equals(request.Filter.ToUpper().Trim()) 
                                               || x.Model.ToUpper().Trim().Contains(request.Filter.ToUpper().Trim())).ToList();
            return Task.FromResult(listaDepurada);
        }
    }
}
