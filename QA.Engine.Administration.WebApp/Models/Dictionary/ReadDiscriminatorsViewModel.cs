using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.Dictionary
{
    public class ReadDiscriminatorsViewModel : QpViewModelBase
    {
        public int ParentId { get; set; }

        public bool? IsPage { get; set; }
    }
}
