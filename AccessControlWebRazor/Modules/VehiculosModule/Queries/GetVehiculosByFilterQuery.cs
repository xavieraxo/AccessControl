using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Queries
{
    public class GetVehiculosByFilterQuery : IRequest<List<Vehiculo>>
    {
        public string Filter { get; set; }
        public GetVehiculosByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
}
