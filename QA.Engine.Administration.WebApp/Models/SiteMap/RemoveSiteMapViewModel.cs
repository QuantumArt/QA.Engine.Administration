using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using QA.Core.Web;
using QA.Engine.Administration.WebApp.AppCode;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class RemoveSiteMapViewModel : QpViewModelBase
    {
        [Display(Name = "ContentVersionOperation_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public ContentVersionOperations OperationsByContentVersion { get; set; }

        [Display(Name = "DeleteVersions_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public bool? IsDeleteAllVersions { get; set; }

        [Display(Name = "VersionToReplace_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        [RequiredIf("OperationsByContentVersion", ContentVersionOperations.Move, ErrorMessageResourceName = "DeleteSiteMapViewModel_ContentVersionId_RequiredIf", ErrorMessageResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public int? ContentVersionId { get; set; }

        public List<SelectListItem> ContentVersions { get; set; }

        public int Id { get; set; }

        public bool IsVersion { get; set; }
    }
}
