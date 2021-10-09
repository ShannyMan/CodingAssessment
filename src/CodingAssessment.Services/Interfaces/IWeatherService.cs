using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services.Models;

namespace CodingAssessment.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<Models.MuddyWeatherForecast> GetMuddyForecast(GeoLocation geoLocation, CancellationToken cancellationToken);
    }
}
