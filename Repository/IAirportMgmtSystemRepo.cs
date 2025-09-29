using Airport_Controll_System.DataModels;

namespace Airport_Controll_System.Repository
{
    public interface IAirportMgmtSystemRepo
    {
        Task<List<AirportDestinationDetails>> GetDestinations(string sourceCode);
    }
}
