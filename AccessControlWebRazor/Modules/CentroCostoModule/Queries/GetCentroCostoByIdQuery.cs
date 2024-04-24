using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Queries
{
    public class GetCentroCostoByIdQuery :IRequest<CentroCosto>
    {
        public int ID { get; set; }

        public GetCentroCostoByIdQuery(int id)
        {
            ID = id;
        }
    }
}
