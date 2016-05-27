using System;

namespace Magpie.Library.Http.Providers
{
    public interface IHttpProvider
    {
        void CallWebUrl(HttpOptions options, object data, Action<CallResponse> callback);
    }
}