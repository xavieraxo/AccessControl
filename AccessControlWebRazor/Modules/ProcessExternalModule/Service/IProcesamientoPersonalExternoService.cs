using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.ProcessExternalModule.Service
{
    public interface IProcesamientoPersonalExternoService
    {
        ProcesamientoPersonalExterno InsertProcess(ProcesamientoPersonalExterno procesamiento);
        ProcesamientoPersonalExterno UpdateProcess(ProcesamientoPersonalExterno procesamiento);
        ProcesamientoPersonalExterno GetProcesamientoByPersonalId(int PersonalExternoID);
        ProcesamientoPersonalExterno GetProcesamientoExternoById(int iD);
        List<ProcesamientoPersonalExterno> GetAll();
        List<ProcesamientoPersonalExterno> GetByFilter(string flter, bool cCosto);
        List<ProcesamientoPersonalExterno> GetByDate(DateTime desde, DateTime hasta);
        byte[] ExportToExcel(List<ProcesamientoPersonalExterno> procesamientos);
        List<ProcesamientoPersonalExterno> GetAllByCentroCosto(int centroCosto);
        List<ProcesamientoPersonalExterno> GetAllProcessPersExtByCentroCostoDisctinctZero();

    }
}
