using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Handler
{
    public class GetAllProcesamientoVehiExtQueryHandler : IRequestHandler<GetAllProcesamientoVehiExtQuery, List<ProcesamientoVehiculoExterno>>
    {
        private readonly IProcesamientoVehiculoExternoService _procesamientoVehiculoExternoService;

        public GetAllProcesamientoVehiExtQueryHandler(IProcesamientoVehiculoExternoService procesamiento)
        {
            _procesamientoVehiculoExternoService = procesamiento;
        }

        public Task<List<ProcesamientoVehiculoExterno>> Handle(GetAllProcesamientoVehiExtQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoVehiculoExternoService.GetAll();
            return Task.FromResult(result);
        }
    }
}
