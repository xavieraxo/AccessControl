using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Queries
{
    public class GetByDominioVehiculoQuery : IRequest<Vehiculo>
    {
        public string Dominio { get; set; }
        public GetByDominioVehiculoQuery(string dominio)
        {
            Dominio = dominio;
        }
    }
}
