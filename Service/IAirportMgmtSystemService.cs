using Airport_Controll_System.DataModels;

namespace Airport_Controll_System.Service
{
    public interface IAirportMgmtSystemService
    {
        Task<List<AirportDestinationDetails>> GetDestinations(string sourceCode);
    }
}
