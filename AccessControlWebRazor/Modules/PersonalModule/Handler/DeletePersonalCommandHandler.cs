using AccessControlWebRazor.Modules.PersonalModule.Command;
using AccessControlWebRazor.Modules.PersonalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Handler
{
    public class DeletePersonalCommandHandler : IRequestHandler<DeletePersonalCommand, bool>
    {
        private readonly IPersonalService _personalService;

        public DeletePersonalCommandHandler(IPersonalService personalService)
        {
            _personalService = personalService;
        }
       
        Task<bool> IRequestHandler<DeletePersonalCommand, bool>.Handle(DeletePersonalCommand request, CancellationToken cancellationToken)
        {
            _personalService.DeletePersonal(request.ID);
            return Task.FromResult(true);
        }
    }
}
