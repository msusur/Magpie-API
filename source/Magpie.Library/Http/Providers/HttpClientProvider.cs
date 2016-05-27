using System.Net.Http;
using CsQuery.ExtensionMethods;

namespace Magpie.Library.Http.Providers
{
    public class HttpClientProvider : IHttpProvider
    {
        public HttpResponse CallWebPage(HttpOptions options)
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
                var response = client.GetStringAsync(options.TargetUrl);
                response.Wait();
                httpContext.Response = new HttpResponse(response.Result);

                options.Interceptors.ForEach(i => i.AfterCall(httpContext));

                return httpContext.Response;
            }
        }
    }
}