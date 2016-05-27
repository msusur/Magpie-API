using System.Net.Http;
using System.Threading.Tasks;
using CsQuery.ExtensionMethods;

namespace Magpie.Library.Http.Providers
{
    public class HttpClientProvider : IHttpProvider
    {
        public async Task<HttpResponse> CallWebPage(HttpOptions options)
        {
            using (var client = new HttpClient())
            {
                var httpContext = new HttpCallContext();
                foreach (var header in options.Headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                httpContext.Options = options;
                httpContext.Client = client;

                options.Interceptors.ForEach(i => i.BeforeCall(httpContext));

                // work on this one..
                var response = await client.GetStringAsync(options.TargetUrl);
                
                httpContext.Response = new HttpResponse(response);

                options.Interceptors.ForEach(i => i.AfterCall(httpContext));

                return httpContext.Response;
            }
        }
    }
}