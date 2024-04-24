using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class GetPersonalExternoByFilterQueryHandler : IRequestHandler<GetPersonalExternoByFilterQuery, List<PersonalExterno>>
    {
        private readonly ICertronicService _certronicService;
        public GetPersonalExternoByFilterQueryHandler(ICertronicService certronicService)
        {
            _certronicService = certronicService;
        }
        public Task<List<PersonalExterno>> Handle(GetPersonalExternoByFilterQuery request, CancellationToken cancellationToken)
        {
            var cadena = request.Filter.ToUpper().Trim();
            var result = _certronicService.GetAllPersonalExterno();
            var listDepurada = result.Where(x => x.Dni == cadena || x.Cuil == cadena || x.LastName.ToUpper().Trim() == cadena || x.FirstName.ToUpper().Trim() == cadena).ToList();
            return Task.FromResult(listDepurada);
        }
    }
}
