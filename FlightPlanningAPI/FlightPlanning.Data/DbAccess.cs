using FlightPlanning.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanning.Data;

public class DbAccess
{
    private readonly AppDbContext _appDbContext = new();

    public async Task<List<Airport>> GetAirportList()
    {
        return await _appDbContext.Airports.ToListAsync();
    }

    public async Task<Airport> GetAirport(int airportId)
    {
        try
        {
            return _appDbContext.Airports.First( a => a.AirportID == airportId);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error attempting to retrieve airport details with ID {airportId}.");
        }
    }

    public async Task<List<Country>> GetCountryList()
    {
        return await _appDbContext.Countries.ToListAsync();
    }

    public void AddCountry(string name)
    {
        try
        {
            _appDbContext.Countries.Add(new Country { Name = name });
            _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error attempting to add country {name} - {ex.Message}.");
        }
    }

    public void DeleteCountry(int countryId)
    {
        try
        {
            var country = _appDbContext.Countries.First(c => c.CountryID == countryId);
            _appDbContext.Countries.Remove(country);
            _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error attempting to delete country with ID {countryId} - {ex.Message}.");
        }
    }

    public async Task<List<Route>> GetRouteList()
    {
        return await _appDbContext.Routes.ToListAsync();
    }

    public async Task<List<AirportGroupAirportsLink>> GetAirportGroupAirportsLinks()
    {
        return await _appDbContext.AirportGroupAirportsLinks.Include(l => l.Airport).ToListAsync();
    }

    public void AddRoute(int departureAirportId, int arrivalAirportId)
    {
        try
        {
            _appDbContext.Routes.Add( new Route { DepartureAirportID = departureAirportId, ArrivalAirportID = arrivalAirportId});
            _appDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error attempting to add route from airport {departureAirportId} to airport {arrivalAirportId} - {ex.Message}.");
        }
    }
}
