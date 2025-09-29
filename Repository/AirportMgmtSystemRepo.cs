using Airport_Controll_System.Controllers;
using Airport_Controll_System.Data;
using Airport_Controll_System.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Airport_Controll_System.Repository
{
    public class AirportMgmtSystemRepo : IAirportMgmtSystemRepo
    {
        private readonly ILogger<AirportMgmtSystemRepo> _logger;
        private readonly AirportMgmtSystemContext _context;

        public AirportMgmtSystemRepo(ILogger<AirportMgmtSystemRepo> logger, AirportMgmtSystemContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<List<AirportDestinationDetails>> GetDestinations(string sourceCode)
        {
            var destinations = await _context.Routes
                                .Where(r => r.SourceAirportCode == sourceCode)
                                .Include(r => r.DestinationAirportCodeNavigation)
                                .Select(r => new AirportDestinationDetails
                                {
                                    AirportName = r.DestinationAirportCode,
                                    Distance = r.DistanceKm,
                                    Duration = r.FlightDurationMinutes
                                }).ToListAsync();
            return destinations;
        }

    }
}
