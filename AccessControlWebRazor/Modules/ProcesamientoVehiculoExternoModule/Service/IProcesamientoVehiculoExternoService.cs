using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculoExternoModule.Service
{
    public interface IProcesamientoVehiculoExternoService
    {
        List<ProcesamientoVehiculoExterno> GetAll();
        ProcesamientoVehiculoExterno GetByDominio(string dominio);
        ProcesamientoVehiculoExterno GetById(int id);
        ProcesamientoVehiculoExterno UpdateProcesamiento(ProcesamientoVehiculoExterno procesamientoVehiculoExterno);
        List<ProcesamientoVehiculoExterno> GetAllByCentroCosto(int centroCosto);
        byte[] ExportToExcel(List<ProcesamientoVehiculoExterno> procesamientos);
        List<ProcesamientoVehiculoExterno> GetAllByCentroCostoNoCZero();
        ProcesamientoVehiculoExterno InsertProcess(ProcesamientoVehiculoExterno procesamiento);
        ProcesamientoVehiculoExterno GetByVehicleId(int vehiculoID);

    }
}
