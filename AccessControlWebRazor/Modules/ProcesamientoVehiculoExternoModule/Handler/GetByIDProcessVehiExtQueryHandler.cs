using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class GetByIDProcessVehiExtQueryHandler : IRequestHandler<GetByIDProcessVehiExtQuery, ProcesamientoVehiculoExterno>
    {
        private readonly IProcesamientoVehiculoExternoService _procesamientoVehiculoExternoService;

        public GetByIDProcessVehiExtQueryHandler(IProcesamientoVehiculoExternoService procesamientoVehiculoExternoService)
        {
            _procesamientoVehiculoExternoService = procesamientoVehiculoExternoService;
        }
        public Task<ProcesamientoVehiculoExterno> Handle(GetByIDProcessVehiExtQuery request, CancellationToken cancellationToken)
        {
            var resutl = _procesamientoVehiculoExternoService.GetById(request.ID);
            return Task.FromResult(resutl); 
        }
    }
}
