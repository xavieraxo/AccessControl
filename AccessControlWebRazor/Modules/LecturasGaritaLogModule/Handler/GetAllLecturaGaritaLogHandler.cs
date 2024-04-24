using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Handler
{
    public class GetAllLecturaGaritaLogHandler : IRequestHandler<GetAllLecturaGaritaLogQuery, List<LecturasGaritaLog>>
    {

        private readonly ILecturaGaritaLogService _LecturaGaritaLogService;
        public GetAllLecturaGaritaLogHandler(ILecturaGaritaLogService lecturaGaritaLogService)
        {
            _LecturaGaritaLogService = lecturaGaritaLogService;
        }

        public async Task<List<LecturasGaritaLog>> Handle(GetAllLecturaGaritaLogQuery request, CancellationToken cancellationToken)
        {
            var lecturas =  _LecturaGaritaLogService.GetAll();
            return lecturas;
        }
    }
}
