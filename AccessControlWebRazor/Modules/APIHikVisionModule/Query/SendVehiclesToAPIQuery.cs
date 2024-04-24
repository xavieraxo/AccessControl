using AccessControlWebRazor.Models;
using MediatR;

namespace AccessControlWebRazor.Modules.ApiHikVisionModule.Query;

public class SendVehiclesToAPIQuery : IRequest<bool>
{
    public  List<VehiculoProdeng> VehiculosProdeng { get; set; }
    public List<Vehiculo> VehiculosExternos { get; set; }

    public SendVehiclesToAPIQuery(List<VehiculoProdeng> vehiculosProden, List<Vehiculo>  vehiculosExternos)
    {
        VehiculosProdeng = vehiculosProden;
        VehiculosExternos = vehiculosExternos;
    }
}