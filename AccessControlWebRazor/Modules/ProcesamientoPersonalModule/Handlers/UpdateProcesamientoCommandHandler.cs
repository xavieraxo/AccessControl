using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Command;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Handlers
{
    public class UpdateProcesamientoCommandHandler : IRequestHandler<UpdateProcesamientoCommand, Procesamiento>
    {
        private readonly IProcesamientoPersonalService _service;

        public UpdateProcesamientoCommandHandler(IProcesamientoPersonalService procesamientoService)
        {
            _service = procesamientoService;
        }
        public Task<Procesamiento> Handle(UpdateProcesamientoCommand request, CancellationToken cancellationToken)
        {
            request.Procesamiento.Procesado = true;
            request.Procesamiento.EstadoFichada = " ";
            var result = _service.UpdateProcesamiento(request.Procesamiento);
            return Task.FromResult(result);
        }
    }
}
