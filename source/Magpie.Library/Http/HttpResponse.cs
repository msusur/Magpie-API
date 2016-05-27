namespace Magpie.Library.Http
{
    public class HttpResponse
    {
        public string ResponseString { get; set; }

        public HttpResponse(string response)
        {
            ResponseString = response;
        }
    }
}