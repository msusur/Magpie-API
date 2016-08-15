using System;
// TODO: Need to rewrite it using Microsoft.AspNetCore.Server.Kestrel.KestrelHttpServer...


namespace Magpie.Library.Tests.HttpServerMock
{
    public class BasicHttpServer : IDisposable
    {
        private bool _disposed;

        public BasicHttpServer Run()
        {
           return this;
        }

        public void Stop()
        {
           
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            if (_disposed)
            {
                throw new ObjectDisposedException("WebServer");
            }

            Stop();
            _disposed = true;
        }
    }
}
