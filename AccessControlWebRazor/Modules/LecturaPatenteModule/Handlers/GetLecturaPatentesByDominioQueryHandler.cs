using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Queries;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Services;
using MediatR;
using NuGet.Protocol.Plugins;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Handlers
{
    public class GetLecturaPatentesByDominioQueryHandler : IRequestHandler<GetLecturaPatentesByDominioQuery, List<LecturaPatente>>
    {
        private readonly ILecturaPatenteService _lecturaPatenteService;

        public GetLecturaPatentesByDominioQueryHandler(ILecturaPatenteService lecturaPatenteService)
        {
            _lecturaPatenteService = lecturaPatenteService;
        }
        public Task<List<LecturaPatente>> Handle(GetLecturaPatentesByDominioQuery request, CancellationToken cancellationToken)
        {
            var result = _lecturaPatenteService.GetLecturaPatentesByDominio(request.Dominio);
            return Task.FromResult(result);
        }
    }
}
