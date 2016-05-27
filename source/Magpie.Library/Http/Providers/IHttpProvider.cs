using System;
using System.Threading.Tasks;

namespace Magpie.Library.Http.Providers
{
    public interface IHttpProvider
    {
        //// spending time on this YAGNI, remarkable...
        //void CallWebUrl<TResponseModel>(string method, HttpOptions options, object data, Action<CallResponse> callback);

        Task<HttpResponse> CallWebPage(HttpOptions options);
    }
}