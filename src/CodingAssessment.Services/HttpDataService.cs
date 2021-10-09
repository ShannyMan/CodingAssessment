using System;
using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services.Interfaces;
using Newtonsoft.Json;

namespace CodingAssessment.Services
{
    public class HttpDataService : IHttpDataService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpDataService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;
        
        public async Task<T> GetDataAsync<T>(string url, CancellationToken cancellationToken) where T : class
        {
            using var httpClient = _httpClientFactory.CreateHttpClient();
            using var response = await httpClient.Get(url, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error communicating with remote HTTP server.");
            }

            var stringData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringData);
        }
    }
}
