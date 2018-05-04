using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Dynamic;

namespace WebApplication.Models
{
    public class AppSettingsWrapper : DynamicObject
    {
        public NameValueCollection items;
        public string []itemAntigo;

        public AppSettingsWrapper()
        {
            items = ConfigurationManager.AppSettings;
        }

        public AppSettingsWrapper(string arquivo)
        {
            Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/" + arquivo);
            AppSettingsSection appsettings = (AppSettingsSection)objConfig.GetSection("appSettings");

            itemAntigo = appsettings.Settings.AllKeys;
        }
    }
}