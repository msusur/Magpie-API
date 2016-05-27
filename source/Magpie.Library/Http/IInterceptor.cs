using System.Net.Http;

namespace Magpie.Library.Http
{
    public abstract class BaseInterceptor
    {
        public virtual void BeforeCall(HttpCallContext context)
        {
        }

        public virtual void AfterCall(HttpCallContext context)
        {
        }
    }

    public class HttpCallContext
    {
        public HttpOptions Options { get; set; }
        public HttpClient Client { get; set; }
        public HttpResponse Response { get; set; }
    }
}