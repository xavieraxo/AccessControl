namespace AccessControlWebRazor.DTO_s.CertronicDTO_s
{
    public class VehiculoDTO
    {
        public string Id { get; set; }
        public string Dominio { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsActive { get; set; }
        public Company Company { get; set; }
        public List<Access> Access { get; set; }
    }
}
