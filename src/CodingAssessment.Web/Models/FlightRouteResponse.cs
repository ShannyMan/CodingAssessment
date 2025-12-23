using CodingAssessment.Services.Models;
using System.Collections.Generic;

namespace CodingAssessment.Web.Models
{
    public class FlightRouteResponse
    {
        public List<FlightRoute> Routes { get; set; } = new List<FlightRoute>();
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
    }
}