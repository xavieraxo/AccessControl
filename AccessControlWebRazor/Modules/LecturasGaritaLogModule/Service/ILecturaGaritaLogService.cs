using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Service
{
    public interface ILecturaGaritaLogService
    {
        List<LecturasGaritaLog> GetAll();
        LecturasGaritaLog GetbyID(int ID);
        List<LecturasGaritaLog> GetByFilter(string filter);
        List<LecturasGaritaLog> GetAllGaritaZero();
        List<LecturasGaritaLog> GetLecturaGaritaDelDia();
    }
}
