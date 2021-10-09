using CodingAssessment.Services.Models;

namespace CodingAssessment.Web.Models
{
    public class MuddyForecastResponse
    {
        public MuddyWeatherForecast Forecast { get; set; }

        public string? Message { get; set; }
    }
}
