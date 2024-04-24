using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries
{
    public class GetLecturaGaritasLogByFilterQuery : IRequest<List<LecturasGaritaLog>>
    {
        public string Filter { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public GetLecturaGaritasLogByFilterQuery(string filter, DateTime? desde, DateTime? hasta)
        {
            Filter = filter;
            Desde = desde;
            Hasta = hasta;
        }
    }
}
