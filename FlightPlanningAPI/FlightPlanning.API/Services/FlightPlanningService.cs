using System.Net;
using FlightPlanning.Data;
using FlightPlanning.Data.Entities;
using Route = FlightPlanning.Data.Entities.Route;

namespace FlightPlanning.API.Services;

public class FlightPlanningService : IFlightPlanningService
{
    private readonly DbAccess _dbAccess = new DbAccess();
    private readonly ILogger<FlightPlanningService> _logger;
    const string ArrivalOnly = "Arrival Only";
    const string DepartureAndArrival = "Departure and Arrival";

    public FlightPlanningService(ILogger<FlightPlanningService> logger)
    {
        _logger = logger;
    }

    public async Task<List<Airport>> GetAirportList()
    {
        return await _dbAccess.GetAirportList();
    }

    public async Task<Airport> GetAirport(int airportId)
    {
        var airports = GetAirportList().Result;

        if (airports.All(a => a.AirportID != airportId))
            throw new ArgumentException($"The airport with ID {airportId} could not be found!");

        return await _dbAccess.GetAirport(airportId);
    }

    public async Task<List<Country>> GetCountryList()
    {
        return await _dbAccess.GetCountryList();
    }

    public HttpStatusCode AddCountry(string name)
    {
        var countries = GetCountryList().Result;

        if (countries.Any(c => String.Equals(c.Name, name, StringComparison.CurrentCultureIgnoreCase)))
            throw new ArgumentException($"Unable to add - Country {name} already exists!");

        _dbAccess.AddCountry(name);

        return HttpStatusCode.OK;
    }

    public HttpStatusCode DeleteCountry(int countryId)
    {
        var countries = GetCountryList().Result;

        if (countries.All(c => c.CountryID != countryId))
            throw new ArgumentException($"Unable to delete - Country with ID {countryId} could not be found!");

        var airports = GetAirportList().Result;
        var hostCountryAirport = airports.Find(a => a.GeographyLevel1ID == countryId);

        if (hostCountryAirport != null)
            throw new ArgumentException($"Unable to delete - Country with ID {countryId} is in use for airport {hostCountryAirport.IATACode}!");

        _dbAccess.DeleteCountry(countryId);

        return HttpStatusCode.OK;
    }

    public async Task<List<Route>> GetRouteList()
    {
        return await _dbAccess.GetRouteList();
    }

    public HttpStatusCode AddRoute(int departureAirportId, int arrivalAirportId)
    {
        var routes = GetRouteList().Result;

        if (routes.Any(r => r.DepartureAirportID == departureAirportId && r.ArrivalAirportID == arrivalAirportId))
            throw new ArgumentException($"Unable to add - Route from airport {departureAirportId} to airport {arrivalAirportId} already exists!");

        var airports = GetAirportList().Result;

        if (airports.All(a => a.AirportID != departureAirportId))
            throw new ArgumentException($"The departure airport {departureAirportId} could not be found!");

        if (airports.All(a => a.AirportID != arrivalAirportId))
            throw new ArgumentException($"The arrival airport {arrivalAirportId} could not be found!");

        var departureAirport = airports.Find(a => a.AirportID == departureAirportId);

        if (departureAirport is { Type: ArrivalOnly })
            throw new ArgumentException($"Invalid route - The chosen departure airport {departureAirportId} is {ArrivalOnly}!");

        _dbAccess.AddRoute(departureAirportId, arrivalAirportId);

        return HttpStatusCode.OK;
    }

    public HttpStatusCode AddRouteByAirportGroups(int departureAirportGroupId, int arrivalAirportGroupId)
    {
        var departGroupAirportsLinks = _dbAccess.GetAirportGroupAirportsLinks().Result.Where(l => l.AirportGroupID == departureAirportGroupId);
        var departAirportId = departGroupAirportsLinks.First(l => l.Airport.Type == DepartureAndArrival).Airport.AirportID;

        var arriveGroupAirportsLinks = _dbAccess.GetAirportGroupAirportsLinks().Result.Where(l => l.AirportGroupID == arrivalAirportGroupId);
        var arriveAirportId = arriveGroupAirportsLinks.First(l => l.Airport.Type is DepartureAndArrival or ArrivalOnly).Airport.AirportID;

        return AddRoute(departAirportId, arriveAirportId);
    }
}
