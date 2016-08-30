using AngleSharp.Dom;
using System;
using Magpie.Library.Attributes;
using Magpie.Library.Http.Exceptions;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal class InnerTextValueProvider : ValueProviderBase
    {
        public InnerTextValueProvider(BindingProperty bindingProperty) : base(bindingProperty)
        {
        }

        public override object GetValue(IElement element, Type propertyType)
        {
            var attr = BindingProperty.Attribute as InnerTextBindingAttribute;
            if (attr == null)
            {
                throw new InvalidAttributeException(element, propertyType);
            }
            return Convert.ChangeType(element.TextContent, propertyType);
        }
    }
}
