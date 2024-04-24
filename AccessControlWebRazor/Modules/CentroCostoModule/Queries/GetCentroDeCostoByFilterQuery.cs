using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Queries
{
    public class GetCentroDeCostoByFilterQuery : IRequest<List<CentroCosto>>
    {
        public string Filter { get; set; }

        public GetCentroDeCostoByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
}
