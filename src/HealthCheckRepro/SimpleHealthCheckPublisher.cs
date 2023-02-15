using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace HealthCheckRepro
{
    internal class SimpleHealthCheckPublisher : IHealthCheckPublisher
    {
        private readonly ILogger<SimpleHealthCheckPublisher> logger;

        public SimpleHealthCheckPublisher(ILogger<SimpleHealthCheckPublisher> logger)
        {
            this.logger = logger;
        }

        public Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
        {
            logger.LogInformation("HealthReport received: {Status}", report.Status);

            return Task.CompletedTask;
        }
    }
}
