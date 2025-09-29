using Airport_Controll_System.Controllers;
using Airport_Controll_System.DataModels;
using Airport_Controll_System.Repository;

namespace Airport_Controll_System.Service
{
    public class AirportMgmtSystemService: IAirportMgmtSystemService
    {
        private readonly ILogger<AirportMgmtSystemService> _logger;
        private readonly IAirportMgmtSystemRepo _repo;


        public AirportMgmtSystemService(ILogger<AirportMgmtSystemService> logger, IAirportMgmtSystemRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<List<AirportDestinationDetails>> GetDestinations(string sourceCode)
        {
            return await _repo.GetDestinations(sourceCode);
        }
    }
}
