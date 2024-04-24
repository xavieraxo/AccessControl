using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Queries;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Services;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Handlers
{
    public class GetLecturasPatenteDelDiaQueryHandler : IRequestHandler<GetLecturasPatenteDelDiaQuery, List<LecturaPatente>>
    {
        private readonly ILecturaPatenteService _lecturaPatenteService;

        public GetLecturasPatenteDelDiaQueryHandler(ILecturaPatenteService lecturaPatenteService)
        {
            _lecturaPatenteService = lecturaPatenteService;
        }
        public Task<List<LecturaPatente>> Handle(GetLecturasPatenteDelDiaQuery request, CancellationToken cancellationToken)
        {
            var result = _lecturaPatenteService.GetLecturaDelDia();
            return Task.FromResult(result);
        }
    }
}
