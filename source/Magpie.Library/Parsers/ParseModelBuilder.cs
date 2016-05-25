using System;
using System.Linq;
using Magpie.Library.Attributes;

namespace Magpie.Library.Parsers
{
    internal static class ParseModelBuilder
    {
        public static ParseModel Build(Type type)
        {
            var firstAttribute =
                type.GetCustomAttributes(typeof(CollectionBindingAttribute), true)
                    .Cast<CollectionBindingAttribute>()
                    .FirstOrDefault();
            if (firstAttribute == null)
            {
                return new SingleParseModel();
            }
            return new MultipleParseModel();
        }
    }
}