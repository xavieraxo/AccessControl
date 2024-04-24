using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries
{
    public class GetProcesamientoPersonalByFilterQuery : IRequest<List<Procesamiento>>
    {
        public string Filter { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public GetProcesamientoPersonalByFilterQuery(string filter, DateTime? desde, DateTime? hasta)
        {
            Filter = filter;
            Desde = desde;
            Hasta = hasta;
        }
    }
}
