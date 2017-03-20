using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using QA.Core.Web;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class EditableSiteMapViewModel : QpViewModelBase
    {
        [Display(Name = "AddSiteMapViewModel_Title", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        [Required(ErrorMessageResourceName = "AddSiteMapViewModel_Title_Required", ErrorMessageResourceType = typeof(App_LocalResources.ViewModelStrings))]
        [StringLength(255, ErrorMessageResourceName = "AddSiteMapViewModel_Title_Required", ErrorMessageResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public string Title { get; set; }

        [Display(Name = "AddSiteMapViewModel_Name", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        [Required(ErrorMessageResourceName = "AddSiteMapViewModel_Name_Required", ErrorMessageResourceType = typeof(App_LocalResources.ViewModelStrings))]
        [StringLength(255, ErrorMessageResourceName = "AddSiteMapViewModel_Name_Required", ErrorMessageResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public string Name { get; set; }

        [Display(Name = "AddSiteMapViewModel_Type", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        [Required(ErrorMessageResourceName = "AddSiteMapViewModel_DiscriminatorId_Required", ErrorMessageResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public int DiscriminatorId { get; set; }

        public List<SelectListItem> Discriminators { get; set; }

        public int? ParentId { get; set; }

        [Display(Name = "AddSiteMapViewModel_Id", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public int Id { get; set; }

        public string TypeName { get; set; }

        [Display(Name = "AddSiteMapViewModel_State", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public string ItemStateName { get; set; }

        [Display(Name = "AddSiteMapViewModel_Culture", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public string CultureName { get; set; }

        [Display(Name = "AddSiteMapViewModel_Visible", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public virtual bool IsVisible { get; set; }

        [Display(Name = "AddSiteMapViewModel_InSitemap", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public virtual bool IsInSitemap { get; set; }

        public string Icon { get; set; }

        [Display(Name = "AddSiteMapViewModel_ElementType", ResourceType = typeof(App_LocalResources.ViewModelStrings))]
        public string ElementTypeName { get; set; }
    }
}
