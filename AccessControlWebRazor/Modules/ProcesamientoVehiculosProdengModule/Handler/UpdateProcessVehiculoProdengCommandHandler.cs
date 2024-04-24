using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Command;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Handler
{
    public class UpdateProcessVehiculoProdengCommandHandler : IRequestHandler<UpdateProcessVehiculoProdengCommand, ProcesamientoVehiculoProdeng>
    {
        private readonly IProcessVehiculoProdengService _service;
        public UpdateProcessVehiculoProdengCommandHandler(IProcessVehiculoProdengService service)
        {
            _service = service;
        }
        public Task<ProcesamientoVehiculoProdeng> Handle(UpdateProcessVehiculoProdengCommand request, CancellationToken cancellationToken)
        {
            request._procesamiento.Procesado = 1;
            request._procesamiento.EstadoFichado = " ";
            var result = _service.UpdateProcess(request._procesamiento);
            return Task.FromResult(result);
        }
    }
}
