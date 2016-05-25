using System;
using CsQuery;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal class NullValueProvider : ValueProviderBase
    {
        public NullValueProvider()
            : base(null)
        { }

        public override object GetValue(CQ element, Type propertyType)
        {
            return propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;
        }
    }
}
