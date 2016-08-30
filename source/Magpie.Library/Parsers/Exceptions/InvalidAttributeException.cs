using System;
using AngleSharp.Dom;
using AngleSharp.Extensions;

namespace Magpie.Library.Http.Exceptions
{
    public class InvalidAttributeException : Exception
    {
        public InvalidAttributeException(IElement element, Type propertyType)
            : base($"Invalid attribute for type: '{propertyType.FullName}' and element: {element.ToHtml()}")
        { }
    }
}
