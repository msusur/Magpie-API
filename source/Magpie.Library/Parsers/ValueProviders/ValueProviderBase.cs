using AngleSharp.Dom;
using System;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal abstract class ValueProviderBase
    {
        protected BindingProperty BindingProperty { get; private set; }

        public ValueProviderBase(BindingProperty bindingProperty)
        {
            BindingProperty = bindingProperty;
        }

        public abstract object GetValue(IElement element, Type propertyType);
    }
}
