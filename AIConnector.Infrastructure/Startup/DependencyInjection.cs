
using AIConnector.Infrastructure.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AIConnector.Infrastructure.Startup;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.TryAddScoped<IGPTHandler, GPTHandler>();
        return services;
    }
}