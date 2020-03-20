using System.Collections.Generic;
using System.Linq;

namespace Dort.RepositoryImpl.Database
{
    internal class PropertyContainer
    {
        private readonly Dictionary<string, object> _ids;
        private readonly Dictionary<string, object> _values;

        internal string TableName { get; set; }

        internal IEnumerable<string> IdNames => _ids.Keys;

        internal IEnumerable<string> ValueNames => _values.Keys;

        internal IEnumerable<string> AllNames => _ids.Keys.Union(_values.Keys);

        internal IDictionary<string, object> IdPairs => _ids;

        internal IDictionary<string, object> ValuePairs => _values;

        internal IEnumerable<KeyValuePair<string, object>> AllPairs => _ids.Concat(_values);

        internal PropertyContainer()
        {
            _ids = new Dictionary<string, object>();
            _values = new Dictionary<string, object>();
        }

        internal void AddId(string name, object value)
        {
            _ids.Add(name, value);
        }

        internal void AddValue(string name, object value)
        {
            _values.Add(name, value);
        }
    }
}
