using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Queries
{
    public class GetProcessPersonalExternoByCCostoIdQuery : IRequest<List<ProcesamientoPersonalExterno>>
    {
        public int CentroCosto { get; set; }

        public GetProcessPersonalExternoByCCostoIdQuery(int centroCosto)
        {
            CentroCosto = centroCosto;
        }
    }
}
