using System;
using System.Collections.Generic;

namespace Airport_Controll_System.Models;

public partial class Airport
{
    public string AirportCode { get; set; } = null!;

    public string AirportName { get; set; } = null!;

    public string? City { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<Routes> RouteDestinationAirportCodeNavigations { get; set; } = new List<Routes>();

    public virtual ICollection<Routes> RouteSourceAirportCodeNavigations { get; set; } = new List<Routes>();
}
