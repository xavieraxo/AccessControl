using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.VehiculosModule.Queries;
using AccessControlWebRazor.Modules.VehiculosModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Handlers
{
    public class GetByDominioVehiculoQueryHandler : IRequestHandler<GetByDominioVehiculoQuery, Vehiculo>
    {
        private readonly IVehiculoService _service;

        public GetByDominioVehiculoQueryHandler(IVehiculoService vehiculoService)
        {
            _service = vehiculoService;
        }
        public Task<Vehiculo> Handle(GetByDominioVehiculoQuery request, CancellationToken cancellationToken)
        {
            var result = _service.GetByDominio(request.Dominio);
            return Task.FromResult(result);
        }
    }
}
