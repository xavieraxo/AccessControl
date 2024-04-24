using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Service;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Handler
{
    public class GetAllGaritaZeroQueryHandler : IRequestHandler<GetAllGaritaZeroQuery, List<LecturasGaritaLog>>
    {
        private readonly ILecturaGaritaLogService _logService;

        public GetAllGaritaZeroQueryHandler(ILecturaGaritaLogService lecturaGaritaLogService)
        {
            _logService = lecturaGaritaLogService;
        }
        public Task<List<LecturasGaritaLog>> Handle(GetAllGaritaZeroQuery request, CancellationToken cancellationToken)
        {
            var result = _logService.GetAllGaritaZero();
            return Task.FromResult(result);
        }
    }
}
