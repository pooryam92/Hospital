using Hospital.Application;
using Hospital.Infrastructure.Database;
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
        services.AddScoped<Seed.Seed>();

        return services;
    }

}