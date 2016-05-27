using System;

namespace Magpie.Library.Http.Providers
{
    public interface IHttpProvider
    {
        //// spending time on this YAGNI, remarkable...
        //void CallWebUrl<TResponseModel>(string method, HttpOptions options, object data, Action<CallResponse> callback);

        void CallWebPage(HttpOptions options, Action<HtmlResponse> callback);
    }
}