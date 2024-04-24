namespace AccessControlWebRazor.DTO_s.VehiculosUnificados
{
    public class AddVehicleRequest
    {
        public string plateNo { get; set; }
        public string vehicleGroupIndexCode { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime expiredDate { get; set; }
    }
}
