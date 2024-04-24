using AccessControlWebRazor.DTO_s.CertronicDTO_s;
using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Command
{
    public class CreateVehiculoCommand : IRequest<Vehiculo>
    {
        public VehiculoDTO Vehiculo { get; set; }

        public CreateVehiculoCommand(VehiculoDTO vehiculoDTO)
        {
            Vehiculo = vehiculoDTO;
        }
    }
}
