using System;
using System.Web;
using QA.Configuration;
using QA.Core;
using QA.Core.Service.Interaction;
using QA.Engine.Administration.Services;
using QA.Engine.Administration.WebApp.App_LocalResources;
using QA.Engine.Administration.WebApp.AppCode;

namespace QA.Engine.Administration.WebApp.Configuration
{
    public class SiteConfiguration
    {
        public string Name { get; set; }

        public string ConnectionName { get; set; }

        public string SiteDescription { get; set; }

        public int SiteId { get; set; }

        public string ContainerName { get; set; }

        public string PublishStatusImageUrl { get; set; }

        public string CreatedStatusImageUrl { get; set; }

        public bool IsEmptyRegionListIfNotSelected { get; set; }

        public bool UseHierarchyRegionsFilter { get; set; }

        public int RootPageId
        {
            get
            {
                var result = ClientUtils.Resolve<ISiteMapService>().GetRootPage(new UserContext());
                if (!result.IsSucceeded)
                {
                    Throws.Exception(result.Error.Message);
                }

                return result.Result?.Id ?? 0;
            }
        }

        [ThreadStatic]
        private static SiteConfiguration _current;

        private const string StorageKey = "CurrentSiteConfiguration";

        public static SiteConfiguration Current
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    if (_current == null)
                    {
                        Throws.Exception(string.Format(ErrorMessages.ErrorConfigurationMessage, string.Empty));
                    }

                    return _current;
                }

                if (HttpContext.Current.Items[StorageKey] == null)
                {
                    Throws.Exception(string.Format(ErrorMessages.ErrorConfigurationMessage, string.Empty));
                }

                return (SiteConfiguration)HttpContext.Current.Items[StorageKey];
            }
        }

        public static string CurrentName => Current.Name;

        public static SiteConfiguration Set(string name)
        {
            var service = ObjectFactoryBase.Resolve<IConfigurationService>();
            var item = service.GetConfiguration<SiteConfiguration>(name);
            if (item == null)
            {
                Throws.Exception(string.Format(ErrorMessages.ErrorConfigurationMessage, name));
            }

            item = service.GetConfiguration<SiteConfiguration>(name);
            if (HttpContext.Current == null)
            {
                _current = item;
            }
            else
            {
                HttpContext.Current.Items[StorageKey] = item;
            }

            return item;
        }
    }
}
