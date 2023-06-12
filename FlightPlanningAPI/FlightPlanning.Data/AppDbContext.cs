using FlightPlanning.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanning.Data;

public class AppDbContext : DbContext
{
    private const string ConnectionString = //#A
        @"Server=localhost\SQLEXPRESS;
             Database=FlightPlanning;
             TrustServerCertificate=True;
             Trusted_Connection=True";

    public DbSet<Airport> Airports { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Route>   Routes { get; set; }

    public DbSet<AirportGroupAirportsLink> AirportGroupAirportsLinks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString); //#B
    }
}
