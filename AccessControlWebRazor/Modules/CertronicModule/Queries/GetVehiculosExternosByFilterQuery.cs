using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Queries
{
    public class GetVehiculosExternosByFilterQuery : IRequest<List<Vehiculo>>
    {
        public string Filter { get; set; }
        public GetVehiculosExternosByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
}
