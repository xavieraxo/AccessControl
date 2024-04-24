using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Queries;
using AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Handlers
{
    public class GetAllProcesamientoDistincZeroQueryHandler : IRequestHandler<GetAllProcesamientoDistincZeroQuery, List<Procesamiento>>
    {
        private readonly IProcesamientoPersonalService _procesamientoService;

        public GetAllProcesamientoDistincZeroQueryHandler(IProcesamientoPersonalService procesamientoService)
        {
            _procesamientoService = procesamientoService;   
        }
        public Task<List<Procesamiento>> Handle(GetAllProcesamientoDistincZeroQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoService.GetAllProcesamientoDistincZero();
            return Task.FromResult(result);
        }
    }
}
