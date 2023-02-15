using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using HealthCheckRepro;

await Host.CreateDefaultBuilder()
    .ConfigureLogging(loggerBuilder =>
    {
        loggerBuilder.AddConsole();
    })
    .ConfigureServices((hostContext, services) => {

#if false
        //This works fine - IHealthCheckPublisher.PublishAsync is called
        services.AddHealthChecks();
#else
        //This does not work - IHealthCheckPublisher.PublishAsync is NEVER called
        services.AddHealthChecks()
            .AddCheck("test", () =>HealthCheckResult.Healthy("We're good"));
#endif

        services.AddSingleton<IHealthCheckPublisher, SimpleHealthCheckPublisher>();

        services.Configure<HealthCheckPublisherOptions>(options =>
        {
            options.Delay = TimeSpan.FromSeconds(1);
            options.Period = TimeSpan.FromSeconds(5);
        });

    }).RunConsoleAsync();
