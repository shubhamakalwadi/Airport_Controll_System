using System;
using System.Collections.Generic;

namespace Airport_Controll_System.Models;

public partial class Routes
{
    public int RouteId { get; set; }

    public string SourceAirportCode { get; set; } = null!;

    public string DestinationAirportCode { get; set; } = null!;

    public int? DistanceKm { get; set; }

    public int? FlightDurationMinutes { get; set; }

    public virtual Airport DestinationAirportCodeNavigation { get; set; } = null!;

    public virtual Airport SourceAirportCodeNavigation { get; set; } = null!;

}
