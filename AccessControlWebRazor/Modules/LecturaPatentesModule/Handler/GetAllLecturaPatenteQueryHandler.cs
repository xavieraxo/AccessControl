using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturaPatentesModule.Data;
using AccessControlWebRazor.Modules.LecturaPatentesModule.Queries;
using AccessControlWebRazor.Modules.LecturaPatentesModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturaPatentesModule.Handler
{
    public class GetAllLecturaPatenteQueryHandler : IRequestHandler<GetAllLecturaPatenteQuery, List<LecturaPatente>>
    {
        public readonly ILecturaPatenteService _lecturaPatenteService;
        public GetAllLecturaPatenteQueryHandler(ILecturaPatenteService lecturaPatenteService)
        {
            _lecturaPatenteService = lecturaPatenteService;
        }
        public async Task<List<LecturaPatente>> Handle(GetAllLecturaPatenteQuery request, CancellationToken cancellationToken)
        {
            var lecturas = _lecturaPatenteService.GetAll();
            return lecturas;
        }
    }
}
