using System;

namespace Magpie.Library.Http.Exceptions
{
    public class InvalidUrlException : Exception
    {
        public InvalidUrlException(string url)
            : base($"Url is invalid: '{url}'")
        { }
    }
}
