using System.ComponentModel.DataAnnotations;

namespace FlightPlanning.Data.Entities;

public class Airport
{
    [Key]
    public int AirportID { get; set; }

    public string IATACode { get; set; }

    public int GeographyLevel1ID { get; set; }

    public string Type { get; set; }
}
