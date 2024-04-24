using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Services
{
    public interface ILecturaPatenteService
    {
        List<LecturaPatente> GetAllLecturaPatente();
        List<LecturaPatente> GetLecturasPatenteByPDominio(string dominio);
        List<LecturaPatente> GetAllLecturaFecha(DateTime fecha);
        LecturaPatente GetLecturaPatenteById(int id);
        List<LecturaPatente> GetLecturaPatenteByDominioAndFecha(string dominio, DateTime fecha);
        List<LecturaPatente> GetLecturaPatenteByDominioAndFechaYFecha(string dominio, DateTime desde, DateTime hasta);
        List<LecturaPatente> GetLecturaPatenteDesdeHasta(DateTime desde, DateTime hasta);
        List<LecturaPatente> GetLecturaPatenteZero();
        List<LecturaPatente> GetLecturaDelDia();
        List<LecturaPatente> GetLecturaPatentesByDominio(string dominio);

    }
}
