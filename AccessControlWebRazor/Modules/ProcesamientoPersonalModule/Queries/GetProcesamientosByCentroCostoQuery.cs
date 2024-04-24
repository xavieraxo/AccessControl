using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries
{
    public class GetProcesamientosByCentroCostoQuery : IRequest<List<Procesamiento>>
    {
        public int CentroCosto { get; set; }

        public GetProcesamientosByCentroCostoQuery(int centroCosto)
        {
            CentroCosto = centroCosto;
        }
    }
}
