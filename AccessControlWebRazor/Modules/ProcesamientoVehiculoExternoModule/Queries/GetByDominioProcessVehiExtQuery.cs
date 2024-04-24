using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries
{
    public class GetByDominioProcessVehiExtQuery : IRequest<ProcesamientoVehiculoExterno>
    {
        public string Dominio { get; set; }
        public GetByDominioProcessVehiExtQuery(string dominio)
        {
            Dominio = dominio;
        }
    }
}
