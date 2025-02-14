using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoCleanArchitecture.Domain.Abstractions.UnitOfWorks;
using TodoCleanArchitecture.Infrastructure.UnitOfWorks;

namespace TodoCleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ToDoCleanDbContext>(options =>
        {
            string connectionString = configuration.GetConnectionString("DefaultConnectionString");
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUnitOfWork,UnitOfWork>();
        return services;
    }
}
