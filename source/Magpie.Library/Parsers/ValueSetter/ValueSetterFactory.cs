using System;
using System.Dynamic;
using System.Linq;

namespace Magpie.Library.Parsers.ValueSetter
{
    internal static class ValueSetterFactory
    {
        public static ValueSetterBase GetSetter(Type instanceType)
        {
            var properties = instanceType.GetProperties().ToDictionary(p => p.Name);
            var isDynamic = typeof(DynamicObject).IsAssignableFrom(instanceType);
            if (isDynamic)
            {
                return new DynamicValueSetter();
            }
            return new StandardValueSetter(properties);
        }
    }
}