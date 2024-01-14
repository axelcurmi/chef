using Chef.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chef.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMealService, MealService>();
        return services;
    }
}