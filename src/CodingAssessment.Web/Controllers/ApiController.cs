using CodingAssessment.Services.Interfaces;
using CodingAssessment.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Web.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        private readonly IGoogleGeolocationService _googleGeolocationService;

        private readonly IWeatherService _weatherService;
        
        private readonly IFlightRouteService _flightRouteService;

        public ApiController(ILogger<ApiController> logger, IGoogleGeolocationService googleGeolocationService, 
            IWeatherService weatherService, IFlightRouteService flightRouteService)
        {
            _logger = logger;
            _googleGeolocationService = googleGeolocationService;
            _weatherService = weatherService;
            _flightRouteService = flightRouteService;
        }

        [HttpGet("api/city-state")]
        public async Task<IActionResult> GetCityStateFromGeolocation([FromQuery]decimal longitude, [FromQuery]decimal latitude, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _googleGeolocationService.GetCityStateLocationFromCoordinates(longitude, latitude, cancellationToken));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error calling api/city-state");
                return NoContent();
            }
        }

        [HttpGet("api/muddy-forecast")]
        public async Task<IActionResult> GetMuddyForecast([FromQuery]string cityStateLocation, CancellationToken cancellationToken)
        {
            try
            {
                var geoLocation = await _googleGeolocationService.GetGeolocationFromCityStateSearch(cityStateLocation, cancellationToken);

                if (geoLocation == null)
                {
                    return Ok(new Models.MuddyForecastResponse
                    {
                        Forecast = MuddyWeatherForecast.Error,
                        Message = "Unable to verify location"
                    });
                }

                return Ok(new Models.MuddyForecastResponse
                {
                    Forecast = await _weatherService.GetMuddyForecast(geoLocation, cancellationToken)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error calling api/muddy-forecast");
                return Ok(new Models.MuddyForecastResponse
                {
                    Forecast = MuddyWeatherForecast.Error,
                    Message = e.Message
                });
            }
        }
        
        [HttpGet("api/flight-routes")]
        public async Task<IActionResult> GetFlightRoutes(CancellationToken cancellationToken)
        {
            try
            {
                var routes = await _flightRouteService.GetFlightRoutesFromGrandRapids(cancellationToken);
                return Ok(new Models.FlightRouteResponse 
                { 
                    Routes = routes,
                    Success = true
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error calling api/flight-routes");
                return Ok(new Models.FlightRouteResponse
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }
        
        [HttpGet("api/cheapest-flights")]
        public async Task<IActionResult> GetCheapestFlights(CancellationToken cancellationToken)
        {
            try
            {
                var routes = await _flightRouteService.GetCheapestFlightRoutes(cancellationToken);
                return Ok(new Models.FlightRouteResponse 
                { 
                    Routes = routes,
                    Success = true
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error calling api/cheapest-flights");
                return Ok(new Models.FlightRouteResponse
                {
                    Success = false,
                    Message = e.Message
                });
            }
        }
    }
}
