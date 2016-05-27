using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsQuery.ExtensionMethods;
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
                provider = new BasicHttpProvider();
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

        public async Task<HttpCall> Get(Action<CallResponse> callback)
        {
            return await Task.Factory.StartNew<HttpCall>(() => Execute(Methods.Get, null, callback));
        }

        public async Task<HttpCall> Post<TResponseModelType>(object requestData, Action<CallResponse<TResponseModelType>> callback)
        {
            return await Task.Factory.StartNew<HttpCall>(() => Execute(Methods.Post, requestData, callback));
        }

        private HttpCall Execute(string method, object requestData, Action<CallResponse> callback)
        {
            return Execute<GenericDataModel>(method, requestData, r=> callback(r.ConvertToResponse()));
        }

        private HttpCall Execute<TResponseModelType>(string method, object requestData, Action<CallResponse<TResponseModelType>> callback)
        {
            _provider.CallWebUrl(Options, requestData, response =>
            {

            });
            return this;
        }
    }
}