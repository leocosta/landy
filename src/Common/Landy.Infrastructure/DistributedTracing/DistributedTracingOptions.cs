namespace Landy.Infrastructure.DistributedTracing
{
    public class DistributedTracingOptions
    {
        public bool IsEnabled { get; set; }
        public JaegerOptions Jaeger { get; set; }
    }

    public class JaegerOptions
    {
        public string ServiceName { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}