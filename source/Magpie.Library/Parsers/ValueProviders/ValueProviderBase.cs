using System;
// TODO: Removed for dotnetcore migration
// using CsQuery;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal abstract class ValueProviderBase
    {
        protected BindingProperty BindingProperty { get; private set; }

        public ValueProviderBase(BindingProperty bindingProperty)
        {
            BindingProperty = bindingProperty;
        }

        public abstract object GetValue(IDomElement element, Type propertyType);
    }
}
