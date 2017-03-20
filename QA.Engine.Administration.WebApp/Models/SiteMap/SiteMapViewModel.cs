using System.Collections.Generic;
using QA.Core.Web;
using QA.Engine.Administration.WebApp.Models.Dictionary;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class SiteMapViewModel : QpViewModelBase
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string StatusName { get; set; }

        public string StatusIcon { get; set; }

        public string RegionsString { get; set; }

        public List<RegionViewModel> Regions { get; set; }

        public string Title { get; set; }

        public string View => Title + " (" + Id + ")";

        public string Culture { get; set; }

        public string CultureId { get; set; }

        public bool IsVersion { get; set; }

        public bool IsVisible { get; set; }

        public virtual bool IsVisibility { get; set; }

        public bool IsPage { get; set; }

        public bool HasChildren { get; set; }

        public bool HasContentVersions { get; set; }

        public string ZoneName { get; set; }

        public string DiscriminatorName { get; set; }

        public string DiscriminatorTitle { get; set; }

        public int SortOrder { get; set; }

        public string SortOrderView => SortOrder == int.MaxValue ? null : SortOrder.ToString();

        public int DiscriminatorId { get; set; }

        public int? ExtensionId { get; set; }

        public int? VersionOfId { get; set; }
    }
}
