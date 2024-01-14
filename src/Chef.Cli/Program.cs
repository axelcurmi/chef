using Chef.Application;
using Chef.Cli;
using Chef.Cli.Commands;
using Chef.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
        services.AddApplicationServices()
            .AddInfrastructureServices();

        services.AddScoped<ListCommandHandler>();
        services.AddScoped<AddCommandHandler>();
        services.AddScoped<DeleteCommandHandler>();
        
        services.AddScoped<ConsoleRunner>();
    })
    .Build();

var consoleRunner = host.Services.GetRequiredService<ConsoleRunner>();
await consoleRunner.Run(args);
