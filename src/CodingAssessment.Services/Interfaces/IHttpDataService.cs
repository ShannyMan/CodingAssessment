using System.Threading;
using System.Threading.Tasks;

namespace CodingAssessment.Services.Interfaces
{
    public interface IHttpDataService
    {
        Task<T> GetDataAsync<T>(string url, CancellationToken cancellationToken) where T: class;
    }
}
