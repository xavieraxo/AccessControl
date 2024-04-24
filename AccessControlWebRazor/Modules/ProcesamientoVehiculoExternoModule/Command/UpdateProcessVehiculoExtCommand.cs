using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Command
{
    public class UpdateProcessVehiculoExtCommand : IRequest<ProcesamientoVehiculoExterno>
    {
        public ProcesamientoVehiculoExterno _procesamiento { get; set; }

        public UpdateProcessVehiculoExtCommand(ProcesamientoVehiculoExterno procesamientoVehiculoExterno)
        {
            _procesamiento = procesamientoVehiculoExterno;   
        }
    }
}
