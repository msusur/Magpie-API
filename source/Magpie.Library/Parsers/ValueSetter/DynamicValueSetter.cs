namespace Magpie.Library.Parsers.ValueSetter
{
    internal class DynamicValueSetter : ValueSetterBase
    {
        internal override void SetValue(string propertyName, object instance, object value)
        {
            dynamic obj = instance;
            obj[propertyName] = value;
        }
    }
}