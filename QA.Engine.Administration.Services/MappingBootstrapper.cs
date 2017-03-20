using System;
using System.Data;
using System.Linq;
using QA.Core;
using QA.Core.Engine;
using QA.Core.Engine.QPData;
using QA.Engine.Administration.Dto;

namespace QA.Engine.Administration.Services
{
    /// <summary>
    /// Реализует методы для маппирования сущностей QPContext в DTO
    /// </summary>
    internal class MappingBootstrapper
    {
        /// <summary>
        /// Инициализация маппинга
        /// </summary>
        internal static void Initialize()
        {
            ConfigureRegionMapping();
            ConfigureAbstractItemMapping();
            ConfigureDiscriminatorMapping();
            ConfigureCultureMapping();
        }

        /// <summary>
        /// Конфигурация маппинга QPAbstractItem, AbstractItem
        /// </summary>
        internal static void ConfigureAbstractItemMapping()
        {
            MappingHelper.CreateMap<QPAbstractItem, AbstractItem>()
                .ForMember(d => d.State,
                    s => s.MapFrom(
                        m => GetItemState(m)))
                .ForMember(d => d.Name,
                    s => s.MapFrom(
                        m => m.VersionOf_ID != null ? m.VersionOf.Name : m.Name))
                .ForMember(d => d.Regions,
                    s => s.MapFrom(
                        m => m.Regions == null ? null : MappingHelper.Map<QPRegion, Region>(m.Regions.ToList())))
                .ForMember(d => d.Culture,
                    s => s.MapFrom(
                        m => m.Culture == null ? null : new Culture { Id = m.Culture.Id, Key = m.Culture.Title }))
                .ForMember(d => d.TitleFormat,
                    s => s.Ignore())
                .ForMember(d => d.Parent,
                    s => s.MapFrom(
                        m => m.Parent))
                .ForMember(d => d.IsVisible,
                    s => s.MapFrom(
                        m => m.IsVisible))
                .ForMember(d => d.IsVisibility,
                    s => s.MapFrom(
                        m => m.Visible))
                .ForMember(d => d.Children,
                    s => s.Ignore())
                .ForMember(d => d.Versions,
                    s => s.Ignore())
                .ForMember(d => d.IconUrl,
                    s => s.MapFrom(
                        m => m.Discriminator == null ? string.Empty : m.Discriminator.IconUrlUrl))
                .ForMember(d => d.VersionOfId,
                    s => s.MapFrom(
                        m => m.VersionOf_ID))
                .ForMember(d => d.IsPage,
                    s => s.MapFrom(
                        m => m.IsPage))
                .ForMember(d => d.Id,
                    s => s.MapFrom(
                        m => m.Id))
                .ForMember(d => d.ZoneName,
                    s => s.MapFrom(
                        m => m.ZoneName))
                .ForMember(d => d.SortOrder,
                    s => s.MapFrom(
                        m => m.IndexOrder == null ? int.MaxValue : m.IndexOrder.Value))
                .ForMember(d => d.DiscriminatorName,
                    s => s.MapFrom(
                        m => m.Discriminator_ID == null ? null : m.Discriminator.Name))
                .ForMember(d => d.DiscriminatorId,
                    s => s.MapFrom(
                        m => m.Discriminator_ID))
                .ForMember(d => d.DiscriminatorTitle,
                    s => s.MapFrom(
                        m => m.Discriminator_ID == null ? null : m.Discriminator.Title))
                .ForMember(d => d.ExtensionId,
                    s => s.MapFrom(
                        m => m.Discriminator_ID == null ? null : m.Discriminator.PreferredContentId));
        }

        /// <summary>
        /// Конфигурация маппинга QPRegion, Region
        /// </summary>
        internal static void ConfigureRegionMapping()
        {
            MappingHelper.CreateMap<QPRegion, Region>()
                .ForMember(d => d.Id,
                    s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Alias,
                    s => s.MapFrom(m => m.Alias))
                .ForMember(d => d.Title,
                    s => s.MapFrom(m => m.Title));
        }

