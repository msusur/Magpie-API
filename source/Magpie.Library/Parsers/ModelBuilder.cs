using System;
using System.Collections.Concurrent;
using System.Linq;
using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers
{
    internal class ModelBuilder<TModelType>
    {
        // ReSharper disable once StaticMemberInGenericType
        private static readonly Lazy<ConcurrentDictionary<string, ParseModel>> ModelCache =
            new Lazy<ConcurrentDictionary<string, ParseModel>>();

        public ParseModel BuildParsingModel()
        {
            var type = typeof(TModelType);
            return ModelCache.Value.GetOrAdd(type.FullName, GenerateModel);
        }

        private ParseModel GenerateModel(string key)
        {
            var type = typeof(TModelType);
            ParseModel model = ParseModelBuilder.Build(type);

            foreach (var propertyInfo in type.GetProperties())
            {
                var attribute = propertyInfo
                    .GetCustomAttributes(typeof(HtmlBindingAttribute), true)
                    .Cast<HtmlBindingAttribute>().FirstOrDefault();

                if (attribute == null)
                {
                    continue;
                }

                var propertyName = propertyInfo.Name;

                model.Properties.Add(new BindingProperty(propertyName, attribute, propertyInfo.PropertyType));
            }
            model.Type = typeof(TModelType);
            return model;
        }
    }
}