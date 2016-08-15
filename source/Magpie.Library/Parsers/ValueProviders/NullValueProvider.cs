using AngleSharp.Dom;
using System;
using System.Reflection;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal class NullValueProvider : ValueProviderBase
    {
        public NullValueProvider()
            : base(null)
        { }

        public override object GetValue(IElement element, Type propertyType)
        {
            return propertyType.GetTypeInfo().IsValueType ? Activator.CreateInstance(propertyType) : null;
        }
    }
}
