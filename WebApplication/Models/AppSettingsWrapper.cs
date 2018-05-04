using System.Collections.Specialized;
using System.Configuration;
using System.Dynamic;

namespace WebApplication.Models
{
    public class AppSettingsWrapper : DynamicObject
    {
        public NameValueCollection _items;

        public AppSettingsWrapper()
        {
            _items = ConfigurationManager.AppSettings;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = _items[binder.Name];
            return result != null;
        }
    }
}