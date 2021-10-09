using System;

namespace CodingAssessment.Services.Interfaces
{
    public interface IHttpClientFactory
    {
        IHttpClient CreateHttpClient();
    }
}
