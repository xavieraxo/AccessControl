using AccessControlWebRazor.Models;

namespace AccessControlWebRazor.Modules.PersonalModule.Service
{
    public interface IPersonalService
    {
        Personal CreatePersonal(Personal personal);
        Personal UpdatePersonal(Personal personal);
        void DeletePersonal(int ID);
        Personal GetPersonalByID(int id);
        Personal GetPersonalByDni(int dni);
        List<Personal> GetAllPersonla();
        List<Personal> GetPersonalByFilter(string filter);
    }
}
