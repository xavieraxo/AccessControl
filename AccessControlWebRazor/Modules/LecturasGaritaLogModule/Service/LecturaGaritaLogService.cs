using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.LecturasGaritaLogModule.Data;

namespace AccessControlWebRazor.Modules.LecturasGaritaLogModule.Service
{
    public class LecturaGaritaLogService : ILecturaGaritaLogService
    {
        private readonly ILecturasGaritaLogRepository _repository;

        public LecturaGaritaLogService(ILecturasGaritaLogRepository repository)
        {
            _repository = repository;
        }

        public List<LecturasGaritaLog> GetAll()
        {
            var result = _repository.GetAll().ToList();
            return result.ToList();
        }

        public List<LecturasGaritaLog> GetAllGaritaZero()
        {
            return _repository.GetAsync(x=> x.Procesado == 0).Result.ToList();
        }

        public List<LecturasGaritaLog> GetByFilter(string filter)
        {
            string cadena = filter.ToUpper().Trim();
            var result = _repository.GetAsync(x=> x.DNI == filter || x.Nombre.ToUpper().Trim().Contains(cadena) || x.Apellido.ToUpper().Trim().Contains(cadena) || x.Genero.ToUpper().Trim().Contains(cadena));
            return result.Result.ToList();
        }

        public LecturasGaritaLog GetbyID(int ID)
        {
            return _repository.GetById(ID);
        }

        public List<LecturasGaritaLog> GetLecturaGaritaDelDia()
        {
            return _repository.GetAsync(x => x.FechaLectura.Value.Date == DateTime.Now.Date).Result.ToList();
        }
    }
}
