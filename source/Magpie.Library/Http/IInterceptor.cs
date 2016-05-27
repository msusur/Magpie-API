namespace Magpie.Library.Http
{
    public abstract class BaseInterceptor
    {
        public virtual void BeforeCall(HttpOptions options)
        {
        }

        public virtual void AfterCall(HttpOptions options, CallResponse response)
        {
        }
    }
}