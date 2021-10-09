using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services.Models;

namespace CodingAssessment.Services.Interfaces
{
    public interface IGoogleGeolocationService
    {
        Task<string> GetCityStateLocationFromCoordinates(decimal longitude, decimal latitude, CancellationToken cancellationToken);

        Task<GeoLocation?> GetGeolocationFromCityStateSearch(string cityStateSearch, CancellationToken cancellationToken);
    }
}
