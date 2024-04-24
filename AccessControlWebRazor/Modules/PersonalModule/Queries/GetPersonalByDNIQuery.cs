using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.PersonalModule.Queries
{
    public class GetPersonalByDNIQuery : IRequest<Personal>
    {
        public int DNI { get; set; }

        public GetPersonalByDNIQuery(int dni)
        {
            DNI = dni;
        }
    }
}
