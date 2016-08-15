using System;
using System.Reflection;
using System.Dynamic;
using System.Linq;

namespace Magpie.Library.Parsers.ValueSetter
{
    internal static class ValueSetterFactory
    {
        public static ValueSetterBase GetSetter(Type instanceType)
        {
            var properties = instanceType.GetTypeInfo().GetProperties().ToDictionary(p => p.Name);
            var isDynamic = typeof(DynamicObject).GetTypeInfo().IsAssignableFrom(instanceType);
            if (isDynamic)
            {
                return new DynamicValueSetter();
            }
            return new StandardValueSetter(properties);
        }
    }
}