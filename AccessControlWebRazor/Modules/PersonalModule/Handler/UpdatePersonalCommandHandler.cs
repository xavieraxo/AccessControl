using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.PersonalModule.Command;
using AccessControlWebRazor.Modules.PersonalModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.PersonalModule.Handler
{
    public class UpdatePersonalCommandHandler : IRequestHandler<UpdatePersonalCommand, Personal>
    {
        private readonly IPersonalService _personalService;

        public UpdatePersonalCommandHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }
        public Task<Personal> Handle(UpdatePersonalCommand request, CancellationToken cancellationToken)
        {
            var result = _personalService.UpdatePersonal(request.PersonalDTO.ToPersonal());
            return Task.FromResult(result);
        }
    }
}
