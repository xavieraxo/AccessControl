using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Queries
{
    public class GetPersonalByFilterQuery : IRequest<List<Personal>>
    {
        public string Filter { get; set; }

        public GetPersonalByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
}
