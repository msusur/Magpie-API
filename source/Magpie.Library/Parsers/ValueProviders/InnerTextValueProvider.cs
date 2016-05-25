using System;
using System.Diagnostics;
using CsQuery;
using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal class InnerTextValueProvider : ValueProviderBase
    {
        public InnerTextValueProvider(BindingProperty bindingProperty) : base(bindingProperty)
        {
        }

        public override object GetValue(IDomElement element, Type propertyType)
        {
            var attr = BindingProperty.Attribute as InnerTextBindingAttribute;
            Debug.Assert(attr != null);
            return Convert.ChangeType(element.InnerText, propertyType);
        }
    }
}
