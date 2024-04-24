using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Queries
{
    public class GetPersonalExternoByFilterQuery : IRequest<List<PersonalExterno>>
    {
        public string Filter { get; set; }
        public GetPersonalExternoByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }
}
