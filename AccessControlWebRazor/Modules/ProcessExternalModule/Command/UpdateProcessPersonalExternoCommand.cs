using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Command
{
    public class UpdateProcessPersonalExternoCommand : IRequest<ProcesamientoPersonalExterno>
    {
        public ProcesamientoPersonalExterno ProcesamientoPersonalExterno { get; set; }
        public UpdateProcessPersonalExternoCommand(ProcesamientoPersonalExterno procesamiento)
        {
            ProcesamientoPersonalExterno = procesamiento;
        }
    }
}
