using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.ProcessExternalModule.Queries;
using AccessControlWebRazor.Modules.ProcessExternalModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Handler
{
    public class GetAllProcessExternalQueryHandler : IRequestHandler<GetAllProcessExternalQuery, List<ProcesamientoPersonalExterno>>
    {
        private readonly IProcesamientoPersonalExternoService _procesamientoService;

        public GetAllProcessExternalQueryHandler(IProcesamientoPersonalExternoService procesamientoService)
        {
            _procesamientoService = procesamientoService;
        }

        public Task<List<ProcesamientoPersonalExterno>> Handle(GetAllProcessExternalQuery request, CancellationToken cancellationToken)
        {
            var result = _procesamientoService.GetAll();
            return Task.FromResult(result);
        }

    }
}
