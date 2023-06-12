using System.Net;
using FlightPlanning.Data.Entities;
using Route = FlightPlanning.Data.Entities.Route;

namespace FlightPlanning.API.Services;

public interface IFlightPlanningService
{
    public Task<List<Airport>> GetAirportList();

    public Task<Airport> GetAirport(int airportId);

    public Task<List<Country>> GetCountryList();

    public HttpStatusCode AddCountry(string name);

    public HttpStatusCode DeleteCountry(int countryId);

    public Task<List<Route>> GetRouteList();

    public HttpStatusCode AddRoute(int departureAirportId, int arrivalAirportId);

    public HttpStatusCode AddRouteByAirportGroups(int departureAirportGroupId, int arrivalAirportGroupId);
}
