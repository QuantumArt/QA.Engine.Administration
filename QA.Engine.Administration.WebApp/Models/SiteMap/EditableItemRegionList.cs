using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class EditableItemRegionList : QpViewModelBase
    {
        public int Id { get; set; }

        public int[] SelectedRegionIDs { get; set; }
    }
}
