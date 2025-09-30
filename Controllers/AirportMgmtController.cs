using Airport_Controll_System.DataModels;
using Airport_Controll_System.Service;
using Microsoft.AspNetCore.Mvc;

namespace Airport_Controll_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportMgmtController : ControllerBase
    {
        private readonly ILogger<AirportMgmtController> _logger;
        private readonly IAirportMgmtSystemService _airportMgmtSystemService;

        public AirportMgmtController(ILogger<AirportMgmtController> logger,IAirportMgmtSystemService airportMgmtSystemService)
        {
            _logger = logger;
            _airportMgmtSystemService= airportMgmtSystemService;
        }

        [HttpGet(Name = "GetDestinationDetails")]
        public async Task <List<AirportDestinationDetails>> GetDestinationDetails(string sourceCode)
        {
           return  await _airportMgmtSystemService.GetDestinations(sourceCode);
        }
    }
}