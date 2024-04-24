using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.CentroCostoModule.Service
{
    public interface ICentroCostoService
    {
        List<CentroCosto> GetAll();
        CentroCosto GetById(int ID);
        List<CentroCosto> GetByFilter(string filter);
    }
}
