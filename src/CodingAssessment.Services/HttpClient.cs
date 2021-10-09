using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services.Interfaces;

namespace CodingAssessment.Services
{
    public class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient = new System.Net.Http.HttpClient();
        
        public Task<HttpResponseMessage> Get(string url, CancellationToken cancellationToken)
        {
            return _httpClient.GetAsync(new Uri(url), cancellationToken);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
