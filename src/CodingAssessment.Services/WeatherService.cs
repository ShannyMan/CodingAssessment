using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services.Interfaces;
using CodingAssessment.Services.Models;

namespace CodingAssessment.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpDataService _httpDataService;

        private readonly HttpDataConfiguration _config;

        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/onecall";

        private const int FreezingTemp = 32;

        public WeatherService(IHttpDataService httpDataService, HttpDataConfiguration config)
        {
            _httpDataService = httpDataService;
            _config = config;
        }

        public async Task<Models.MuddyWeatherForecast> GetMuddyForecast(Models.GeoLocation geoLocation, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}?lat={geoLocation.Latitude}&lon={geoLocation.Longitude}&exclude=current,minutely,alerts,hourly&units=imperial&appid={_config.OpenWeatherApiKey}";
            var weatherResponse = await _httpDataService.GetDataAsync<Models.OpenWeatherResponse>(url, cancellationToken);

            var dayTwo = weatherResponse.daily.First(d => d.Date.Date == DateTime.Today.AddDays(2));
            var dayThree = weatherResponse.daily.First(d => d.Date.Date == DateTime.Today.AddDays(3));

            const string rain = "Rain";

            if (dayThree.temp.max <= FreezingTemp)
            {
                return MuddyWeatherForecast.NotMuddy;
            }

            if (dayThree.weather.Any(w => w.main == rain))
            {
                return MuddyWeatherForecast.Muddy;
            }

            if (dayTwo.weather.Any(w => w.main == rain))
            {
                return MuddyWeatherForecast.PossiblyMuddy;
            }

            return MuddyWeatherForecast.NotMuddy;
        }
    }
}
