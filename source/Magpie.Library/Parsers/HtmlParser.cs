using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using CsQuery;
using Magpie.Library.Parsers.ValueProviders;
using Magpie.Library.Parsers.ValueSetter;

namespace Magpie.Library.Parsers
{
    public class HtmlParser
    {
        private readonly CQ _dom;

        public HtmlParser(string inputHtml)
        {
            _dom = CQ.Create(inputHtml);
        }

        public HtmlParser(Stream htmlStream)
        {
            _dom = CQ.Create(htmlStream);
        }

        public IList<TModelType> ParseModelCollection<TModelType>()
            where TModelType : new()
        {
            var parsingModel = new ModelBuilder<TModelType>().BuildParsingModel();
            return CreateModelCollection<TModelType>(parsingModel);
        }

        public TModelType ParseModel<TModelType>()
            where TModelType : new()
        {
            var parsingModel = new ModelBuilder<TModelType>().BuildParsingModel();
            return ParseModel<TModelType>(parsingModel);
        }

        public TModelType ParseModel<TModelType>(ParseModel parsingModel)
            where TModelType : new()
        {
            return CreateSingleModel<TModelType>(parsingModel, _dom);
        }

        private IList<TModelType> CreateModelCollection<TModelType>(ParseModel parsingModel)
            where TModelType : new()
        {
            return CreateModelCollection(parsingModel, typeof(TModelType)).Cast<TModelType>().ToList();
        }

        private IList<object> CreateModelCollection(ParseModel parsingModel, Type modelType)
        {
            MultipleParseModel multipleModel = parsingModel as MultipleParseModel;
            Debug.Assert(multipleModel != null);
            var context = _dom.Select(multipleModel.Selector);
            return context.Select(e => CreateSingleModel(parsingModel, new CQ(e.OuterHTML),
                                                                    Activator.CreateInstance(modelType))).ToList();
        }

        private TModelType CreateSingleModel<TModelType>(ParseModel parsingModel, CQ domModel)
            where TModelType : new()
        {
            return (TModelType)CreateSingleModel(parsingModel, domModel, new TModelType());
        }

        private object CreateSingleModel(ParseModel parsingModel, CQ domModel, object instance)
        {
            var instanceType = instance.GetType();
            var valueSetter = ValueSetterFactory.GetSetter(instanceType);

            foreach (var bindingProperty in parsingModel.Properties)
            {
                var element = domModel.Select(bindingProperty.Selector).FirstElement();
                var value = ValueProviderFactory
                                .GetProvider(bindingProperty)
                                .GetValue(element, bindingProperty.PropertyType);
                valueSetter.SetValue(bindingProperty.PropertyName, instance, value);
            }

            return instance;
        }
    }
}