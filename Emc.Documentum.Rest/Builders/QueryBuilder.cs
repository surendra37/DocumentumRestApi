using System.Text;

namespace Emc.Documentum.Rest.Builders
{
    public class QueryBuilder
    {
        private StringBuilder _builder;
        public QueryBuilder()
        {
            _builder = new StringBuilder();
        }

        public QueryBuilder(string api)
        {
            _builder = new StringBuilder(api);
        }

        public QueryBuilder Select(params string[] names)
        {
            _builder.Append("Select ");
            _builder.Append(string.Join(",", names));
            return this;
        }

        public QueryBuilder From(string name)
        {
            _builder.AppendFormat(" from {0}", name);
            return this;
        }

        public string Build()
        {
            return _builder.ToString();
        }
    }
}
