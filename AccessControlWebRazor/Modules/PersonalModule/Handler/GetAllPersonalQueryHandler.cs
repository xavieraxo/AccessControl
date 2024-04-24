using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using AccessControlWebRazor.Modules.PersonalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.PersonalModule.Handler
{
    public class GetAllPersonalQueryHandler : IRequestHandler<GetAllPersonalQuery, List<Personal>>
    {
        private readonly IPersonalService _personalService;

        public GetAllPersonalQueryHandler(IPersonalService personal)
        {
            _personalService = personal;
        }
        public Task<List<Personal>> Handle(GetAllPersonalQuery request, CancellationToken cancellationToken)
        {
            var result = _personalService.GetAllPersonla();
            return Task.FromResult(result);
        }
    }
}
