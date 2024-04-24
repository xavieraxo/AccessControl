using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class ProcessMaquinariaCertronicQueryHandler : IRequestHandler<ProcessMaquinariaCertronicQuery, bool>
    {
        private readonly ICertronicService _service;

        public ProcessMaquinariaCertronicQueryHandler(ICertronicService certronicService)
        {
            _service = certronicService;
        }
        public Task<bool> Handle(ProcessMaquinariaCertronicQuery request, CancellationToken cancellationToken)
        {
            var result = _service.ValidateMaquinaria(request.Maquinaria);
            return Task.FromResult(result);
        }
    }
}
