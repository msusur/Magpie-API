using System;
using System.Diagnostics;
using CsQuery;
using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal class AttributeValueProvider : ValueProviderBase
    {
        public AttributeValueProvider(BindingProperty bindingProperty)
            : base(bindingProperty)
        { }

        public override object GetValue(CQ element, Type propertyType)
        {
            var htmlBindingAttribute = BindingProperty.Attribute as AttributeBindingAttribute;
            Debug.Assert(htmlBindingAttribute != null);

            return Convert.ChangeType(element.Attr(htmlBindingAttribute.AttributeName), propertyType);
        }
    }
}
