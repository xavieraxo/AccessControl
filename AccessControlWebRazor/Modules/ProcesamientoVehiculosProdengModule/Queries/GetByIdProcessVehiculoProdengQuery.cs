using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries
{
    public class GetByIdProcessVehiculoProdengQuery : IRequest<ProcesamientoVehiculoProdeng>
    {
        public int ID { get; set; }
        public GetByIdProcessVehiculoProdengQuery(int id)
        {
            ID = id;
        }
    }
}
