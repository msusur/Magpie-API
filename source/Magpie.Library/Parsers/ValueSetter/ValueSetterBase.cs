namespace Magpie.Library.Parsers.ValueSetter
{
    internal abstract class ValueSetterBase
    {
        internal abstract void SetValue(string propertyName, object instance, object value);
    }
}