using System;
using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers
{
    internal class BindingProperty
    {
        public string PropertyName { get; private set; }
        public Type PropertyType { get; private set; }
        public string Selector => Attribute.Selector;
        public HtmlBindingAttribute Attribute { get; private set; }

        public BindingProperty(string propertyName, HtmlBindingAttribute attribute, Type propertyType)
        {
            PropertyName = propertyName;
            Attribute = attribute;
            PropertyType = propertyType;
        }
    }
}