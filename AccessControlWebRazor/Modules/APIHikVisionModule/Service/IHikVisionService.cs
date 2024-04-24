using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ApiHikVisionModule.Service;

public interface IHikVisionService
{
    Task SendWhiteListToHikVisionCamera(List<VehiculoProdeng> vehiculosProdeng, List<Vehiculo> vehiculosExternos);
}