using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.PersonalModule.Queries;
using AccessControlWebRazor.Modules.PersonalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Handler
{
    public class GetPersonalByIDQueryHandler : IRequestHandler<GetPersonalByIDQuery, Personal>
    {
        private readonly IPersonalService _personalService;

        public GetPersonalByIDQueryHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }
        public Task<Personal> Handle(GetPersonalByIDQuery request, CancellationToken cancellationToken)
        {
            var result = _personalService.GetPersonalByID(request.ID);
            return Task.FromResult(result);
        }
    }
}
