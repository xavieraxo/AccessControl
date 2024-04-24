using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Queries
{
    public class GetAllVehiculosExternosQuery : IRequest<List<Vehiculo>>
    {
    }
}
