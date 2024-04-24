using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Handlers
{
    public class GetCentroDeCostoByFilterQueryHandler : IRequestHandler<GetCentroDeCostoByFilterQuery, List<CentroCosto>>
    {
        private readonly ICentroCostoService _centroCostoService;
        public GetCentroDeCostoByFilterQueryHandler(ICentroCostoService centroCostoService)
        {
            _centroCostoService = centroCostoService;   
        }
        public Task<List<CentroCosto>> Handle(GetCentroDeCostoByFilterQuery request, CancellationToken cancellationToken)
        {
            var result = _centroCostoService.GetByFilter(request.Filter);
            return Task.FromResult(result);
        }
    }
}
