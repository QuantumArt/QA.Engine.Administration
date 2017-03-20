using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class MoveItemViewModel : QpViewModelBase
    {
        public int ItemId { get; set; }

        public int NewParentId { get; set; }
    }
}
