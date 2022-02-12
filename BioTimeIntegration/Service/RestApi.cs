using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BioTimeIntegration.Back
{


    public class RestApi
    {
        private string Uri = BioTimeIntegration.Properties.Resources.Url;
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly JsonSerializerOptions _options;
        private string Token;


        public RestApi()
        {
            _httpClient.BaseAddress = new Uri(Uri);
            _httpClient.Timeout = new TimeSpan(0, 0, 2);
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<Tdata> GetAsync<Tdata>(string path, string header = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);
            if (header != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue($"JWT", header);
            }
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<Tdata>(content, _options);

            return data;
        }

        public async Task<Tdata> PostAsync<Tdata>(string path, object body, MediaTypeWithQualityHeaderValue header = null)
        {
            var requestBody = JsonSerializer.Serialize(body);

            var request = new HttpRequestMessage(HttpMethod.Post, path);
            if (header != null)
            {
                request.Headers.Accept.Add(header);
            }
            request.Content = new StringContent(requestBody);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<Tdata>(content, _options);

            return data;
        }



    }
}
