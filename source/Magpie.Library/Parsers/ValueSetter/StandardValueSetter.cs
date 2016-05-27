using System.Collections.Generic;
using System.Reflection;

namespace Magpie.Library.Parsers.ValueSetter
{
    internal class StandardValueSetter : ValueSetterBase
    {
        private readonly Dictionary<string, PropertyInfo> _properties;

        public StandardValueSetter(Dictionary<string, PropertyInfo> properties)
        {
            _properties = properties;
        }

        internal override void SetValue(string propertyName, object value, object value)
        {
            var propertyInfo = _properties[propertyName];
            propertyInfo.SetValue(value, value);
        }
    }
}