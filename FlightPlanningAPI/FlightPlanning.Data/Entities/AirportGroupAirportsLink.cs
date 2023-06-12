using System.ComponentModel.DataAnnotations;

namespace FlightPlanning.Data.Entities;

public class AirportGroupAirportsLink
{
    [Key]
    public int LinkId { get; set; }

    public int AirportGroupID { get; set; }

    public int AirportId { get; set; }

    public Airport Airport { get; set; } = null!;
}
