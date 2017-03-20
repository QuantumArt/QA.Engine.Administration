using System.ComponentModel.DataAnnotations;
using QA.Core.Web;
using QA.Engine.Administration.WebApp.App_LocalResources;
using QA.Engine.Administration.WebApp.AppCode;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class AddSiteMapViewModel : QpViewModelBase
    {
        [Display(Name = "AddSiteMapViewModel_Title", ResourceType = typeof(ViewModelStrings))]
        [Required(ErrorMessageResourceName = "AddSiteMapViewModel_Title_Required", ErrorMessageResourceType = typeof(ViewModelStrings))]
        [StringLength(255, ErrorMessageResourceName = "AddSiteMapViewModel_Title_Required", ErrorMessageResourceType = typeof(ViewModelStrings))]
        public string Title { get; set; }

        [Display(Name = "AddSiteMapViewModel_Name", ResourceType = typeof(ViewModelStrings))]
        [Required(ErrorMessageResourceName = "AddSiteMapViewModel_Name_Required", ErrorMessageResourceType = typeof(ViewModelStrings))]
        [StringLength(255, ErrorMessageResourceName = "AddSiteMapViewModel_Name_Required", ErrorMessageResourceType = typeof(ViewModelStrings))]
        [RegularExpression("^[a-zA-Z0-9\\-_]{1,}$", ErrorMessageResourceName = "AddSiteMapViewModel_Name_Pattern", ErrorMessageResourceType = typeof(ViewModelStrings))]
        public string Name { get; set; }

        [Display(Name = "AddSiteMapViewModel_Type", ResourceType = typeof(ViewModelStrings))]
        [Required(ErrorMessageResourceName = "AddSiteMapViewModel_DiscriminatorId_Required", ErrorMessageResourceType = typeof(ViewModelStrings))]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "AddSiteMapViewModel_DiscriminatorId_Required", ErrorMessageResourceType = typeof(ViewModelStrings))]
        public int DiscriminatorId { get; set; }

        public int PreferredContentId { get; set; }

        public int? StructuralVersionParentId { get; set; }

        public int? ParentId { get; set; }

        public SiteMapViewModel Parent { get; set; }

        [Display(Name = "VersionType_Title", ResourceType = typeof(ViewModelStrings))]
        public VersionTypes VersionTypeId { get; set; }

        public bool IsVersion { get; set; }
    }
}
