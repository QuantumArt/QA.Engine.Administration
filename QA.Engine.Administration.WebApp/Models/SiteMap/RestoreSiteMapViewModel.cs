using System.ComponentModel.DataAnnotations;
using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class RestoreSiteMapViewModel : QpViewModelBase
    {
        public int Id { get; set; }

        [Display(Name = "RestoreVersions_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public bool? IsRestoreAllVersions { get; set; }

        [Display(Name = "RestoreWidgets_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public bool? IsRestoreWidgets { get; set; }

        [Display(Name = "RestoreContentVersions_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public bool? IsRestoreContentVersions { get; set; }

        public bool IsVersion { get; set; }

        public bool IsPage { get; set; }

        [Display(Name = "RestoreChildren_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public bool? IsRestoreAllChildren { get; set; }
    }
}
