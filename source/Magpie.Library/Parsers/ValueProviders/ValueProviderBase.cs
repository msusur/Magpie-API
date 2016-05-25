using System;
using CsQuery;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal abstract class ValueProviderBase
    {
        protected BindingProperty BindingProperty { get; private set; }

        public ValueProviderBase(BindingProperty bindingProperty)
        {
            BindingProperty = bindingProperty;
        }

        public abstract object GetValue(CQ element, Type propertyType);
    }
}
