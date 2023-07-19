using Microsoft.Extensions.Diagnostics.HealthChecks;
namespace api.v1.service.auth.Helpers
{
    public class HealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            return isHealthy ? 
                Task.FromResult(HealthCheckResult.Healthy("A healthy result")) : 
                Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "An unhealthy result."));
        }
    }
}