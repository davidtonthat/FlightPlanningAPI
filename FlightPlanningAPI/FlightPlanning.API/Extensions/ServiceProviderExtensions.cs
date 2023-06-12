using FlightPlanning.API.Services;

namespace FlightPlanning.API.Extensions;

public static class ServiceProviderExtensions
{
    public static IServiceCollection RegisterWebComponents(this IServiceCollection services,
        IConfiguration configuration)
    {
        RegisterServices(services);
        return services;
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IFlightPlanningService, FlightPlanningService>();
    }
}
