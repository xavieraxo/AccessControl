using System.Text.Json.Serialization;

namespace AccessControlWebRazor.DTO_s.CertronicDTO_s
{
    public class MaquinariaDTO
    {
        
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("company")]
        public Company Company { get; set; }

        [JsonPropertyName("access")]
        public List<Access> Access { get; set; }
    }
}
