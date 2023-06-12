namespace FlightPlanning.Data.Entities;

public class Route
{
    public int RouteID { get; set; }

    public int DepartureAirportID { get; set; }

    public int ArrivalAirportID { get; set; }
}
