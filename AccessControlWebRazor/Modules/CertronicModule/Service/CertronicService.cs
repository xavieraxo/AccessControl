using AccessControlWebRazor.DTO_s.CertronicDTO_s;
using AccessControlWebRazor.Integrations;
using AccessControlWebRazor.Models;
using AccessControlWebRazor.Modules.CertronicModule.Data;
using AccessControlWebRazor.Modules.VehiculosModule.Data;

namespace AccessControlWebRazor.Modules.CertronicModule.Service
{
    public class CertronicService : ICertronicService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly IMaquinariaRepository _maquinariaRepository;
        private readonly IPersonalExtrenoRepository _personalExtrenoRepository;
        private readonly IHttpManager _httpManager;
        private const string UrlPersonal = "https://certronic.io/WebServices/prodeng/personal.php";
        private const string UrlVehículos = "https://certronic.io/WebServices/prodeng/vehiculos.php";
        private const string UrlMaquinarias = "https://certronic.io/WebServices/prodeng/maquinarias.php";

        private const string apiKey = "uy7ALSSGlA88KIhUG9AhKrD1IN32QPId";

        public CertronicService(IVehiculoRepository vehiculoRepository, IMaquinariaRepository maquinariaRepository, IPersonalExtrenoRepository personalExtrenoRepository, IHttpManager httpManager)
        {
            _httpManager = httpManager;
            _vehiculoRepository = vehiculoRepository;
            _maquinariaRepository = maquinariaRepository;
            _personalExtrenoRepository = personalExtrenoRepository;
        }

        public bool ValidateMaquinaria(MaquinariaDTO maquinaria)
        {
            return _maquinariaRepository.GetAll().ToList().Any(x => x.Number == maquinaria.Number);
        }

        public bool ValidatePersonal(PersonalExternoDTO persona)
        {
            return _personalExtrenoRepository.GetAll().ToList().Any(x => x.Dni == persona.Dni);
        }

        public bool ValidateVehiculo(Vehiculo vehiculo)
        {
            return _vehiculoRepository.GetAll().ToList().Any(x => x.Dominio == vehiculo.Dominio);
        }

        public bool Sincronizacion()
        {
            var resultMaquinariaAPI = _httpManager.GetAsync<RootObjectMaquinaria>(UrlMaquinarias, apiKey).Result.output;
            var resultPersonalAPI = _httpManager.GetAsync<RootObjectPersonalExterno>(UrlPersonal, apiKey).Result.output;
            var resultVehiculosAPI = _httpManager.GetAsync<RootObjectVehiculo>(UrlVehículos, apiKey).Result.output;

            var resultMaquinaria = _maquinariaRepository.GetAll().ToList();
            var resultPersonal = _personalExtrenoRepository.GetAll().ToList();
            var resultVehiculos = _vehiculoRepository.GetAll().ToList();

            foreach (var item in resultMaquinariaAPI.Maquinarias)
            {
                if (!resultMaquinaria.Any(x => x.Number == item.Number))
                {
                    var nuevaMaquinaria = new Maquinaria()
                    {
                        
                        Number = item.Number,
                        Description = item.Description,
                        Brand = item.Brand,
                        IsActive = 1
                    };
                    _maquinariaRepository.Insert(nuevaMaquinaria);
                }
            }

            foreach (var item in resultPersonalAPI.Personal)
            {
                if (!resultPersonal.Any(x => x.Dni == item.Dni))
                {
                    var nuevaPersonal = new PersonalExterno()
                    {
                        Dni = item.Dni,
                        Cuil = item.Cuil,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        IsActive = 1,
                    };
                    _personalExtrenoRepository.Insert(nuevaPersonal);
                }
            }

            foreach (var item in resultVehiculosAPI.Vehiculos)
            {
                if (!resultVehiculos.Any(x => x.Dominio == item.Dominio))
                {
                    var nuevaVehiculo = new Vehiculo()
                    {
                        Dominio = item.Dominio,
                        Model = item.Model,
                        Brand = item.Brand,
                        IsActive = Convert.ToInt32(item.IsActive),
                    };
                    _vehiculoRepository.Insert(nuevaVehiculo);
                }
            }
            return true;
        }

        public Maquinaria CreateMaquinaria(MaquinariaDTO maquinaria)
        {
            var maquinaInsert = new Maquinaria()
            {
                IsActive = Convert.ToInt32(maquinaria.IsActive),
                Brand = maquinaria.Brand,
                Description = maquinaria.Description,
                Number = maquinaria.Number
            };
            return _maquinariaRepository.Insert(maquinaInsert);
        }

        public PersonalExterno CreatePersonalExterno(PersonalExternoDTO personal)
        {
            var newPersonal = new PersonalExterno()
            {
                FirstName = personal.FirstName,
                Cuil = personal.Cuil,
                Dni = personal.Dni,
                IsActive = Convert.ToInt32(personal.IsActive),
                LastName = personal.LastName
            };
            return _personalExtrenoRepository.Insert(newPersonal);
        }

        public Vehiculo CreateVehiculo(VehiculoDTO vehiculo)
        {
            var newVehiculo = new Vehiculo()
            {
                Dominio = vehiculo.Dominio,
                Brand = vehiculo.Brand,
                IsActive = Convert.ToInt32(vehiculo.IsActive),
                Model = vehiculo.Model
            };
            return _vehiculoRepository.Insert(newVehiculo);
        }

        public PersonalExterno GetPersonalExternoById(int ID)
        {
          return _personalExtrenoRepository.GetById(ID);
        }

        public PersonalExterno GetPersonalExternoByDNI(string DNI)
        {
            var person = _personalExtrenoRepository.GetAsync(x => x.Dni == DNI).Result.FirstOrDefault();
            return person;
        }

        public Vehiculo GetVehiculoByDominio(string dominio)
        {
            return _vehiculoRepository.GetAsync(x => x.Dominio == dominio).Result.FirstOrDefault();
        }

        public Maquinaria GetMaquinariaByNumeration(string number)
        {
            return _maquinariaRepository.GetAsync(x => x.Number == number).Result.FirstOrDefault();
        }

        public List<PersonalExterno> GetAllPersonalExterno()
        {
            return _personalExtrenoRepository.GetAll().ToList();
        }

        public List<Vehiculo> GetAllVehiculoExterno()
        {
            return _vehiculoRepository.GetAll().ToList();
        }
    }
}
