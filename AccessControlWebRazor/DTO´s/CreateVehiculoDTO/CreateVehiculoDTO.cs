using AccessControlWebRazor.DTO_s.CertronicDTO_s;

namespace AccessControlWebRazor.DTO_s.CreateVehiculoDTO
{
    public class CreateVehiculoDTO
    {
        public VehiculoDTO vehiculo;
        public Models.LecturaPatente lecturasGaritaLog;

        public CreateVehiculoDTO()
        {
            vehiculo = new VehiculoDTO();
            lecturasGaritaLog = new Models.LecturaPatente();
        }
    }
}
