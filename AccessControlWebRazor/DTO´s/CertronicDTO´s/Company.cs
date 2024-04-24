using System.Text.Json.Serialization;

namespace AccessControlWebRazor.DTO_s.CertronicDTO_s
{
    public class Company
    {
        [JsonPropertyName("cuit")]
        public string Cuit { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
