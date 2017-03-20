using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class DeleteSiteMapRegionViewModel : QpViewModelBase
    {
        public int Id { get; set; }

        public int RegionId { get; set; }
    }
}
