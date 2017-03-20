using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class ReorderViewModel : QpViewModelBase
    {
        public int ItemId { get; set; }

        public int RelatedItemId { get; set; }

        public bool IsInsertBefore { get; set; }
    }
}
