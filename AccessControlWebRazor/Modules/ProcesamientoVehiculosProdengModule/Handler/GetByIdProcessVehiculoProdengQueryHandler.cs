using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Handler
{
    public class GetByIdProcessVehiculoProdengQueryHandler : IRequestHandler<GetByIdProcessVehiculoProdengQuery, ProcesamientoVehiculoProdeng>
    {
        private readonly IProcessVehiculoProdengService _service;

        public GetByIdProcessVehiculoProdengQueryHandler(IProcessVehiculoProdengService service)
        {
            _service = service;
        }

        public Task<ProcesamientoVehiculoProdeng> Handle(GetByIdProcessVehiculoProdengQuery request, CancellationToken cancellationToken)
        {
            var resutl = _service.GetById(request.ID);
            return Task.FromResult(resutl);
        }
    }
}
