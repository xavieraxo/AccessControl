using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Command;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class CreateVehiculoCommandHandler : IRequestHandler<CreateVehiculoCommand, Vehiculo>
    {
        private readonly ICertronicService _certronicService;

        public CreateVehiculoCommandHandler(ICertronicService certronicService)
        {
            _certronicService = certronicService;
        }
        public Task<Vehiculo> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var result = _certronicService.CreateVehiculo(request.Vehiculo);
            return Task.FromResult(result);
        }
    }
}
