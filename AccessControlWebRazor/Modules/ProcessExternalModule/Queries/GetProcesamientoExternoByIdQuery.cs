using AccessControlWebRazor.Models;
using MediatR;


namespace AccessControlWebRazor.Modules.ProcessExternalModule.Queries
{
    public class GetProcesamientoExternoByIdQuery : IRequest<ProcesamientoPersonalExterno>
    {
        public int ID { get; set; }

        public GetProcesamientoExternoByIdQuery(int id)
        {
            ID = id;
        }
    }
}
