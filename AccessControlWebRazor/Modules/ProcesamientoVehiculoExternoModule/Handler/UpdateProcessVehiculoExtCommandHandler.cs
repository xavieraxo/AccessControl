using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Command;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class UpdateProcessVehiculoExtCommandHandler : IRequestHandler<UpdateProcessVehiculoExtCommand, ProcesamientoVehiculoExterno>
    {
        private readonly IProcesamientoVehiculoExternoService _procesamientoVehiculoExternoService;
        public UpdateProcessVehiculoExtCommandHandler(IProcesamientoVehiculoExternoService procesamientoVehiculoExterno)
        {
            _procesamientoVehiculoExternoService = procesamientoVehiculoExterno;
        }
        public Task<ProcesamientoVehiculoExterno> Handle(UpdateProcessVehiculoExtCommand request, CancellationToken cancellationToken)
        {
            request._procesamiento.Procesado = 1;
            request._procesamiento.EstadoFichado = " ";
            var result = _procesamientoVehiculoExternoService.UpdateProcesamiento(request._procesamiento);
            return Task.FromResult(result);
        }
    }
}
