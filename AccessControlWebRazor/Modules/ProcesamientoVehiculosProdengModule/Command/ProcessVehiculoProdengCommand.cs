using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Command
{
    public class ProcessVehiculoProdengCommand : IRequest<ProcesamientoVehiculoProdeng>
    {
        public VehiculoProdeng Vehiculo { get; set; }
        public LecturaPatente LecturaPatente { get; set; }
        

        public ProcessVehiculoProdengCommand(VehiculoProdeng vehiculoProdeng, LecturaPatente lecturaPatente)
        {
            Vehiculo = vehiculoProdeng;
            LecturaPatente = lecturaPatente;            
        }
    }
}
