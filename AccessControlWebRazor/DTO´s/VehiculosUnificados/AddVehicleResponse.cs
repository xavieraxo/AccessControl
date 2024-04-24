namespace AccessControlWebRazor.DTO_s.VehiculosUnificados
{
    public class AddVehicleResponse
    {
        public string plateNo { get; set; }
        public string personId { get; set; }
        public string phoneNo { get; set; }
        public int vehicleColor { get; set; }
        public string vehicleGroupIndexCode { get; set; }
        public string personGivenName { get; set; }
        public string personFamilyName { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime expiredDate { get; set; }
    }
}
