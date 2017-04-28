using QA.Configuration;
using System.Configuration;

namespace QA.Engine.Administration.WebApp.Configuration
{
    public class ConfigurationServiceSiteConfiguratioFactory : ISiteConfiguratioFactory
    {

        private readonly IConfigurationService _configurationService;

        public ConfigurationServiceSiteConfiguratioFactory(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public SiteConfiguration Create(string customerCode, int siteId)
        {
            var config = _configurationService.GetConfiguration<SiteConfiguration>(customerCode);
            if (config != null)
            {
                config.ConnectionString = ConfigurationManager.ConnectionStrings[config.ConnectionName].ConnectionString;
            }
            return config;
        }
    }
}