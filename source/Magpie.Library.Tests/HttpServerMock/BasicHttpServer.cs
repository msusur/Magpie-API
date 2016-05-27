using System;
using System.Net;
using System.Text;
using System.Threading;


namespace Magpie.Library.Tests.HttpServerMock
{
    public class BasicHttpServer : IDisposable
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> _responderMethod;

        private bool _disposed;

        public BasicHttpServer(string port, Func<HttpListenerRequest, string> method)
        {
            _listener.Prefixes.Add($"http://localhost:{port}/");
            _responderMethod = method;
            _listener.Start();
        }

        public BasicHttpServer(Func<HttpListenerRequest, string> method, string port)
            : this(port, method)
        { }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            if (ctx == null)
                            {
                                return;
                            }
                            try
                            {
                                string rstr = _responderMethod(ctx.Request);
                                byte[] buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch
                            { //avoid exceptions.
                            }
                            finally
                            {
                                // always close the stream
                                ctx?.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch
                {
                    //avoid exceptions.
                }
            });
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
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
