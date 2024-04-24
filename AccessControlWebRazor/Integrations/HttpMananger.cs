using AccessControlWebRazor.DTO_s.VehiculosUnificados;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AccessControlWebRazor.Integrations
{
    public class HttpManager : IHttpManager
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpManager(IHttpClientFactory client)
        {
            _clientFactory = client;
        }

        public async Task<(HttpStatusCode statusCode, TOutput output)> GetAsync<TOutput>(string url, string? token)
        {
            var http = _clientFactory.CreateClient();
            if (!string.IsNullOrWhiteSpace(token))
            {
                var header = http.DefaultRequestHeaders.TryAddWithoutValidation("apikey", token);
            }
            var result = await http.GetFromJsonAsync<TOutput>(url);
            if (result != null)
            {
                return (HttpStatusCode.OK, result);
            }
            else
            {
                return (HttpStatusCode.BadGateway, result);
            }
        }

        public async Task<(HttpStatusCode statusCode, TOutput output)> PostAsync<TInput, TOutput>(string url, TInput body, string? token)
        {
            var data = this.GenerateContent(body);
            var http = _clientFactory.CreateClient();
            if (!string.IsNullOrWhiteSpace(token))
            {
                var header = http.DefaultRequestHeaders.TryAddWithoutValidation("apikey", token);
            }
            var result = http.PostAsync(url, data);
            return await this.ReturnRequestResult<TOutput>(await result);
        }

        public async Task<(HttpStatusCode statusCode, TOutput output)> PutAsync<TInput, TOutput>(string url, TInput body, string? token)
        {
            var data = this.GenerateContent(body);
            var http = _clientFactory.CreateClient();
            if (!string.IsNullOrWhiteSpace(token))
            {
                var header = http.DefaultRequestHeaders.TryAddWithoutValidation("apikey", token);
            }
            var result = http.PutAsync(url, data);
            return await this.ReturnRequestResult<TOutput>(await result);
        }

        private StringContent GenerateContent<T>(T data)
        {
            var jsonData = System.Text.Json.JsonSerializer.Serialize(data);
            return new StringContent(jsonData, encoding: Encoding.UTF8, mediaType: "application/json");
        }

        private async Task<(HttpStatusCode statusCode, T output)> ReturnRequestResult<T>(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                var s = result.Content.ReadAsStringAsync();
                var deserialized = (result.StatusCode, System.Text.Json.JsonSerializer.Deserialize<T>(s.Result));
                return (result.StatusCode, default);
            }
            return (result.StatusCode, default);
        }

        public async Task<bool> PostAsyncHikCentralVehicleAdd<TInput, TOutput>(string url, AddVehicleRequest request)
        {
            try
            {
                string stringToSign = "POST\n*/*\napplication/json\nx-ca-key:28522529\n/artemis/api/resource/v1/vehicle/add";
                string signature = HikCentralSignature("WyTsY2VnL2zv0ftZP0ZS", stringToSign);

                var handler = new HttpClientHandler() { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
                HttpClient http = new HttpClient(handler);
                // Agregar los encabezados personalizados
                http.DefaultRequestHeaders.Add("x-ca-key", "28522529");
                http.DefaultRequestHeaders.Add("x-ca-signature-headers", "x-ca-key");
                http.DefaultRequestHeaders.Add("x-ca-signature", signature);
                
                HttpRequestMessage requestMessage = new HttpRequestMessage();
                requestMessage.Content = new StringContent("{" +
     "                                       \"pageNo\": 1," +
     "                                       \"pageSize\": 500," +
     "                                       \"vehicleGroupIndexCode\": \"1\"," +
     $"                                       \"plateNo\": \"{request.plateNo}\"," +
     "                                       \"effectiveDate\": \"2024-02-02T00:00:00+08:00\"," +
     "                                       \"expiredDate\": \"2025-02-02T00:00:00+08:00\"" +
     "                                   }",
     Encoding.UTF8, "application/json");
                var response = await http.PostAsync("https://localhost/artemis/api/resource/v1/vehicle/vehicleList", requestMessage.Content);

                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public async Task<(HttpStatusCode statusCode, TOutput output)> PostAsyncHikCentralVehicleUpdate<TInput, TOutput>(string url, TInput body)
        {
            try
            {
                string stringToSign = "POST\n*/*\napplication/json\nx-ca-key:28522529\n/artemis/api/resource/v1/vehicle/update";
                string signature = HikCentralSignature("WyTsY2VnL2zv0ftZP0ZS", stringToSign);

                var handler = new HttpClientHandler() { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
                HttpClient http = new HttpClient(handler);

                // Agregar los encabezados personalizados
                http.DefaultRequestHeaders.Add("x-ca-key", "28522529");
                http.DefaultRequestHeaders.Add("x-ca-signature-headers", "x-ca-key");
                http.DefaultRequestHeaders.Add("x-ca-signature", signature);

                var data = this.GenerateContent(body);
                var response = await http.PostAsync(url, data);

                return await this.ReturnRequestResult<TOutput>(response);

            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error: {ex.Message}");
                return (HttpStatusCode.InternalServerError, default(TOutput));
            }
        }

        public async Task<TOutput> PostAsyncHikCentralVehicleList<TInput, TOutput>(string url, TInput body)
        {

            try
            {
                string stringToSign = "POST\n*/*\napplication/json\nx-ca-key:28522529\n/artemis/api/resource/v1/vehicle/vehicleList";
                string signature = HikCentralSignature("WyTsY2VnL2zv0ftZP0ZS", stringToSign);

                var handler = new HttpClientHandler() { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator };
                HttpClient httpclient = new HttpClient(handler);

                httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
                httpclient.DefaultRequestHeaders.Add("x-ca-key", "28522529");
                httpclient.DefaultRequestHeaders.Add("x-ca-signature-headers", "x-ca-key");
                httpclient.DefaultRequestHeaders.Add("x-ca-signature", signature);

                var data = this.GenerateContent(body);

                HttpRequestMessage requestMessage = new HttpRequestMessage();
                requestMessage.Content = new StringContent("{" +
    "                                       \"pageNo\": 1," +
    "                                       \"pageSize\": 500," +
    "                                       \"vehicleGroupIndexCode\": \"1\"}",
                                            Encoding.UTF8, "application/json");

                requestMessage.Content.Headers.ContentType.CharSet = null;
                var response = await httpclient.PostAsync("https://localhost/artemis/api/resource/v1/vehicle/vehicleList", requestMessage.Content);

                var coso = response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TOutput>(coso.Result);

                return result;


            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error: {ex.Message}");
                return default(TOutput);
            }
        }

        private static readonly Encoding encoding = Encoding.UTF8;
        public static string HikCentralSignature(string secret, string message)
        {
            string result = null;
            var secretByte = encoding.GetBytes(secret);
            using (var hmacsha256 = new HMACSHA256(secretByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(message));
                result = System.Convert.ToBase64String(hmacsha256.Hash);
                return result;
            }
        }
    }
}
