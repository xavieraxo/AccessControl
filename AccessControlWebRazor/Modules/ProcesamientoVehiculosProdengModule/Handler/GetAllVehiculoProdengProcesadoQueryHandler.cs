using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Handler
{
    public class GetAllVehiculoProdengProcesadoQueryHandler : IRequestHandler<GetAllVehiculoProdengProcesadoQuery, List<ProcesamientoVehiculoProdeng>>
    {
        private readonly IProcessVehiculoProdengService _service;
        public GetAllVehiculoProdengProcesadoQueryHandler(IProcessVehiculoProdengService service)
        {
            _service = service;
        }
        public Task<List<ProcesamientoVehiculoProdeng>> Handle(GetAllVehiculoProdengProcesadoQuery request, CancellationToken cancellationToken)
        {
            var result = _service.GetAllVehiculoProdengProcesado();
            return Task.FromResult(result); 
        }
    }
}
