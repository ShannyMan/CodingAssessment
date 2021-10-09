using System;
using CodingAssessment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodingAssessment.Services
{
    public static class ServiceRegistrar
    {
        public static void RegisterHttpServices(this IServiceCollection serviceCollection, HttpDataConfiguration config)
        {
            serviceCollection.AddTransient<IHttpClient, HttpClient>();
            serviceCollection.AddSingleton<IHttpClientFactory, HttpClientFactory>();
            serviceCollection.AddSingleton<IHttpDataService, HttpDataService>();
            serviceCollection.AddSingleton<IGoogleGeolocationService, GoogleGeolocationService>(s =>
                new GoogleGeolocationService(s.GetService<IHttpDataService>() ?? throw new NullReferenceException("Service could not be resolved"), config)
            );
            serviceCollection.AddSingleton<IWeatherService, WeatherService>(s =>
                new WeatherService(s.GetService<IHttpDataService>() ?? throw new NullReferenceException("Service could not be resolved"), config)
            );
        }
    }
}
