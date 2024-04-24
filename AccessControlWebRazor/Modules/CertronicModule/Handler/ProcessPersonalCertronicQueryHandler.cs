using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class ProcessPersonalCertronicQueryHandler : IRequestHandler<ProcessPersonalCertronicQuery, bool>
    {
        private readonly ICertronicService _certronicService;

        public ProcessPersonalCertronicQueryHandler(ICertronicService certronicService )
        {
            _certronicService = certronicService;
        }
        public Task<bool> Handle(ProcessPersonalCertronicQuery request, CancellationToken cancellationToken)
        {
            var result = _certronicService.ValidatePersonal(request.Personal);
            return Task.FromResult(result);
        }
    }
}
