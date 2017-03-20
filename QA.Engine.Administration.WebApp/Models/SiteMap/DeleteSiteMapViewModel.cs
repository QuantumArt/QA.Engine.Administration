using System.ComponentModel.DataAnnotations;
using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class DeleteSiteMapViewModel : QpViewModelBase
    {
        [Display(Name = "DeleteVersions_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public bool? IsDeleteAllVersions { get; set; }

        public int Id { get; set; }

        public bool IsVersion { get; set; }

        public bool IsPage { get; set; }
    }
}
