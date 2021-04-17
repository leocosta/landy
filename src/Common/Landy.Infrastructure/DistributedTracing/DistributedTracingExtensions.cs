using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Landy.Infrastructure.DistributedTracing
{
    public static class DistributedTracingExtensions
    {
        public static IServiceCollection AddDistributedTracing(
            this IServiceCollection services, DistributedTracingOptions options = default)
        {
            if (!options?.IsEnabled ?? true)
            {
                return services;
            }

            services.AddOpenTelemetryTracing(builder =>
            {
                var resourceBuilder = ResourceBuilder
                    .CreateDefault()
                    .AddService(options.Jaeger.ServiceName);

                builder
                    .SetResourceBuilder(resourceBuilder)
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .SetSampler(new AlwaysOnSampler())
                    .AddJaegerExporter(jaegerOptions =>
                    {
                        jaegerOptions.AgentHost = options.Jaeger.Host;
                        jaegerOptions.AgentPort = options.Jaeger.Port;
                    });
            });

            return services;
        }
    }
}
