using System.Collections.Generic;

namespace Magpie.Library.Http
{
    public class HttpOptions
    {
        public string TargetUrl { get; set; }
        public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();
        public IList<BaseInterceptor> Interceptors { get; } = new List<BaseInterceptor>();
    }
}