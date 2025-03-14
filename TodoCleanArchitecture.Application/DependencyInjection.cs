using Microsoft.Extensions.DependencyInjection;
using TodoCleanArchitecture.Application.Abstractions.Services;
using TodoCleanArchitecture.Application.Implementations.Services;

namespace TodoCleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IManagerService, ManagerService>();

        return services;
    }
}
