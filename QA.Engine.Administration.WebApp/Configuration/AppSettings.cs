using System.Configuration;

namespace QA.Engine.Administration.WebApp.Configuration
{
    public class AppSettings
    {

        static int GetInt(string key, int? defaultValue = null)
        {
            var val = ConfigurationManager.AppSettings[key];
            int result;
            if (int.TryParse(val, out result))
            {
                return result;
            }

            return defaultValue ?? result;
        }

        public static bool IsViewSiteList
        {
            get
            {
                bool result;
                bool.TryParse(ConfigurationManager.AppSettings["SiteConfiguration.IsViewSiteList"], out result);
                return result;
            }
        }

        public static int DefaultPageSize => GetInt("SiteConfiguration.DefaultPageSize");

        public static int RegionStringLetterCount => GetInt("SiteConfiguration.RegionStringLetterCount");

        public static int ItemPreviewCustomActionId => GetInt("ItemPreview.CustomActionId");

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



        /// <summary>
        /// Проверять обновление маппингов, не чаще чем значение CheckMappingUpdatePeriodicity (сек)
        /// </summary>
        public static int CheckMappingUpdatePeriodicity => GetInt("CheckMappingUpdatePeriodicity", 300);

        public static int MappingCacheTime => GetInt("MappingCacheTime", 300);


    }
}
