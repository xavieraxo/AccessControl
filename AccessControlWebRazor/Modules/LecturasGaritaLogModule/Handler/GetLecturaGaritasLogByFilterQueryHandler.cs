using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Service;
using MediatR;


namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Handler
{
    public class GetLecturaGaritasLogByFilterQueryHandler : IRequestHandler<GetLecturaGaritasLogByFilterQuery, List<LecturasGaritaLog>>
    {
        private readonly ILecturaGaritaLogService _lecturaGaritaLogService;

        public GetLecturaGaritasLogByFilterQueryHandler(ILecturaGaritaLogService lecturaGaritaLogService)
        {
            _lecturaGaritaLogService = lecturaGaritaLogService;
        }
        public Task<List<LecturasGaritaLog>> Handle(GetLecturaGaritasLogByFilterQuery request, CancellationToken cancellationToken)
        {
            var cadena = string.Empty;
            if (!string.IsNullOrWhiteSpace(request.Filter) && request.Desde == null && request.Hasta == null)
            {
                cadena = request.Filter.ToUpper().Trim();
                var result = _lecturaGaritaLogService.GetByFilter(cadena);
                
                return Task.FromResult(result);
            }
            else
            {
                return Task.FromResult(_lecturaGaritaLogService.GetAll());
            }
        }
    }
}
