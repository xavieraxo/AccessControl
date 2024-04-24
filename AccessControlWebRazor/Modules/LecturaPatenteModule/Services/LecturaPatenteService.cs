using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturaPatenteModule.Data;

namespace AccessControlWebRazor.Modules.LecturaPatenteModule.Services
{
    public class LecturaPatenteService : ILecturaPatenteService
    {
        private readonly ILecturaPatenteRepository _repository;

        public LecturaPatenteService(ILecturaPatenteRepository lecturaPatente)
        {
            _repository = lecturaPatente;
        }
        public List<LecturaPatente> GetAllLecturaFecha(DateTime fecha)
        {
            return _repository.GetAsync(x=> x.FechaLectura_datetime.Date == fecha.Date).Result.ToList();
        }

        public List<LecturaPatente> GetAllLecturaPatente()
        {
            return _repository.GetAll().ToList();
        }

        public List<LecturaPatente> GetLecturaDelDia()
        {
            return _repository.GetAsync(x => x.FechaLectura_datetime.Date == DateTime.Now.Date).Result.ToList();
        }

        public List<LecturaPatente> GetLecturaPatenteByDominioAndFecha(string dominio, DateTime fecha)
        {
            return _repository.GetAsync(x => x.FechaLectura_datetime.Date == fecha.Date && x.Patente.Contains(dominio)).Result.ToList();
        }

        public List<LecturaPatente> GetLecturaPatenteByDominioAndFechaYFecha(string dominio, DateTime desde, DateTime hasta)
        {
            return _repository.GetAsync(x => x.FechaLectura_datetime.Date >= desde.Date && x.FechaLectura_datetime.Date <= hasta.Date && x.Patente.Contains(dominio)).Result.ToList();
        }

        public LecturaPatente GetLecturaPatenteById(int id)
        {
            return _repository.GetById(id);
        }

        public List<LecturaPatente> GetLecturaPatenteDesdeHasta(DateTime desde, DateTime hasta)
        {
            return _repository.GetAsync(x => x.FechaLectura_datetime.Date >= desde.Date && x.FechaLectura_datetime.Date <= hasta.Date).Result.ToList();
        }

        public List<LecturaPatente> GetLecturaPatentesByDominio(string dominio)
        {
            return _repository.GetAsync(x=> x.Patente.Trim().ToUpper().Contains(dominio.Trim().ToUpper())).Result.ToList();
        }

        public List<LecturaPatente> GetLecturaPatenteZero()
        {
            return _repository.GetAsync(x=> x.Procesado == 0).Result.ToList();
        }

        public List<LecturaPatente> GetLecturasPatenteByPDominio(string dominio)
        {
            return _repository.GetAsync(x => x.Patente.Contains(dominio)).Result.ToList();
        }
    }
}
