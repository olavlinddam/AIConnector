using AIConnector.Application.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AIConnector.Infrastructure.Startup;

namespace AIConnector.Application.Startup;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.TryAddScoped<IWorklogService, WorklogService>();
        return services;
    }
}