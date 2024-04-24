using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries
{
    public class GetByIDProcessVehiExtQuery : IRequest<ProcesamientoVehiculoExterno>
    {
        public int ID { get; set; }
        public GetByIDProcessVehiExtQuery(int id)
        {
                ID = id;    
        }
    }
}
