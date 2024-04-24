using AccessControlWebRazor.Modules.CertronicModule.Command;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class SincronizarCertronicCommandHandler : IRequestHandler<SincronizarCertronicCommand, bool>
    {
        private readonly ICertronicService _service;

        public SincronizarCertronicCommandHandler(ICertronicService certronicService)
        {
            _service = certronicService;
        }
        public  Task<bool> Handle(SincronizarCertronicCommand request, CancellationToken cancellationToken)
        {
            var result = _service.Sincronizacion();
            return Task.FromResult(result);
        }
    }
}
