using System.Threading.Tasks;

namespace Magpie.Library.Http.Providers
{
    public interface IHttpProvider
    {
        Task<HttpResponse> CallWebPage(HttpOptions options);
    }
}