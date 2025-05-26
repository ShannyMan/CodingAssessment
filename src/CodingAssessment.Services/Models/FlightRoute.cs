namespace CodingAssessment.Services.Models
{
    public class FlightRoute
    {
        public string Destination { get; set; }
        public string Airline { get; set; }
        public decimal Price { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public bool IsDirectFlight { get; set; }
    }
}