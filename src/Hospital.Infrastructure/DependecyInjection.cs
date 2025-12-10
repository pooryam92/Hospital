using Hospital.Application;
using Hospital.Application.Abstractions;
using Hospital.Infrastructure.Database;
using Hospital.Infrastructure.FileHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<HospitalContext>(options =>
            {
                options.UseInMemoryDatabase("HospitalDB");
            }
        );
        services.AddScoped<IHospitalContext>(provider => provider.GetRequiredService<HospitalContext>());
        services.AddScoped<IFileHandler, FileHandlerMock>();
        services.AddScoped<Seed.Seed>();

        return services;
    }

}