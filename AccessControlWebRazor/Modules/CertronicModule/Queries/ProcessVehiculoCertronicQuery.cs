using AccessControlWebRazor.DTO_s.CertronicDTO_s;
using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Queries
{
    public class ProcessVehiculoCertronicQuery : IRequest<bool>
    {
        public Vehiculo Vehiculo { get; set; }

        public ProcessVehiculoCertronicQuery(Vehiculo vehiculo)
        {
            Vehiculo = vehiculo;
        }
    }
}
