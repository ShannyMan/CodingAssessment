using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services.Interfaces;
using CodingAssessment.Services.Models;

namespace CodingAssessment.Services
{
    public class GoogleGeolocationService : IGoogleGeolocationService
    {
        private readonly IHttpDataService _httpDataService;

        private readonly HttpDataConfiguration _config;

        private const string BaseUrl = "https://maps.googleapis.com/maps/api/geocode/json";

        public GoogleGeolocationService(IHttpDataService httpDataService, HttpDataConfiguration config)
        {
            _httpDataService = httpDataService;
            _config = config;
        }

        public async Task<string> GetCityStateLocationFromCoordinates(decimal longitude, decimal latitude, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}?latlng={latitude}%2C{longitude}&language=en&key={_config.GoogleApiKey}";
            var locationData = await _httpDataService.GetDataAsync<GoogleGeolocationResponse>(url, cancellationToken);

            var postalRecord = FindPostalRecord(locationData);

            return postalRecord?.formatted_address ?? string.Empty;
        }

        public async Task<GeoLocation?> GetGeolocationFromCityStateSearch(string cityStateSearch, CancellationToken cancellationToken)
        {
            var url = $"{BaseUrl}?address={cityStateSearch}&language=en&key={_config.GoogleApiKey}";
            var locationData = await _httpDataService.GetDataAsync<GoogleGeolocationResponse>(url, cancellationToken);

            var postalRecord = FindPostalRecord(locationData);

            if (postalRecord == null)
            {
                return null;
            }

            return new GeoLocation
            {
                Latitude = Convert.ToDecimal(postalRecord.geometry.location.lat),
                Longitude = Convert.ToDecimal(postalRecord.geometry.location.lng)
            };
        }

        private static GoogleGeolocationResponse.Result? FindPostalRecord(GoogleGeolocationResponse? locationData)
        {
            if (locationData == null || locationData.status != "OK" || locationData.results == null)
            {
                return null;
            }

            return locationData.results.FirstOrDefault(l => l.types.Contains("postal_code")) ??
                   locationData.results.FirstOrDefault();
        }
    }
}
