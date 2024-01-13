using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositoryes;
using Microsoft.EntityFrameworkCore;
using Services.Hubs;
using Services.Interfaces;
using Services.Logic;
using Services.Mappers;

namespace serverPontaj.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("Database"),
                b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));

        return services;
    }

    public static IServiceCollection RegisterDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IClockingService, ClockingService>();
        services.AddAutoMapper(typeof(ServiceProfiler));
        services.AddSingleton<EmployeeHub>();
        services.AddSignalR();

        return services;
    }
}
