using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CodingAssessment.Services.Interfaces
{
    public interface IHttpClient : IDisposable
    {
        Task<HttpResponseMessage> Get(string url, CancellationToken cancellationToken);
    }
}
