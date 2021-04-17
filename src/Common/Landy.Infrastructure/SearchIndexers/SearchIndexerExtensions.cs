using System;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Landy.Infrastructure.SearchIndexers.ElasticSearch;

namespace Landy.Infrastructure.SearchIndexers
{
    public static class SearchIndexerExtensions
    {
        public static IServiceCollection AddSearchIndexer(this IServiceCollection services, SearchIndexerOptions options)
        {
            services.AddElasticSearch(options.ElasticSearch);

            return services;
        }

        private static IServiceCollection AddElasticSearch(this IServiceCollection services, ElasticSearchOptions options)
        {
            var uri = new Uri(options.BootstrapServers);
            var connectionSettings = new ConnectionSettings(uri);
            connectionSettings.EnableDebugMode();

            if (!string.IsNullOrWhiteSpace(options.DefaultIndex))
            {
                connectionSettings.DefaultIndex(options.DefaultIndex);
            }

            services.AddSingleton<IElasticClient>(new ElasticClient(connectionSettings));

            return services;
        }
    }
}