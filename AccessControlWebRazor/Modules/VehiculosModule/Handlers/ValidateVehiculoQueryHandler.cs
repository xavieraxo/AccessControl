using AccessControlWebRazor.Modules.VehiculosModule.Queries;
using AccessControlWebRazor.Modules.VehiculosModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Handlers
{
    public class ValidateVehiculoQueryHandler : IRequestHandler<ValidateVehiculoQuery, bool>
    {
        private readonly IVehiculoService _service;

        public ValidateVehiculoQueryHandler(IVehiculoService vehiculoService)
        {
            _service = vehiculoService;
        }
        public Task<bool> Handle(ValidateVehiculoQuery request, CancellationToken cancellationToken)
        {
            var result = _service.ValidateVehicle(request.Dominio);
            return Task.FromResult(result);
        }
    }
}
