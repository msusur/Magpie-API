using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NetHttp = System.Net.Http;
using Magpie.Library.Http.Exceptions;
using Magpie.Library.Http.Providers;

namespace Magpie.Library.Http
{
    public class HttpCall : IDisposable
    {
        private readonly IHttpProvider _provider;
        private static readonly Regex UrlRegexPattern = new Regex(Strings.UrlPattern);

        public HttpOptions Options { get; }

        private HttpCall(HttpOptions options, IHttpProvider provider)
        {
            if (provider == null)
            {
                // let's wait until we find a better solution.
                //provider = new BasicHttpProvider();
                provider = new HttpClientProvider();
            }

            _provider = provider;
            Options = options;
        }

        public static HttpCall To(string url, IHttpProvider provider = null)
        {
            var isValidUrl = UrlRegexPattern.IsMatch(url);

            if (!isValidUrl)
            {
                throw new InvalidUrlException(url);
            }

            HttpCall call = new HttpCall(new HttpOptions { TargetUrl = url }, provider);
            return call;
        }

        public void Dispose()
        {
            // we'll see if we really need this
        }

        public HttpCall AddHeader(string header, string value)
        {
            Options.Headers.Add(header, value);
            return this;
        }

        public HttpCall InterceptWith<TInterceptor>()
            where TInterceptor : BaseInterceptor, new()
        {
            Options.Interceptors.Add(new TInterceptor());
            return this;
        }

        public async Task<HttpResponse> LoadPage()
        {
            return await Task.Factory.StartNew(() => _provider.CallWebPage(Options));
        }
    }
}