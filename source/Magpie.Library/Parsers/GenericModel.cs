using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Magpie.Library.Parsers
{
    public class GenericModel : DynamicObject, IEnumerable<KeyValuePair<string, object>>
    {
        private readonly Dictionary<string, object> _innerDictionary = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            _innerDictionary.TryGetValue(binder.Name, out result);

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var contains = _innerDictionary.ContainsKey(binder.Name);
            if (contains)
            {
                _innerDictionary[binder.Name] = value;
            }
            else
            {
                _innerDictionary.Add(binder.Name, value);
            }
            return true;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _innerDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
