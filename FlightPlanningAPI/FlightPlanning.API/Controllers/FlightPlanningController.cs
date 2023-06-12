using System.ComponentModel.DataAnnotations;
using FlightPlanning.API.Services;
using FlightPlanning.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Route = FlightPlanning.Data.Entities.Route;

namespace FlightPlanning.API.Controllers;

[ApiController]
[Route("api/flights")]
public class FlightPlanningController : ControllerBase
{
    private readonly IFlightPlanningService _flightPlanningService;
    private readonly ILogger<FlightPlanningController> _logger;

    public FlightPlanningController(
        ILogger<FlightPlanningController> logger,
        IFlightPlanningService flightPlanningService)
    {
        _logger = logger;
        _flightPlanningService = flightPlanningService;
    }

    [HttpGet]
    [Route("airports")]
    public Task<List<Airport>> GetAirportList()
    {
        return _flightPlanningService.GetAirportList();
    }

    [HttpGet]
    [Route("airports/{ID:int}")]
    public Task<Airport> GetAirport(int ID)
    {
        return _flightPlanningService.GetAirport(ID);
    }

    [HttpGet]
    [Route("countries")]
    public Task<List<Country>> GetCountryList()
    {
        return _flightPlanningService.GetCountryList();
    }

    [HttpPost]
    [Route("countries")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCountry([Required, FromBody] string name)
    {
        var status = _flightPlanningService.AddCountry(name);

        return Ok(status);
    }

    [HttpDelete]
    [Route("countries/{ID:int}")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteCountry(int ID)
    {
        var status = _flightPlanningService.DeleteCountry(ID);

        return Ok(status);
    }

    [HttpGet]
    [Route("routes")]
    public Task<List<Route>> GetRouteList()
    {
        return _flightPlanningService.GetRouteList();
    }

    [HttpPost]
    [Route("simple-routes")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddRoute(
        [Required, FromHeader] int departureAirportId,
        [Required, FromHeader] int arrivalAirportId)
    {
        var status = _flightPlanningService.AddRoute(departureAirportId, arrivalAirportId);

        return Ok(status);
    }

    [HttpPost]
    [Route("routes")]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddRouteByAirportGroups(
        [Required, FromHeader] int departureAirportGroupId,
        [Required, FromHeader] int arrivalAirportGroupId)
    {
        var status = _flightPlanningService.AddRouteByAirportGroups(departureAirportGroupId, arrivalAirportGroupId);

        return Ok(status);
    }
}
