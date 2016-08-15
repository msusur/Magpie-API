using System;
// TODO: Removed for dotnetcore migration
//using CsQuery;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal class NullValueProvider : ValueProviderBase
    {
        public NullValueProvider()
            : base(null)
        { }

        public override object GetValue(IDomElement element, Type propertyType)
        {
            return propertyType.IsValueType ? Activator.CreateInstance(propertyType) : null;
        }
    }
}
