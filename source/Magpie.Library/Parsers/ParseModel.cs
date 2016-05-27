using System;
using System.Collections.Generic;
using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers
{
    public abstract class ParseModel
    {
        public IList<BindingProperty> Properties { get; } = new List<BindingProperty>();
    }

    public sealed class DynamicParseModel : ParseModel
    {
        public void AddProperty(string name, string selector, Type type)
        {
            var innerTextBindingAttribute = new InnerTextBindingAttribute
            {
                Selector = selector

            };
            Properties.Add(new BindingProperty(name, innerTextBindingAttribute, type));
        }

        public void AddProperty(string name, string selector, Type type, string attributeName)
        {
            var attributeBindingAttribute = new AttributeBindingAttribute
            {
                AttributeName = attributeName,
                Selector = selector
            };
            Properties.Add(new BindingProperty(name, attributeBindingAttribute, type));
        }
    }

    public abstract class StronglyTypedParseModel : ParseModel
    {
        public Type Type { get; set; }
    }
}