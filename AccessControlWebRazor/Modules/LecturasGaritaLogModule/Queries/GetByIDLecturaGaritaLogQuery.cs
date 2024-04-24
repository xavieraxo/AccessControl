using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Queries
{
    public class GetByIDLecturaGaritaLogQuery : IRequest<LecturasGaritaLog>
    {
        public int ID { get; set; }

        public GetByIDLecturaGaritaLogQuery(int id)
        {
            ID = id;
        }
    }
}
