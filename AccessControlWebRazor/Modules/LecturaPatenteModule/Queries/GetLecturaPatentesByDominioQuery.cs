using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Queries
{
    public class GetLecturaPatentesByDominioQuery : IRequest<List<LecturaPatente>>
    {
        public string Dominio { get; set; }

        public GetLecturaPatentesByDominioQuery(string dominio)
        {
            Dominio = dominio;
        }
    }
}
