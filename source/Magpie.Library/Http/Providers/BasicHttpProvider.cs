using System;
using System.Net;

namespace Magpie.Library.Http.Providers
{
    public class BasicHttpProvider : IHttpProvider
    {
        public void CallWebUrl(HttpOptions options, object data, Action<CallResponse> callback)
        {
            using (WebRequest request = HttpWebRequest.Create())
            {
                
            }
        }
    }
}
