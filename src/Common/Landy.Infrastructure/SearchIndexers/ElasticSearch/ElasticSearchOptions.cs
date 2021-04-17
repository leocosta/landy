namespace Landy.Infrastructure.SearchIndexers.ElasticSearch
{
    public class ElasticSearchOptions
    {
        public string BootstrapServers { get; set; }
        public string DefaultIndex { get; set; }
    }
}