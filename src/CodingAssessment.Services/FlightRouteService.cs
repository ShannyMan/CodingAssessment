using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services.Interfaces;
using CodingAssessment.Services.Models;

namespace CodingAssessment.Services
{
    public class FlightRouteService : IFlightRouteService
    {
        // Mock data for flight routes from Grand Rapids, MI
        private readonly List<FlightRoute> _flightRoutes = new List<FlightRoute>
        {
            new FlightRoute
            {
                Destination = "New York, NY",
                Airline = "Delta",
                Price = 299.99m,
                DepartureTime = "08:00 AM",
                ArrivalTime = "11:30 AM",
                Duration = "3h 30m",
                IsDirectFlight = true
            },
            new FlightRoute
            {
                Destination = "Chicago, IL",
                Airline = "United",
                Price = 149.99m,
                DepartureTime = "09:15 AM",
                ArrivalTime = "10:00 AM",
                Duration = "45m",
                IsDirectFlight = true
            },
            new FlightRoute
            {
                Destination = "Los Angeles, CA",
                Airline = "American",
                Price = 399.99m,
                DepartureTime = "06:30 AM",
                ArrivalTime = "10:45 AM",
                Duration = "4h 15m",
                IsDirectFlight = true
            },
            new FlightRoute
            {
                Destination = "Miami, FL",
                Airline = "Delta",
                Price = 329.99m,
                DepartureTime = "07:45 AM",
                ArrivalTime = "12:30 PM",
                Duration = "4h 45m",
                IsDirectFlight = true
            },
            new FlightRoute
            {
                Destination = "Denver, CO",
                Airline = "Southwest",
                Price = 259.99m,
                DepartureTime = "10:00 AM",
                ArrivalTime = "12:15 PM",
                Duration = "3h 15m",
                IsDirectFlight = true
            },
            new FlightRoute
            {
                Destination = "Atlanta, GA",
                Airline = "Delta",
                Price = 239.99m,
                DepartureTime = "11:30 AM",
                ArrivalTime = "02:45 PM",
                Duration = "3h 15m",
                IsDirectFlight = true
            },
            new FlightRoute
            {
                Destination = "Dallas, TX",
                Airline = "American",
                Price = 279.99m,
                DepartureTime = "09:30 AM",
                ArrivalTime = "12:15 PM",
                Duration = "2h 45m",
                IsDirectFlight = false
            },
            new FlightRoute
            {
                Destination = "Seattle, WA",
                Airline = "Alaska",
                Price = 349.99m,
                DepartureTime = "08:15 AM",
                ArrivalTime = "11:30 AM",
                Duration = "4h 15m",
                IsDirectFlight = true
            },
            new FlightRoute
            {
                Destination = "Boston, MA",
                Airline = "JetBlue",
                Price = 289.99m,
                DepartureTime = "07:00 AM",
                ArrivalTime = "10:30 AM",
                Duration = "3h 30m",
                IsDirectFlight = true
            },
            new FlightRoute
            {
                Destination = "Las Vegas, NV",
                Airline = "Southwest",
                Price = 269.99m,
                DepartureTime = "08:45 AM",
                ArrivalTime = "11:15 AM",
                Duration = "3h 30m",
                IsDirectFlight = false
            }
        };

        public Task<List<FlightRoute>> GetFlightRoutesFromGrandRapids(CancellationToken cancellationToken)
        {
            // In a real implementation, this would call an external API or database
            return Task.FromResult(_flightRoutes);
        }

        public Task<List<FlightRoute>> GetCheapestFlightRoutes(CancellationToken cancellationToken)
        {
            // Get one cheapest flight per destination
            var cheapestRoutes = _flightRoutes
                .GroupBy(r => r.Destination)
                .Select(g => g.OrderBy(r => r.Price).First())
                .OrderBy(r => r.Price)
                .ToList();

            return Task.FromResult(cheapestRoutes);
        }
    }
}