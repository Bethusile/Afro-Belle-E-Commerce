using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AB.Helpers
{
    public class PayPalClient
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public PayPalClient(string clientId, string clientSecret, bool useSandbox = true)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            _baseUrl = useSandbox ? "https://api.sandbox.paypal.com" : "https://api.paypal.com";
        }
        // Constructor accepting HttpClient
        public PayPalClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        private async Task<string> GetAccessTokenAsync()
        {
            using var client = new HttpClient();
            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);

            var requestBody = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync($"{_baseUrl}/v1/oauth2/token", requestBody);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Unable to fetch PayPal access token.");

            var responseData = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());
            return responseData.GetProperty("access_token").GetString();
        }

        public async Task<string> CreateOrderAsync(decimal totalAmount, string currency = "ZAR")
        {
            var accessToken = await GetAccessTokenAsync();

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var orderPayload = new
            {
                intent = "CAPTURE",
                purchase_units = new[]
                {
                    new
                    {
                        amount = new
                        {
                            currency_code = currency,
                            value = totalAmount.ToString("F2")
                        }
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(orderPayload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_baseUrl}/v2/checkout/orders", content);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Unable to create PayPal order.");

            var responseData = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());
            return responseData.GetProperty("id").GetString(); // Return the PayPal Order ID
        }

        public async Task<bool> CaptureOrderAsync(string orderId)
        {
            var accessToken = await GetAccessTokenAsync();

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.PostAsync($"{_baseUrl}/v2/checkout/orders/{orderId}/capture", null);

            if (!response.IsSuccessStatusCode)
                return false;

            var responseData = JsonSerializer.Deserialize<JsonElement>(await response.Content.ReadAsStringAsync());
            var status = responseData.GetProperty("status").GetString();

            return status == "COMPLETED";
        }
    }
}
