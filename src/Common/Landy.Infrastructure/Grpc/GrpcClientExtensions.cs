using System;
using Grpc.Core;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GrpcClientExtensions
    {
        public static IServiceCollection AddGrpcClientOptions<T>(
            this IServiceCollection services, string address) where T: ClientBase
        {
            services.AddGrpcClient<T>(i =>
            {
                i.Address = new Uri(address);
            });

            return services;
        }
    }
}
