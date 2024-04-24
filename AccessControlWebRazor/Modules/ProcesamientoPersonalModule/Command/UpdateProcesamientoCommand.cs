using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Command
{
    public class UpdateProcesamientoCommand : IRequest<Procesamiento>
    {
        public Procesamiento Procesamiento { get; set; }

        public UpdateProcesamientoCommand(Procesamiento procesamiento)
        {
            Procesamiento = procesamiento;
        }
    }
}
