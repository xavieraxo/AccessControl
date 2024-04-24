using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Queries
{
    public class GetPersonalByIDQuery : IRequest<Personal>
    {
        public int ID { get; set; }

        public GetPersonalByIDQuery(int id)
        {
            ID = id;
        }
    }
}
