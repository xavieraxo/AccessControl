using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class GetVehiculosExternosByFilterQueryHandler : IRequestHandler<GetVehiculosExternosByFilterQuery, List<Vehiculo>>
    {
        private readonly ICertronicService _certronicService;
        public GetVehiculosExternosByFilterQueryHandler(ICertronicService certronicService)
        {
            _certronicService = certronicService;
        }
        public Task<List<Vehiculo>> Handle(GetVehiculosExternosByFilterQuery request, CancellationToken cancellationToken)
        {
            var cadena = request.Filter.ToUpper().Trim();
            var result = _certronicService.GetAllVehiculoExterno();
            var listaDepurada = result.Where(x => x.Dominio.ToUpper().Trim().Equals(cadena) || x.Model.ToUpper().Trim().Contains(cadena) || x.Brand.ToUpper().Trim().Contains(cadena)).ToList();
            return Task.FromResult(listaDepurada);
        }
    }
}
