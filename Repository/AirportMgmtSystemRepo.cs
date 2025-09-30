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
            var destinations = new List<AirportDestinationDetails>();
            try
            {
                _logger.LogInformation("Fetching of Destination Airport Started with SourceCode:" + sourceCode);
                destinations = await _context.Routes
                                   .Where(r => r.SourceAirportCode == sourceCode)
                                   .Include(r => r.DestinationAirportCodeNavigation)
                                   .Select(r => new AirportDestinationDetails
                                   {
                                       AirportName = r.DestinationAirportCode,
                                       Distance = r.DistanceKm,
                                       Duration = r.FlightDurationMinutes
                                   }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Repository at GetDestination Method", ex.Message);
            }
            return destinations;
        }

    }
}
