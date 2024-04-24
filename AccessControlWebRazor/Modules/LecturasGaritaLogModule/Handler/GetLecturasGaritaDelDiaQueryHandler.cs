using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Handler
{
    public class GetLecturasGaritaDelDiaQueryHandler : IRequestHandler<GetLecturasGaritaDelDiaQuery, List<LecturasGaritaLog>>
    {
        private readonly ILecturaGaritaLogService _logService;

        public GetLecturasGaritaDelDiaQueryHandler(ILecturaGaritaLogService lecturaGaritaLogService)
        {
            _logService = lecturaGaritaLogService;
        }
        public Task<List<LecturasGaritaLog>> Handle(GetLecturasGaritaDelDiaQuery request, CancellationToken cancellationToken)
        {
            var result = _logService.GetLecturaGaritaDelDia();
            return Task.FromResult(result);
        }
    }
}
