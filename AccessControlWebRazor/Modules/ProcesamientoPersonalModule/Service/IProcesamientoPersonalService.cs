using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ProcesamientoPersonalModule.Service
{
    public interface IProcesamientoPersonalService
    {
        Procesamiento GetProcesamientoByID(int ID);
        List<Procesamiento> GetAllProcesamiento();
        List<Procesamiento> GetProcemientoByCentroCosto(int centroCosto);
        List<Procesamiento> GetAllProcesamientoDistincZero();
        Procesamiento UpdateProcesamiento(Procesamiento procesamiento);
        byte[] ExportToExcel(List<Procesamiento> procesamientos);
        List<Procesamiento> GetAllByCentroCosto(int centroCosto);
        List<Procesamiento> GetAllByCentroCostoNoCZero();
    }
}
