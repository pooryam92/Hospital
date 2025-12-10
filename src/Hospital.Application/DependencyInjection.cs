using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(p =>
        {
            p.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}