        /// <summary>
        /// Конфигурация маппинга QPCulture, Culture
        /// </summary>
        internal static void ConfigureCultureMapping()
        {
            MappingHelper.CreateMap<QPCulture, Culture>()
                .ForMember(d => d.Id,
                    s => s.MapFrom(m => m.Id))
                .ForMember(d => d.Key,
                    s => s.MapFrom(m => m.Title));
        }

        /// <summary>
        /// Маппинг контентов Qp
        /// </summary>
        internal static void ConfigureContentMapping()
        {
            MappingHelper.CreateMap<DataRow, QpContentDto>()
               .ForMember(d => d.Id,
                   s => s.MapFrom(m => m["CONTENT_ID"]))
               .ForMember(d => d.Name,
                    s => s.MapFrom(m => m["NET_CONTENT_NAME"] == DBNull.Value ? m["CONTENT_NAME"] : m["NET_CONTENT_NAME"]));

            MappingHelper.CreateMap<DataRow, QpFieldDto>()
               .ForMember(d => d.Id,
                   s => s.MapFrom(m => m["ATTRIBUTE_ID"]))
               .ForMember(d => d.Name,
                    s => s.MapFrom(m => m["NET_ATTRIBUTE_NAME"] == DBNull.Value ? m["ATTRIBUTE_NAME"] : m["NET_ATTRIBUTE_NAME"]));
        }

        /// <summary>
        /// Маппинг действий Qp
        /// </summary>
        internal static void ConfigureActionMapping()
        {
            MappingHelper.CreateMap<DataRow, QpActionDto>()
               .ForMember(d => d.Id,
                   s => s.MapFrom(m => m["ID"]))
               .ForMember(d => d.Name,
                    s => s.MapFrom(m => m["NAME"] == DBNull.Value ? string.Empty : m["NAME"]))
                .ForMember(d => d.Code,
                    s => s.MapFrom(m => m["CODE"] == DBNull.Value ? string.Empty : m["CODE"]));
        }

        /// <summary>
        /// Возвращает тип статуса по состоянию элемента
        /// </summary>
        /// <param name="item">Элемент</param>
        /// <returns></returns>
        private static ItemState GetItemState(
            QPAbstractItem item)
        {
            // TODO: real mapping
            if (item.StatusType.Name == ItemState.Published.GetDescription())
            {
                return ItemState.Published;
            }

            return ItemState.Created;
        }

        /// <summary>
        /// Настраивает маппинг типов разделов
        /// </summary>
        internal static void ConfigureDiscriminatorMapping()
        {
            MappingHelper.CreateMap<QPDiscriminator, DiscriminatorDTO>()
                .ForMember(d => d.Id,
                    s => s.MapFrom(m => m.Id))
                .ForMember(d => d.PreferredContentId,
                    s => s.MapFrom(m => m.PreferredContentId))
                .ForMember(d => d.Title,
                    s => s.MapFrom(m => m.Title))
                .ForMember(d => d.Name,
                    s => s.MapFrom(m => m.Name))
                .ForMember(d => d.AllowedChildren,
                    s => s.Ignore())
                .ForMember(d => d.AllowedParents,
                    s => s.Ignore())
                .ForMember(d => d.AllowedZoneNames,
                    s => s.Ignore())
                .ForMember(d => d.DisallowChildren,
                    s => s.Ignore())
                .ForMember(d => d.DisallowedParents,
                    s => s.Ignore())
                .ForMember(d => d.ItemType,
                    s => s.Ignore());

            MappingHelper.CreateMap<QPItemDefinitionConstraint, DiscriminatorConstraintDto>()
                .ForMember(d => d.SourceId,
                    s => s.MapFrom(m => m.Source_ID))
                .ForMember(d => d.TargetId,
                    s => s.MapFrom(m => m.Target_ID));
        }
    }
}
