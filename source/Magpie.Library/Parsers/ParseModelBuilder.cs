using System;
using System.Linq;
using System.Reflection;
using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers
{
    internal static class ParseModelBuilder
    {
        public static StronglyTypedParseModel Build(Type type)
        {
            var firstAttribute =
                type.GetTypeInfo().GetCustomAttributes(typeof(CollectionBindingAttribute), true)
                    .Cast<CollectionBindingAttribute>()
                    .FirstOrDefault();
            if (firstAttribute == null)
            {
                return new SingleParseModel();
            }
            return new MultipleParseModel(firstAttribute.Selector);
        }
    }
}