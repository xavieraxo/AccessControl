using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Command
{
    public class ProcesamientoVehiculoExternoCommand : IRequest<ProcesamientoVehiculoExterno>
    {
        public Vehiculo Vehiculo { get; set; }
        public LecturaPatente Lectura { get; set; }
        public ProcesamientoVehiculoExternoCommand(Vehiculo vehiculo, LecturaPatente lecturasGarita)
        {
            Vehiculo = vehiculo;
            Lectura = lecturasGarita;
        }
    }
}
