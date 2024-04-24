using System.Text.Json.Serialization;

namespace AccessControlWebRazor.DTO_s.CertronicDTO_s
{
    public class RootObjectVehiculo
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("vehicles")]
        public List<VehiculoDTO> Vehiculos { get; set; }
    }
}
