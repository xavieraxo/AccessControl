using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries
{
    public class GetProcessVehiProByFilterQuery : IRequest<List<ProcesamientoVehiculoProdeng>>
    {
        public string Filter { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public GetProcessVehiProByFilterQuery(string filter, DateTime? desde, DateTime? hasta)
        {
            Filter = filter;
            Desde = desde;
            Hasta = hasta;
        }
    }
}
