using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Handlers
{
    public class GetAllCentroCostoQueryHandler : IRequestHandler<GetAllCentroCostoQuery, List<CentroCosto>>
    {
        private readonly ICentroCostoService _centroCostoService;

        public GetAllCentroCostoQueryHandler(ICentroCostoService centroCostoService)
        {
            _centroCostoService = centroCostoService;
        }
        public Task<List<CentroCosto>> Handle(GetAllCentroCostoQuery request, CancellationToken cancellationToken)
        {
            var result = _centroCostoService.GetAll();
            return Task.FromResult(result);
        }
    }
}
