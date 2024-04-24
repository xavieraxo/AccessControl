using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using AccessControlWebRazor.Modules.PersonalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.PersonalModule.Handler
{
    public class GetPersonalByDNIQueryHandler : IRequestHandler<GetPersonalByDNIQuery, Personal>
    {
        private readonly IPersonalService _personalService;

        public GetPersonalByDNIQueryHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }
        public Task<Personal> Handle(GetPersonalByDNIQuery request, CancellationToken cancellationToken)
        {
            var result = _personalService.GetPersonalByDni(request.DNI);
            return Task.FromResult(result);
        }
    }
}
