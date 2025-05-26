using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Services.Models;

namespace CodingAssessment.Services.Interfaces
{
    public interface IFlightRouteService
    {
        Task<List<FlightRoute>> GetFlightRoutesFromGrandRapids(CancellationToken cancellationToken);
        Task<List<FlightRoute>> GetCheapestFlightRoutes(CancellationToken cancellationToken);
    }
}