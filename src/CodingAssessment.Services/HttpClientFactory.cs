using CodingAssessment.Services.Interfaces;

namespace CodingAssessment.Services
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public IHttpClient CreateHttpClient()
        {
            return new HttpClient();
        }
    }
}
