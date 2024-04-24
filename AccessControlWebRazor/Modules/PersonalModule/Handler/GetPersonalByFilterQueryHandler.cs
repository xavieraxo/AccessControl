using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using AccessControlWebRazor.Modules.PersonalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Handler
{
    public class GetPersonalByFilterQueryHandler : IRequestHandler<GetPersonalByFilterQuery, List<Personal>>
    {
        private readonly IPersonalService _personalService;

        public GetPersonalByFilterQueryHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }
        public Task<List<Personal>> Handle(GetPersonalByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _personalService.GetPersonalByFilter(request.Filter);
            return Task.FromResult(result);
        }
    }
}
