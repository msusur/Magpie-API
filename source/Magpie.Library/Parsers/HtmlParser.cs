using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CsQuery;
using Magpie.Library.Attributes;
using Magpie.Library.Parsers.ValueProviders;

namespace Magpie.Library.Parsers
{
    public class HtmlParser
    {
        private readonly CQ _dom;

        public HtmlParser(string inputHtml)
        {
            _dom = CQ.Create(inputHtml);
        }

        public IList<TModelType> ParseModelCollection<TModelType>()
        {
            return new List<TModelType>();
        }

        public TModelType ParseModel<TModelType>()
            where TModelType : new()
        {
            var parsingModel = new ModelBuilder<TModelType>().BuildParsingModel();
            return CreateModel<TModelType>(parsingModel);
        }

        private TModelType CreateModel<TModelType>(ParseModel parsingModel)
            where TModelType : new()
        {
            var instance = new TModelType();
            Type instanceType = typeof(TModelType);
            var properties = instanceType.GetProperties()
                .ToDictionary(p => p.Name);


            foreach (var bindingProperty in parsingModel.Properties)
            {
                var element = _dom.Select(bindingProperty.Selector);
                var value = ValueProviderFactory
                                .GetProvider(bindingProperty)
                                .GetValue(element, bindingProperty.PropertyType);
                var propertyInfo = properties[bindingProperty.PropertyName];
                propertyInfo.SetValue(instance, value);
            }

            return instance;
        }
    }

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