using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class ProcessVehiculoCertronicQueryHandler : IRequestHandler<ProcessVehiculoCertronicQuery, bool>
    {
        private readonly ICertronicService _certronicService;

        public ProcessVehiculoCertronicQueryHandler(ICertronicService certronicService)
        {
            _certronicService = certronicService;
        }
        public Task<bool> Handle(ProcessVehiculoCertronicQuery request, CancellationToken cancellationToken)
        {
            var result = _certronicService.ValidateVehiculo(request.Vehiculo);
            return Task.FromResult(result);
        }
    }
}
