using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class ReadSiteMapItemViewModel : QpViewModelBase
    {
        public int Id { get; set; }

        public bool IsIncludeChildrenCount { get; set; }
    }
}
