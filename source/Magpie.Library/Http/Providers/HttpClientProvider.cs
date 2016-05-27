using System;
using System.Net.Http;
using CsQuery.ExtensionMethods;

namespace Magpie.Library.Http.Providers
{
    public class HttpClientProvider : IHttpProvider
    {
        public async void CallWebPage(HttpOptions options, Action<HtmlResponse> callback)
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

                var response = await client.GetStringAsync(options.TargetUrl);
                httpContext.Response = new HttpResponse(response);

                options.Interceptors.ForEach(i => i.AfterCall(httpContext));
            }
        }
    }
}