using System.Net.Http;
using System.Threading.Tasks;

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

                foreach (var interceptor in options.Interceptors)
                {
                    interceptor.BeforeCall(httpContext);
                }

                // work on this one..
                var response = await client.GetStringAsync(options.TargetUrl);
                
                httpContext.Response = new HttpResponse(response);

                foreach (var interceptor in options.Interceptors)
                {
                    interceptor.AfterCall(httpContext);
                }

                return httpContext.Response;
            }
        }
    }
}