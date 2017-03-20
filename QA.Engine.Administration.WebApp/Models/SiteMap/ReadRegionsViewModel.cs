using QA.Core.Web;
using QA.Engine.Administration.WebApp.Models.Kendo;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class ReadRegionsViewModel : QpViewModelBase
    {
        public string Text { get; set; }

        public int Id { get; set; }

        // TODO: fix naming
        public KendoFilterViewModel filter { get; set; }

        public int PageIndex { get; set; }
    }
}
