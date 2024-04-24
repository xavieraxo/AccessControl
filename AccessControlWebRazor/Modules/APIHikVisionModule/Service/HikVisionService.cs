using AccessControlWebRazor.DTO_s.VehiculosUnificados;
using AccessControlWebRazor.Integrations;
using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Queries;
using AccessControlWebRazor.Modules.ProdengVehiculosModule.Queries;
using MediatR;

namespace AccessControlWebRazor.Modules.ApiHikVisionModule.Service;

public class HikVisionService : IHikVisionService
{
    private readonly IMediator _mediator;
    private readonly IHttpManager _httpManager;
    const string urlGetListVehicle = "https://localhost/artemis/api/resource/v1/vehicle/vehicleList";
    const string urlAddVehicle = "https://localhost/artemis/api/resource/v1/vehicle/single/add";

    public HikVisionService(IMediator mediator, IHttpManager httpManager)
    {

        _httpManager = httpManager;
        _mediator = mediator;
    }

    public async Task SendWhiteListToHikVisionCamera(List<VehiculoProdeng> vehiculosProdeng, List<Vehiculo> vehiculosExternos)
    {

        try
        {
            var request = new PostListVehicleRequest()
            {
                pageSize = 500,
                pageNo = 1,
                vehicleGroupIndexCode = "1"
            };
            var listaVehiculosCamera = await _httpManager.PostAsyncHikCentralVehicleList<PostListVehicleRequest, ResponseGetListVehicleAPI>(urlGetListVehicle, request);
            var listaProdeng = vehiculosProdeng;

            var listaExterno = vehiculosExternos;


            foreach (var item in listaProdeng)
            {
                if (!listaVehiculosCamera.data.list.Any(x => x.plateNo.Trim().ToUpper() == item.Dominio.Trim().ToUpper()))
                {
                    var newVehicle = new AddVehicleRequest()
                    {
                        effectiveDate = DateTime.Now,
                        expiredDate = DateTime.Now.AddDays(365),
                        plateNo = item.Dominio,
                        vehicleGroupIndexCode = "1"
                    };

                    var addVehicle = await _httpManager.PostAsyncHikCentralVehicleAdd<AddVehicleRequest, AddVehicleResponse>(urlAddVehicle, newVehicle);
                }
            }

            foreach (var item in listaExterno)
            {
                if (!listaVehiculosCamera.data.list.Any(x => x.plateNo.Trim().ToUpper() == item.Dominio.Trim().ToUpper()))
                {
                    var newVehicle = new AddVehicleRequest()
                    {
                        effectiveDate = DateTime.Now,
                        expiredDate = DateTime.Now.AddDays(365),
                        plateNo = item.Dominio,
                        vehicleGroupIndexCode = "1"
                    };

                    var addVehicle = await _httpManager.PostAsyncHikCentralVehicleAdd<AddVehicleRequest, AddVehicleResponse>(urlAddVehicle, newVehicle);
                }
            }
        }
        catch (Exception e)
        {

            throw e;
        }


    }
}
