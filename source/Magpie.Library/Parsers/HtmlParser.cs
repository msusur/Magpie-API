using System.Collections.Generic;
using System.Linq;
using CsQuery;
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
            var parsingModel = new ModelBuilder<TModelType>().BuildParsingModel();
            return CreateModelCollection<TModelType>(parsingModel);
        }

        public TModelType ParseModel<TModelType>()
            where TModelType : new()
        {
            var parsingModel = new ModelBuilder<TModelType>().BuildParsingModel();
            return CreateSingleModel<TModelType>(parsingModel, _dom);
        }

        private IList<TModelType> CreateModelCollection<TModelType>(ParseModel parsingModel)
        {
            var list = new List<TModelType>();
            MultipleParseModel multipleModel = parsingModel as MultipleParseModel;

            return list;
        }

        private TModelType CreateSingleModel<TModelType>(ParseModel parsingModel, CQ domModel)
            where TModelType : new()
        {
            var instance = new TModelType();
            var instanceType = typeof(TModelType);
            var properties = instanceType.GetProperties()
                .ToDictionary(p => p.Name);


            foreach (var bindingProperty in parsingModel.Properties)
            {
                var element = domModel.Select(bindingProperty.Selector);
                var value = ValueProviderFactory
                                .GetProvider(bindingProperty)
                                .GetValue(element, bindingProperty.PropertyType);
                var propertyInfo = properties[bindingProperty.PropertyName];
                propertyInfo.SetValue(instance, value);
            }

            return instance;
        }
    }
}