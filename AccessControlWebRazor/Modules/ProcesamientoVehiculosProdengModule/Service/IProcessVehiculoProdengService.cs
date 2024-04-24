using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ProcesamientoVehiculosProdengModule.Service
{
    public interface IProcessVehiculoProdengService
    {
        ProcesamientoVehiculoProdeng InsertProcess(ProcesamientoVehiculoProdeng procesamiento);
        ProcesamientoVehiculoProdeng UpdateProcess(ProcesamientoVehiculoProdeng procesamiento);
        ProcesamientoVehiculoProdeng GetProcesamientoByVehiculoProdengId(int VehiculoProdengID);
        List<ProcesamientoVehiculoProdeng> GetAllVehiculoProdengProcesado();
        List<ProcesamientoVehiculoProdeng> GetAllByCentroCosto(int centroCosto);
        List<ProcesamientoVehiculoProdeng> GetAllByCentroCostoNoCZero();
        byte[] ExportToExcel(List<ProcesamientoVehiculoProdeng> procesamientos);
        ProcesamientoVehiculoProdeng GetById(int id);
    }
}
