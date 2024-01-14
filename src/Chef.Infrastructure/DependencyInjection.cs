using Chef.Core.Repositories;
using Chef.Infrastructure.Data;
using Chef.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Chef.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        var dbFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "chef.db");
        
        services.AddSingleton(new ChefDbContext($"{dbFile}"));
        services.AddScoped<IMealRepository, MealRepository>();
        
        return services;
    }
}