using System.Reflection;
using MediatR;
using Landy.Infrastructure.SearchIndexers;
using Landy.Services.Offer.Core.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OfferModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddOfferModuleCore(this IServiceCollection services, AppSettings appSettings)
        {
            // configure MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // configure search indexers
            services.AddSearchIndexer(appSettings.SearchIndexer);

            return services;
        }
    }
}