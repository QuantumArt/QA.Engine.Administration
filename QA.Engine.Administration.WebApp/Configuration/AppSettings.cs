using System.Configuration;

namespace QA.Engine.Administration.WebApp.Configuration
{
    public class AppSettings
    {
        public static bool IsViewSiteList
        {
            get
            {
                bool result;
                bool.TryParse(ConfigurationManager.AppSettings["SiteConfiguration.IsViewSiteList"], out result);
                return result;
            }
        }

        public static int DefaultPageSize
        {
            get
            {
                int result;
                int.TryParse(ConfigurationManager.AppSettings["SiteConfiguration.DefaultPageSize"], out result);
                return result;
            }
        }

        public static int RegionStringLetterCount
        {
            get
            {
                int result;
                int.TryParse(ConfigurationManager.AppSettings["SiteConfiguration.RegionStringLetterCount"], out result);
                return result;
            }
        }

        public static int ItemPreviewCustomActionId
        {
            get
            {
                var val = ConfigurationManager.AppSettings["ItemPreview.CustomActionId"];
                int result;
                int.TryParse(val, out result);
                return result;
            }
        }

        public static int ReorderItemStep
        {
            get
            {
                int result = 1;
                int.TryParse(ConfigurationManager.AppSettings["ReorderItemStep"], out result);
                return result != 0 ? result : 10 ;
            }
        }

        public static string ItemPreviewUrlSuffix => ConfigurationManager.AppSettings["ItemPreview.UrlSuffix"];

        public static string ItemPreviewItemIdParamName => ConfigurationManager.AppSettings["ItemPreview.ItemIdParamName"];

        public static string ItemPreviewChosenRegionParamName => ConfigurationManager.AppSettings["ItemPreview.ChosenRegionParamName"];

        public static string ItemPreviewChosenCultureParamName => ConfigurationManager.AppSettings["ItemPreview.ChosenCultureParamName"];
    }
}
