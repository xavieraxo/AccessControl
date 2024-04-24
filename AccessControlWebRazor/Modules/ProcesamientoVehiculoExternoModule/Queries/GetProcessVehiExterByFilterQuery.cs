using AccessControlWebRazor.Models;
using MediatR;


namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries
{
    public class GetProcessVehiExterByFilterQuery : IRequest<List<ProcesamientoVehiculoExterno>>
    {
        public string Filter { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        public GetProcessVehiExterByFilterQuery(string filter, DateTime? desde, DateTime? hasta)
        {
            Filter = filter;
            Desde = desde;
            Hasta = hasta;
        }
    }
}
