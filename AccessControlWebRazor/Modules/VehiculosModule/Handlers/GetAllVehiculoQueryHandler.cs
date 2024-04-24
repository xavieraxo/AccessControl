using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.VehiculosModule.Queries;
using AccessControlWebRazor.Modules.VehiculosModule.Service;
using MediatR;

namespace AccessControlWebRazor.Modules.VehiculosModule.Handlers
{
    public class GetAllVehiculoQueryHandler : IRequestHandler<GetAllVehiculoQuery, List<Vehiculo>>
    {
        private readonly IVehiculoService _service;

        public GetAllVehiculoQueryHandler(IVehiculoService vehiculoService)
        {
            _service = vehiculoService;
        }
        public Task<List<Vehiculo>> Handle(GetAllVehiculoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _service.GetAll();
                return Task.FromResult(result);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
