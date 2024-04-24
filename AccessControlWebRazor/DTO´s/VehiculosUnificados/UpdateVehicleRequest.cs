namespace AccessControlWebRazor.DTO_s.VehiculosUnificados
{
    public class UpdateVehicleRequest
    {
        public string vehicleId { get; set; }
        public string vehicleGroupIndexcode { get; set; }
        public string plateNo { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime expiredDate { get; set; }
    }
}
