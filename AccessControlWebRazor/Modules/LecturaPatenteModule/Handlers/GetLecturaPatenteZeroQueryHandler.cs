using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Queries;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Services;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Handlers
{
    public class GetLecturaPatenteZeroQueryHandler : IRequestHandler<GetLecturaPatenteZeroQuery, List<LecturaPatente>>
    {
        private readonly ILecturaPatenteService _lecturaPatenteService;

        public GetLecturaPatenteZeroQueryHandler(ILecturaPatenteService lecturaPatenteService)
        {
            _lecturaPatenteService = lecturaPatenteService;
        }
        public Task<List<LecturaPatente>> Handle(GetLecturaPatenteZeroQuery request, CancellationToken cancellationToken)
        {
            var result = _lecturaPatenteService.GetLecturaPatenteZero();
            return Task.FromResult(result);
        }
    }
}
