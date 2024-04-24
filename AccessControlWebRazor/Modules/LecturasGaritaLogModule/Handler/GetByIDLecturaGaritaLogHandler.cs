using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Handler
{
    public class GetByIDLecturaGaritaLogHandler : IRequestHandler<GetByIDLecturaGaritaLogQuery, LecturasGaritaLog>
    {
        private readonly ILecturaGaritaLogService _service;

        public GetByIDLecturaGaritaLogHandler(ILecturaGaritaLogService service)
        {
            _service = service;
        }

        public async Task<LecturasGaritaLog> Handle(GetByIDLecturaGaritaLogQuery request, CancellationToken cancellationToken)
        {
            var lectura = _service.GetbyID(request.ID);
            return lectura;
        }
    }
}
