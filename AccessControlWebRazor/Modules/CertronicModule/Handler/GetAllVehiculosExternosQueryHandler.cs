using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.CertronicModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.CertronicModule.Handler
{
    public class GetAllVehiculosExternosQueryHandler : IRequestHandler<GetAllVehiculosExternosQuery, List<Vehiculo>>
    {
        private readonly ICertronicService _certronicService;
        public GetAllVehiculosExternosQueryHandler(ICertronicService certronicService)
        {
            _certronicService = certronicService;   
        }
        public Task<List<Vehiculo>> Handle(GetAllVehiculosExternosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _certronicService.GetAllVehiculoExterno();
                return Task.FromResult(result);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
