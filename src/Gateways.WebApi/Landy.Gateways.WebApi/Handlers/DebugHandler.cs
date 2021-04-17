using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Landy.Gateways.WebApi.Handlers
{
    public class DebugHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
