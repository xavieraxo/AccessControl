using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.PersonalModule.Data;


namespace AccessControlWebRazor.Modules.PersonalModule.Service
{
    public class PersonalService : IPersonalService
    {
        private readonly IPersonalRepository _personalRepository;

        public PersonalService(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }
        public Personal CreatePersonal(Personal personal)
        {
            return _personalRepository.Insert(personal);
        }

        public void DeletePersonal(int ID)
        {
            _personalRepository.Delete(ID);
        }

        public List<Personal> GetAllPersonla()
        {
            return _personalRepository.GetAll().ToList();
        }

        public Personal GetPersonalByDni(int dni)
        {
            var personal = _personalRepository.GetAsync(x => x.NroDocumento == dni).Result.FirstOrDefault();
            return personal;
        }

        public List<Personal> GetPersonalByFilter(string filter)
        {
            var cadena = filter.ToUpper().Trim();
            var personal =  _personalRepository.GetAsync(x=> x.Apellido.ToUpper().Trim().Contains(cadena) 
                                                        || x.Nombre.ToUpper().Trim().Contains(cadena)
                                                        || x.Localidad.ToUpper().Trim().Contains(cadena)
                                                        || x.NroDocumento.ToString().ToUpper().Trim().Contains(cadena)
                                                        || x.NroLegajo.ToString().ToUpper().Trim().Contains(cadena)).Result;
            return personal.ToList();            
        }

        public Personal GetPersonalByID(int id)
        {
            return _personalRepository.GetById(id);
        }

        public Personal UpdatePersonal(Personal personal)
        {
            return _personalRepository.Update(personal);
        }
    }
}
