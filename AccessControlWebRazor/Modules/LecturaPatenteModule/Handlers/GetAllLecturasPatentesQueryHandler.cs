using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Queries;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Services;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Handlers
{
    public class GetAllLecturasPatentesQueryHandler : IRequestHandler<GetAllLecturasPatentesQuery, List<LecturaPatente>>
    {
        private readonly ILecturaPatenteService _lecturaPatenteService;

        public GetAllLecturasPatentesQueryHandler(ILecturaPatenteService lecturaPatente)
        {
            _lecturaPatenteService = lecturaPatente;
        }
        public Task<List<LecturaPatente>> Handle(GetAllLecturasPatentesQuery request, CancellationToken cancellationToken)
        {
            var result = _lecturaPatenteService.GetAllLecturaPatente();
            return Task.FromResult(result);
        }
    }
}
