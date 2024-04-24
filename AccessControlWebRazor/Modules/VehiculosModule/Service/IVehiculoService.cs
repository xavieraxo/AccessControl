using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.VehiculosModule.Service
{
    public interface IVehiculoService
    {
        void Sincronizacion(List<Vehiculo> vehiculos);
        List<Vehiculo> GetAll();
        Vehiculo GetByDominio(string dominio);
        bool ValidateVehicle(string dominio);
    }
}
