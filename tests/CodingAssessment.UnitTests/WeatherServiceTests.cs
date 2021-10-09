using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services;
using CodingAssessment.Services.Interfaces;
using CodingAssessment.Services.Models;
using Moq;
using Xunit;

namespace CodingAssessment.UnitTest
{
    public class WeatherServiceTests
    {
        private readonly WeatherService _weatherService;
        private readonly Mock<IHttpDataService> _httpDataService;
        private readonly GeoLocation _geoLocation = new GeoLocation();


        public WeatherServiceTests()
        {
            _httpDataService = new Mock<IHttpDataService>();
            _weatherService = new WeatherService(_httpDataService.Object, new HttpDataConfiguration());
        }

        [Fact]
        public async Task TestMuddyDayThree()
        {
            _httpDataService.Setup(x => x.GetDataAsync<OpenWeatherResponse>(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(CreateOpenWeatherResponse("Rain", "Sunny", 50));

            var retVal = await _weatherService.GetMuddyForecast(_geoLocation, CancellationToken.None);
            
            Assert.Equal(MuddyWeatherForecast.Muddy, retVal);
            _httpDataService.Verify(s => s.GetDataAsync<OpenWeatherResponse>(It.IsAny<string>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task TestTooColdToBeMuddy()
        {
            _httpDataService.Setup(x => x.GetDataAsync<OpenWeatherResponse>(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(CreateOpenWeatherResponse("Rain", "Sunny", 31));

            var retVal = await _weatherService.GetMuddyForecast(_geoLocation, CancellationToken.None);

            Assert.Equal(MuddyWeatherForecast.NotMuddy, retVal);
            _httpDataService.Verify(s => s.GetDataAsync<OpenWeatherResponse>(It.IsAny<string>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task TestNotMuddy()
        {
            _httpDataService.Setup(x => x.GetDataAsync<OpenWeatherResponse>(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(CreateOpenWeatherResponse("Sunny", "Sunny", 50));

            var retVal = await _weatherService.GetMuddyForecast(_geoLocation, CancellationToken.None);

            Assert.Equal(MuddyWeatherForecast.NotMuddy, retVal);
            _httpDataService.Verify(s => s.GetDataAsync<OpenWeatherResponse>(It.IsAny<string>(), CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task TestPossiblyMuddy()
        {
            _httpDataService.Setup(x => x.GetDataAsync<OpenWeatherResponse>(It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(CreateOpenWeatherResponse("Sunny", "Rain", 50));

            var retVal = await _weatherService.GetMuddyForecast(_geoLocation, CancellationToken.None);

            Assert.Equal(MuddyWeatherForecast.PossiblyMuddy, retVal);
            _httpDataService.Verify(s => s.GetDataAsync<OpenWeatherResponse>(It.IsAny<string>(), CancellationToken.None), Times.Once);
        }

        private static int ToUnixDate(DateTime date)
        {
            return Convert.ToInt32(new DateTimeOffset(date).ToUnixTimeSeconds());
        }

        private static OpenWeatherResponse CreateOpenWeatherResponse(string dayThreeWeather, string dayTwoWeather, double dayThreeMaxTemp)
        {
            return new OpenWeatherResponse
            {
                daily = new List<OpenWeatherResponse.Daily>
                {
                    new OpenWeatherResponse.Daily
                    {
                        dt = ToUnixDate(DateTime.Today),
                        temp = new OpenWeatherResponse.Temp
                        {
                            day = 50,
                            eve = 50,
                            max = 50,
                            min = 50,
                            morn = 50,
                            night = 50
                        },
                        weather = new List<OpenWeatherResponse.Weather>
                        {
                            new OpenWeatherResponse.Weather
                            {
                                main = "Sunny"
                            }

                        }
                    },
                    new OpenWeatherResponse.Daily
                    {
                        dt = ToUnixDate(DateTime.Today.AddDays(1)),
                        temp = new OpenWeatherResponse.Temp
                        {
                            day = 50,
                            eve = 50,
                            max = 50,
                            min = 50,
                            morn = 50,
                            night = 50
                        },
                        weather = new List<OpenWeatherResponse.Weather>
                        {
                            new OpenWeatherResponse.Weather
                            {
                                main = "Sunny"
                            }

                        }
                    },
                    new OpenWeatherResponse.Daily
                    {
                        dt = ToUnixDate(DateTime.Today.AddDays(2)),
                        temp = new OpenWeatherResponse.Temp
                        {
                            day = 50,
                            eve = 50,
                            max = 50,
                            min = 50,
                            morn = 50,
                            night = 50
                        },
                        weather = new List<OpenWeatherResponse.Weather>
                        {
                            new OpenWeatherResponse.Weather
                            {
                                main = dayTwoWeather
                            }

                        }
                    },
                    new OpenWeatherResponse.Daily
                    {
                        dt = ToUnixDate(DateTime.Today.AddDays(3)),
                        temp = new OpenWeatherResponse.Temp
                        {
                            day = dayThreeMaxTemp,
                            eve = dayThreeMaxTemp,
                            max = dayThreeMaxTemp,
                            min = dayThreeMaxTemp,
                            morn = dayThreeMaxTemp,
                            night = dayThreeMaxTemp
                        },
                        weather = new List<OpenWeatherResponse.Weather>
                        {
                            new OpenWeatherResponse.Weather
                            {
                                main = dayThreeWeather
                            }

                        }
                    }
                }
            };
        }
    }
}