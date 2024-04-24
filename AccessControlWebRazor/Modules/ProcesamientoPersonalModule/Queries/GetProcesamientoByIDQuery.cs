using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries
{
    public class GetProcesamientoByIDQuery : IRequest<Procesamiento>
    {
        public int ID { get; set; }

        public GetProcesamientoByIDQuery(int id)
        {
            ID = id;
        }
    }
}
