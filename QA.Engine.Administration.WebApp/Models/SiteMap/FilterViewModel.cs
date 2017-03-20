using QA.Core.Engine.QPData;
using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class FilterViewModel : QpViewModelBase
    {
        public int? ParentId { get; set; }

        public int? CultureId { get; set; }

        public string Regions { get; set; }

        public bool IsArchive { get; set; }

        public SiteMapItemType Type { get; set; }
    }
}
