using System.Text.Json.Serialization;

namespace AccessControlWebRazor.DTO_s.CertronicDTO_s
{
    public class Access
    {
        [JsonPropertyName("extCode")]
        public string ExtCode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("hasAccess")]
        public bool HasAccess { get; set; }
    }
}
