using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class GetAllPersonalExternoQueryHandler : IRequestHandler<GetAllPersonalExternoQuery, List<PersonalExterno>>
    {
        private readonly ICertronicService _certronicService;

        public GetAllPersonalExternoQueryHandler(ICertronicService certronicService)
        {
            _certronicService = certronicService;
        }
        public Task<List<PersonalExterno>> Handle(GetAllPersonalExternoQuery request, CancellationToken cancellationToken)
        {
            var result = _certronicService.GetAllPersonalExterno();
            return Task.FromResult(result);
        }
    }
}
