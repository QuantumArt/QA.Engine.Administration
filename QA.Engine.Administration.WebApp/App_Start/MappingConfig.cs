using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA.Core;
using QA.Core.Engine;
using QA.Engine.Administration.Dto;
using QA.Engine.Administration.WebApp.App_LocalResources;
using QA.Engine.Administration.WebApp.Configuration;
using QA.Engine.Administration.WebApp.Models.Dictionary;
using QA.Engine.Administration.WebApp.Models.SiteMap;

namespace QA.Engine.Administration.WebApp.App_Start
{
    internal class MappingConfig
    {
        internal static void RegisterMappings()
        {
            ConfigureAbstractItemMapping();
            ConfigureDiscriminatorMapping();
            ConfigureRegionMapping();
            ConfigureCultureMapping();
        }

        internal static void ConfigureAbstractItemMapping()
        {
            MappingHelper.CreateMap<AbstractItem, SiteMapViewModel>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.ParentId, s => s.MapFrom(m => m.Parent?.Id ?? 0))
                .ForMember(d => d.Name, s => s.MapFrom(m => m.Name))
                .ForMember(d => d.Title, s => s.MapFrom(m => m.Title))
                .ForMember(d => d.IsVisible, s => s.MapFrom(m => m.IsVisible))
                .ForMember(d => d.IsVisibility, s => s.MapFrom(m => m.IsVisibility))
                .ForMember(d => d.StatusIcon, s => s.MapFrom(m => ItemStateImage(m.State)))
                .ForMember(d => d.StatusName, s => s.MapFrom(m => m.State.GetDescription()))
                .ForMember(d => d.Icon, s => s.MapFrom(m => m.IconUrl))
                .ForMember(d => d.RegionsString, s => s.MapFrom(m =>
                 {
                     var str = m.Regions == null
                         ? string.Empty
                         : string.Join(", ", m.Regions.OrderBy(o => o.Alias).Select(r => r.Alias ?? r.Title).ToList());

                     if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str) || str.Length == 0 || str.Length <= AppSettings.RegionStringLetterCount)
                     {
                         return str;
                     }

                     return str.Substring(0, AppSettings.RegionStringLetterCount) + "...";
                 }))
                .ForMember(d => d.Regions, s => s.MapFrom(m => m.Regions?.ToList() ?? new List<Region>()))
                .ForMember(d => d.Culture, s => s.MapFrom(m => m.Culture == null ? string.Empty : m.Culture.Key))
                .ForMember(d => d.CultureId, s => s.MapFrom(m => m.Culture?.Id.ToString() ?? string.Empty))
                .ForMember(d => d.IsVersion, s => s.MapFrom(m => m.VersionOfId != null))
                .ForMember(d => d.VersionOfId, s => s.MapFrom(m => m.VersionOfId))
                .ForMember(d => d.IsPage, s => s.MapFrom(m => m.IsPage))
                .ForMember(d => d.ZoneName, s => s.MapFrom(m => m.ZoneName))
                .ForMember(d => d.SortOrder, s => s.MapFrom(m => m.SortOrder))
                .ForMember(d => d.DiscriminatorName, s => s.MapFrom(m => m.DiscriminatorName))
                .ForMember(d => d.DiscriminatorId, s => s.MapFrom(m => m.DiscriminatorId))
                .ForMember(d => d.DiscriminatorTitle, s => s.MapFrom(m => m.DiscriminatorTitle))
                .ForMember(d => d.ExtensionId, s => s.MapFrom(m => m.ExtensionId));

            MappingHelper.CreateMap<AbstractItem, DeleteSiteMapViewModel>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.IsVersion, s => s.MapFrom(m => m.VersionOfId != null))
                .ForMember(d => d.IsPage, s => s.MapFrom(m => m.IsPage));

            MappingHelper.CreateMap<AbstractItem, RestoreSiteMapViewModel>()
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.IsVersion, s => s.MapFrom(m => m.VersionOfId != null))
                .ForMember(d => d.IsPage, s => s.MapFrom(m => m.IsPage));

            MappingHelper.CreateMap<AbstractItem, EditableSiteMapViewModel>()
                .ForMember(d => d.Name, s => s.MapFrom(m => m.Name))
                .ForMember(d => d.Title, s => s.MapFrom(m => m.Title))
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Icon, s => s.MapFrom(m => m.IconUrl))
                .ForMember(d => d.TypeName, s => s.MapFrom(m => m.DiscriminatorTitle))
                .ForMember(d => d.ItemStateName, s => s.MapFrom(m => m.State.GetDescription()))
                .ForMember(d => d.IsVisible, s => s.MapFrom(m => m.IsVisible))
                .ForMember(d => d.IsInSitemap, s => s.MapFrom(m => m.IsInSitemap))
                .ForMember(d => d.CultureName, s => s.MapFrom(m => m.Culture == null ? CommonStrings.NotSpecifiedText : m.Culture.Key))
                .ForMember(d => d.ElementTypeName, s => s.MapFrom(m => m.VersionOfId == null ? (m.IsPage ? CommonStrings.BaseSiteMapItemName : CommonStrings.WidgetItemName) : CommonStrings.ContentVersionItemName))
                .ForMember(d => d.ParentId, s => s.MapFrom(m => m.Parent?.Id));

            MappingHelper.CreateMap<AbstractItem, SelectListItem>()
                .ForMember(d => d.Text, s => s.MapFrom(m => m.Title + " (" + m.Id + ")"))
                .ForMember(d => d.Value, s => s.MapFrom(m => m.Id));
        }

        /// <summary>
        /// Настраивает маппинг типов разделов
        /// </summary>
        internal static void ConfigureDiscriminatorMapping()
        {
            MappingHelper.CreateMap<DiscriminatorDTO, SelectListItem>()
                .ForMember(d => d.Text, s => s.MapFrom(m => m.Title))
                .ForMember(d => d.Value, s => s.MapFrom(m => m.Id));

            MappingHelper.CreateMap<DiscriminatorDTO, DiscriminatorViewModel>()
                .ForMember(d => d.Title, s => s.MapFrom(m => m.Title))
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.PreferredContentId, s => s.MapFrom(m => m.PreferredContentId));

            MappingHelper.CreateMap<DiscriminatorConstraintDto, DiscriminatorConstraintViewModel>()
               .ForMember(d => d.SourceId, s => s.MapFrom(m => m.SourceId))
               .ForMember(d => d.TargetId, s => s.MapFrom(m => m.TargetId));
        }

        /// <summary>
        /// Настраивает маппинг регионов
        /// </summary>
        internal static void ConfigureRegionMapping()
        {
            MappingHelper.CreateMap<Region, SelectListItem>()
                .ForMember(d => d.Text, s => s.MapFrom(m => m.Title))
                .ForMember(d => d.Value, s => s.MapFrom(m => m.Id));

            MappingHelper.CreateMap<Region, RegionViewModel>()
                .ForMember(d => d.Title, s => s.MapFrom(m => m.Title))
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Alias, s => s.MapFrom(m => m.Alias));
        }

        /// <summary>
        /// Настраивает маппинг культур
        /// </summary>
        internal static void ConfigureCultureMapping()
        {
            MappingHelper.CreateMap<Culture, SelectListItem>()
                .ForMember(d => d.Text, s => s.MapFrom(m => m.Key))
                .ForMember(d => d.Value, s => s.MapFrom(m => m.Id));

            MappingHelper.CreateMap<Culture, CultureViewModel>()
                .ForMember(d => d.Title, s => s.MapFrom(m => m.Key))
                .ForMember(d => d.Id, s => s.MapFrom(m => m.Id));
        }

        /// <summary>
        /// Возвращает картинку по статусу
        /// </summary>
        /// <param name="state">Статус</param>
        private static string ItemStateImage(ItemState state)
        {
            switch (state)
            {
                case ItemState.Published:
                    return SiteConfiguration.Current.PublishStatusImageUrl;
                default:
                    return SiteConfiguration.Current.CreatedStatusImageUrl;
            }

        }
    }
}
