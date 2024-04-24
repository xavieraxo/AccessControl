using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Queries
{
    public class GetProcessPersonalExternoByFilterQuery : IRequest<List<ProcesamientoPersonalExterno>>
    {
        public string Filter { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public GetProcessPersonalExternoByFilterQuery(string filter, DateTime? desde, DateTime? hasta)
        {
            Filter = filter;
            Desde = desde;
            Hasta = hasta;
        }

    }
}
