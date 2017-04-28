using QA.Engine.Administration.Services;
using Quantumart.QPublishing.Database;

namespace QA.Engine.Administration.WebApp.Configuration
{
    public class QPSiteConfiguratioFactory : ISiteConfiguratioFactory
    {
        private readonly IQpSettingsService _qpSettingsService;
        public QPSiteConfiguratioFactory(IQpSettingsService qpSettingsService)
        {
            _qpSettingsService = qpSettingsService;
        }

        public SiteConfiguration Create(string customerCode, int siteId)
        {
            var connectionString = GetConnectionString(customerCode);
            var useHierarchyRegionsFilter = _qpSettingsService.GetSetting(connectionString, "USE_HIERARCHY_REGIONS_FILTER");
            SiteConfiguration config = new SiteConfiguration
            {
                UseHierarchyRegionsFilter = useHierarchyRegionsFilter != null && useHierarchyRegionsFilter.ToLower() == "true",
                ConnectionString = connectionString,
                SiteId = siteId,
                PublishStatusImageUrl = "/Content/icons/pub.png",
                CreatedStatusImageUrl = "/Content/icons/new.jpg",
            };
            
            return config;
        }


        protected virtual string GetConnectionString(string customerCode)
        {
            return DBConnector.GetConnectionString(customerCode);
        }
    }
}