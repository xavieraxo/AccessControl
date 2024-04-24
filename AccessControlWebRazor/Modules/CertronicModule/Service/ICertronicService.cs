using AccessControlWebRazor.DTO_s.CertronicDTO_s;
using AccessControlWebRazor.Models;


namespace AccessControlWebRazor.Modules.CertronicModule.Service
{
    public interface ICertronicService
    {
        bool Sincronizacion();
        bool ValidatePersonal(PersonalExternoDTO persona);
        bool ValidateMaquinaria(MaquinariaDTO maquinaria);
        bool ValidateVehiculo(Vehiculo persona);
        Maquinaria CreateMaquinaria(MaquinariaDTO maquinaria);
        PersonalExterno CreatePersonalExterno(PersonalExternoDTO personal);
        Vehiculo CreateVehiculo(VehiculoDTO vehiculo);
        PersonalExterno GetPersonalExternoById(int ID);
        List<PersonalExterno> GetAllPersonalExterno();
        PersonalExterno GetPersonalExternoByDNI(string DNI);
        Vehiculo GetVehiculoByDominio(string dominio);
        List<Vehiculo> GetAllVehiculoExterno();
        Maquinaria GetMaquinariaByNumeration(string number);
    }
}
