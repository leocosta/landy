using Landy.Infrastructure.MessageBrokers;
using Landy.Infrastructure.SearchIndexers;

namespace Landy.Services.Offer.Core.Configuration
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public MessageBrokerOptions MessageBroker { get; set; }
        public SearchIndexerOptions SearchIndexer { get; set; }
    }

    public class ConnectionStrings
    {
        public string Offers { get; set; }
    }
}