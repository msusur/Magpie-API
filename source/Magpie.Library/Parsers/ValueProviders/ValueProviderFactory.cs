using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers.ValueProviders
{
    internal static class ValueProviderFactory
    {
        public static ValueProviderBase GetProvider(BindingProperty bindingProperty)
        {
            if (bindingProperty.Attribute is AttributeBindingAttribute)
            {
                return new AttributeValueProvider(bindingProperty);
            }
            if (bindingProperty.Attribute is InnerTextBindingAttribute)
            {
                return new InnerTextValueProvider(bindingProperty);
            }

            return new NullValueProvider();
        }
    }
}