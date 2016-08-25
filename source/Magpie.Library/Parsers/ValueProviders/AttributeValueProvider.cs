using AngleSharp.Dom;
using System;
using System.Diagnostics;
using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal class AttributeValueProvider : ValueProviderBase
    {
        public AttributeValueProvider(BindingProperty bindingProperty)
            : base(bindingProperty)
        { }

        public override object GetValue(IElement element, Type propertyType)
        {
            var htmlBindingAttribute = BindingProperty.Attribute as AttributeBindingAttribute;
            Debug.Assert(htmlBindingAttribute != null);

            return Convert.ChangeType(element.GetAttribute(htmlBindingAttribute.AttributeName), propertyType);
        }
    }
}
