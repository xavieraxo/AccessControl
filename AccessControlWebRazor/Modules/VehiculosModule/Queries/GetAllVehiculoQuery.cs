using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Queries
{
    public class GetAllVehiculoQuery : IRequest<List<Vehiculo>>
    {
    }
}
