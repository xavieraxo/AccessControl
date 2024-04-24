using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.PersonalModule.Command;
using AccessControlWebRazor.Modules.PersonalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Handler
{
    public class CreatePersonalCommandHandler : IRequestHandler<CreatePersonalCommand, Personal>
    {
        private readonly IPersonalService _personalService;

        public CreatePersonalCommandHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }
        public Task<Personal> Handle(CreatePersonalCommand request, CancellationToken cancellationToken)
        {
            var result = _personalService.CreatePersonal(request.PersonalDTO.ToPersonal());
            return Task.FromResult(result);
        }
    }
}
