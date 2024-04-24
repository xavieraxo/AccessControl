using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CentroCostoModule.Queries;
using AccessControlWebRazor.Modules.CentroCostoModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Handlers
{
    public class GetCentroCostoByIdQueryHandler : IRequestHandler<GetCentroCostoByIdQuery, CentroCosto>
    {
        private readonly ICentroCostoService _centroCostoService;

        public GetCentroCostoByIdQueryHandler(ICentroCostoService centroCostoService)
        {
            _centroCostoService = centroCostoService;
        }
        public Task<CentroCosto> Handle(GetCentroCostoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _centroCostoService.GetById(request.ID);  
            return Task.FromResult(result);
        }
    }
}
