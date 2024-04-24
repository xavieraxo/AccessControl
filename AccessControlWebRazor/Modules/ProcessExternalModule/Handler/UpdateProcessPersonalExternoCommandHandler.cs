using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Command;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Handler
{
    public class UpdateProcessPersonalExternoCommandHandler : IRequestHandler<UpdateProcessPersonalExternoCommand, ProcesamientoPersonalExterno>
    {
        private readonly IProcesamientoPersonalExternoService _procesamientoService;
        public UpdateProcessPersonalExternoCommandHandler(IProcesamientoPersonalExternoService procesamiento)
        {
            _procesamientoService = procesamiento;
        }
        public Task<ProcesamientoPersonalExterno> Handle(UpdateProcessPersonalExternoCommand request, CancellationToken cancellationToken)
        {
           
            var result = _procesamientoService.UpdateProcess(request.ProcesamientoPersonalExterno);
            return Task.FromResult(result);
        }
    }
}
