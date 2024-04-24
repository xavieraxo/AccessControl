using AccessControlWebRazor.DTO_s.VehiculosUnificados;
using System.Net;

namespace AccessControlWebRazor.Integrations
{
    public interface IHttpManager
    {
        Task<(HttpStatusCode statusCode, TOutput output)> GetAsync<TOutput>(string url, string? token);

        Task<(HttpStatusCode statusCode, TOutput output)> PostAsync<TInput, TOutput>(string url, TInput body, string? token);

        Task<(HttpStatusCode statusCode, TOutput output)> PutAsync<TInput, TOutput>(string url, TInput body, string? token);

        Task<bool> PostAsyncHikCentralVehicleAdd<TInput, TOutput>(string url, AddVehicleRequest request);

        Task<(HttpStatusCode statusCode, TOutput output)> PostAsyncHikCentralVehicleUpdate<TInput, TOutput>(string url, TInput body);

        Task<TOutput> PostAsyncHikCentralVehicleList<TInput, TOutput>(string url, TInput body);
    }
}
