using System;
using System.Collections.Generic;
using System.Linq;
using QA.Core;
using QA.Core.Data;
using QA.Core.Data.QP;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;
using QA.Engine.Administration.Data.Infrastructure.Filters;

namespace QA.Engine.Administration.Data
{
    public class SiteMapRepository : L2SqlRepositoryBase<QPAbstractItem, int>, ISiteMapRepository
    {
        public SiteMapRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public virtual QPAbstractItem GetRootPage()
        {
            return GetAllQuery<QPAbstractItem>()
                .Where(w => w.Parent_ID == null & w.VersionOf_ID == null)
                .OrderBy(o => o.Id)
                .FirstOrDefault();
        }

        public virtual List<QPAbstractItem> GetSiteMapItems(SiteMapItemType type, int? parentId, int? cultureId, int[] regions, bool isArchive, int? pageSize, int? pageIndex, bool useHierarchyRegionsFilter)
        {
            var query = BuildSiteMapQuery(type, parentId == null ? null : new[] { parentId.Value }, cultureId, regions, isArchive, useHierarchyRegionsFilter)
                .OrderBy(o => o.IndexOrder ?? int.MaxValue)
                .ThenBy(o => o.VersionOf_ID != null ? o.VersionOf.Name : o.Name)
                .AsQueryable();

            if (pageSize != null && pageIndex != null)
            {
                ApplyPaging(ref query, pageIndex, pageSize);
            }

            return query.ToList();
        }

        public virtual List<QPAbstractItem> GetWidgets(int? parentId, int? cultureId, int[] regions, int? pageSize, int? pageIndex, bool useHierarchyRegionsFilter)
        {
            var query = BuildWidgetsQuery(parentId == null ? null : new[] { parentId.Value }, cultureId, regions, false, useHierarchyRegionsFilter)
                .OrderBy(o => o.IndexOrder ?? int.MaxValue)
                .ThenBy(o => o.VersionOf_ID != null ? o.VersionOf.Name : o.Name)
                .AsQueryable();

            if (pageSize != null && pageIndex != null)
            {
                ApplyPaging(ref query, pageIndex, pageSize);
            }

            return query.ToList();
        }

        public virtual int GetSiteMapItemsCount(SiteMapItemType type, int? parentId, int? cultureId, int[] regions, bool isArchive, bool useHierarchyRegionsFilter)
        {
            return BuildSiteMapQuery(type, parentId == null ? null : new[] { parentId.Value }, cultureId, regions, isArchive, useHierarchyRegionsFilter).Count;
        }

        public virtual int GetWidgetsCount(int? parentId, int? cultureId, int[] regions, bool useHierarchyRegionsFilter)
        {
            return BuildWidgetsQuery(parentId == null ? null : new[] { parentId.Value }, cultureId, regions, false, useHierarchyRegionsFilter).Count;
        }

        protected virtual IList<QPAbstractItem> BuildWidgetsQuery(int[] parentId, int? cultureId, int[] selectedRegions, bool isArchive, bool useHierarchyRegionsFilter)
        {
            var query = GetAllQuery<QPAbstractItem>();
            query = isArchive ? query.Where(w => w.Archive & w.Visible) : query.Where(w => w.Archive == false);

            Throws.IfArgumentNot(parentId != null, _ => parentId);
            query = query.Where(w => parentId.Contains(w.Parent_ID ?? 0) & w.IsPage == false);

            var rootPage = GetRootPage();
            Throws.IfArgumentNot(rootPage != null && rootPage.Id != 0, _ => rootPage, ex => new Exception(ExceptionMessages.RootPageNotFount));
            query = FilterCulture(query, rootPage.Id, cultureId);

            return RegionFilterFactory.Create(rootPage, selectedRegions, useHierarchyRegionsFilter, UnitOfWork).FilterSiteMapQuery(query.ToList()).ToList();
        }

        protected virtual IList<QPAbstractItem> BuildSiteMapQuery(SiteMapItemType type, int[] parentId, int? cultureId, int[] selectedRegions, bool isArchive, bool useHierarchyRegionsFilter)
        {
            var query = GetAllQuery<QPAbstractItem>();
            if (isArchive)
            {
                query = query.Where(w => w.Archive & w.Visible);
            }

            switch (type)
            {
                case SiteMapItemType.SiteMap:
                    query = query.Where(w => w.IsPage == true & w.VersionOf_ID == null);
                    query = parentId == null
                        ? query.Where(w => w.Parent_ID == null & w.VersionOf_ID == null)
                        : query.Where(w => parentId.Contains(w.Parent_ID ?? 0) || GetAllQuery<QPAbstractItem>().Where(w1 => parentId.Contains(w1.Parent_ID ?? 0)).Any(s => s.Id == w.VersionOf_ID));

                    break;
                case SiteMapItemType.Widget:
                    Throws.IfArgumentNot(parentId != null, _ => parentId);
                    query = query.Where(w => parentId.Contains(w.Parent_ID ?? 0) & w.IsPage == false);
                    break;
                case SiteMapItemType.ContentVersion:
                    Throws.IfArgumentNot(parentId != null, _ => parentId);
                    query = query.Where(w => parentId.Contains(w.VersionOf_ID ?? 0));
                    break;
                default:
                    if (parentId != null)
                    {
                        // Т.З. нет, логику никто не помнит Было так:
                        // query = query.Where(w => isArchive ? (parentId.Contains(w.Parent_ID ?? 0) || parentId.Contains(w.VersionOf_ID ?? 0)) : (parentId.Contains(w.Parent_ID ?? 0) || parentId.Contains(w.VersionOf_ID ?? 0)));
                        // parentId содержит слишком много элементов, больше чем позволяет использовать SQL WHERE IN(...)

                        // Ниже откровенный говнокод. Но я не понимаю, как это должно работать. Просто обхожу ошибку.
                        // Нам бы схемку, аль чертеж - мы б затеяли вертеж. Ну а так ищи что хочешь - черта лысого найдешь
                        var queryList = query.ToList().Where(w => parentId.Contains(w.Parent_ID ?? 0) || parentId.Contains(w.VersionOf_ID ?? 0)).ToList();
                        query = queryList.AsQueryable();
                    }
                    else
                    {
                        query = query.Where(w => isArchive
                            ? w.Parent_ID != null && GetAllQuery<QPAbstractItem>().Any(a => a.Id == (w.Parent_ID ?? 0) & a.Archive) == false || w.VersionOf_ID != null && GetAllQuery<QPAbstractItem>().Any(a => a.Id == (w.VersionOf_ID ?? 0) & a.Archive) == false
                            : w.Parent_ID == null || w.VersionOf_ID == null);
                    }

                    break;
            }

            var rootPage = GetRootPage();
            Throws.IfArgumentNot(rootPage != null && rootPage.Id != 0, _ => rootPage, ex => new Exception(ExceptionMessages.RootPageNotFount));
            query = FilterCulture(query, rootPage.Id, cultureId);

            return RegionFilterFactory.Create(rootPage, selectedRegions, useHierarchyRegionsFilter, UnitOfWork).FilterSiteMapQuery(query.ToList()).ToList();
        }

        internal IQueryable<QPAbstractItem> FilterCulture(IQueryable<QPAbstractItem> query, int rootPageId, int? cultureId)
        {
            if (cultureId.HasValue && cultureId != 0)
            {
                return query.Where(w => w.Id == rootPageId || w.Culture_ID == null || w.Culture_ID == cultureId);
            }

            return query;
        }

        public virtual void ChangeSiteMapItemParent(int itemId, int newParentId)
        {
            Throws.IfArgumentNot(itemId > 0, _ => itemId);
            Throws.IfArgumentNot(newParentId > 0, _ => newParentId);

            var item = GetById(itemId);
            if (item == null || item.Id == 0)
            {
                throw new DataException(ExceptionMessages.SourceElementNotFound);
            }

            var parent = GetById(newParentId);
            if (parent == null || parent.Id == 0)
            {
                throw new DataException(ExceptionMessages.TargetElementNotFound);
            }

            item.Parent = parent;
        }

        public virtual void PublishSiteMapItem(int itemId)
        {
            Throws.IfArgumentNot(itemId > 0, _ => itemId);

            var item = GetById(itemId);
            if (item == null || item.Id == 0)
            {
                throw new DataException(ExceptionMessages.PublishigElementNotFound);
            }

            var query = GetAllQuery<StatusType>();
            query = query.Where(w => w.SiteId == item.StatusType.SiteId & w.Name == ContentItemStatus.Published.GetDescription());

            var status = query.SingleOrDefault();
            if (status == null || status.Id == 0)
            {
                throw new DataException(ExceptionMessages.PublishingStatusNotFound);
            }

            item.StatusType = status;
        }

        public virtual void PublishSiteMapItems(int[] itemIds)
        {
            Throws.IfArgumentNot(itemIds != null, _ => itemIds);
            var items = GetByIds(itemIds);

            if (items == null || itemIds.Length == 0)
            {
                return;
            }

            var query = GetAllQuery<StatusType>();
            query = query.Where(w => w.SiteId == items[0].StatusType.SiteId & w.Name == ContentItemStatus.Published.GetDescription());

            var status = query.SingleOrDefault();
            if (status == null || status.Id == 0)
            {
                throw new DataException(ExceptionMessages.PublishingStatusNotFound);
            }

            items.ForEach(a => a.StatusType = status);
        }

        public void EditItem(int itemId, string title)
        {
            Throws.IfArgumentNot(itemId > 0, _ => itemId);
            Throws.IfArgumentNullOrEmpty(title, _ => title);

            var item = GetById(itemId);
            if (item == null || item.Id == 0)
            {
                throw new DataException(ExceptionMessages.ElementNotFound);
            }

            item.Title = title;
        }

        public override QPAbstractItem GetById(int id)
        {
            Throws.IfArgumentNot(id > 0, _ => id);
            var query = GetAllQuery<QPAbstractItem>().Where(w => w.Id == id);
            return query.SingleOrDefault();
        }

        public virtual List<QPAbstractItem> GetByIds(int[] ids)
        {
            Throws.IfArgumentNot(ids != null, _ => ids);
            var query = GetAllQuery<QPAbstractItem>().Where(w => ids.Contains(w.Id));
            return query.ToList();
        }

        public QPAbstractItem GetById(int id, bool isArchive)
        {
            Throws.IfArgumentNot(id > 0, _ => id);
            var query = GetAllQuery<QPAbstractItem>().Where(w => w.Id == id & w.Archive == isArchive);
            return query.SingleOrDefault();
        }

        public List<QPAbstractItem> GetByName(string name)
        {
            Throws.IfArgumentNullOrEmpty(name, _ => name);
            var query = GetAllQuery<QPAbstractItem>().Where(w => w.Name == name);
            return query.ToList();
        }

        public List<QPAbstractItem> GetByName(string name, int parentId)
        {
            Throws.IfArgumentNullOrEmpty(name, _ => name);
            var query = GetAllQuery<QPAbstractItem>().Where(w => w.Name == name & (w.Parent_ID ?? -1) == parentId);
            return query.ToList();
        }

        public virtual List<SiteMapChildrenCountResult> GetChildrenCountByParents(SiteMapItemType type, int[] parentIds, int? cultureId, int[] regions, bool isArchive, bool useHierarchyRegionsFilter)
        {
            Throws.IfArgumentNot(parentIds != null && parentIds.Any(), _ => parentIds);

            var query = BuildSiteMapQuery(type, parentIds, cultureId, regions, isArchive, useHierarchyRegionsFilter);
            var items = query.GroupBy(g => g.Parent_ID ?? g.VersionOf_ID).Select(s => new
            {
                Id = s.Key.Value,
                ChildrenCount = s.Count()
            }).ToList();

            return items.Select(s => new SiteMapChildrenCountResult
            {
                Id = s.Id,
                ChildrenCount = s.ChildrenCount
            }).ToList();
        }

        public virtual bool HasParent(int id)
        {
            Throws.IfArgumentNot(id > 0, _ => id);
            var query = GetAllQuery<QPAbstractItem>().Where(w => w.Id == id & w.Parent_ID != null);
            return query.Any();
        }

        public virtual bool IsHierarchyConstainsItem(int id, int parentId)
        {
            Throws.IfArgumentNot(id > 0, _ => id);
            Throws.IfArgumentNot(parentId > 0, _ => parentId);
            var query = GetAllQuery<TrailedAbstractItem>().Where(w => w.Id == parentId & w.Trail.Contains(id.ToString()));
            return query.Any();
        }

        public virtual QPAbstractItem Create(string title, string name, int discriminatorId, int parentId, StatusType status)
        {
            Throws.IfArgumentNullOrEmpty(title, _ => title);
            Throws.IfArgumentNullOrEmpty(name, _ => name);
            Throws.IfArgumentNot(discriminatorId > 0, _ => discriminatorId);
            Throws.IfArgumentNot(parentId > 0, _ => parentId);
            Throws.IfArgumentNot(status != null && status.Id != 0, _ => status);

            var entity = new QPAbstractItem
            {
                Title = title,
                Name = name,
                Discriminator_ID = discriminatorId,
                IsVisible = false,
                IsPage = true,
                IsInSiteMap = true,
                StatusType = status,
                Parent_ID = parentId
            };

            return base.Create(entity);
        }

        public virtual bool CanItemBeIncludeToItem(int itemId, int parentItemId)
        {
            Throws.IfArgumentNot(itemId > 0, _ => itemId);
            Throws.IfArgumentNot(parentItemId > 0, _ => parentItemId);

            var item = GetById(itemId);
            var parent = GetById(parentItemId);
            return parent.Discriminator.AllowedItemDefinitions1.Count == 0 || parent.Discriminator.AllowedItemDefinitions1.Any(a => a.Id == item.Discriminator_ID);
        }

        public virtual List<QPRegion> GetRegions(int id, int? pageSize, int? pageIndex)
        {
            Throws.IfArgumentNot(id > 0, _ => id);
            var query = GetAllQuery<AbstractItemAbtractItemRegionArticle>().Where(w => w.QPAbstractItem_ID == id);
            query = query.OrderBy(o => o.QPRegion.Title);
            if (pageSize != null && pageIndex != null)
            {
                ApplyPaging(ref query, pageIndex, pageSize);
            }

            return query.ToList().Select(s => s.QPRegion).ToList();
        }

        public virtual int GetRegionsCount(int id)
        {
            Throws.IfArgumentNot(id > 0, _ => id);
            var query = GetAllQuery<AbstractItemAbtractItemRegionArticle>().Where(w => w.QPAbstractItem_ID == id);
            return query.Count();
        }

        public virtual List<AbstractItemAbtractItemRegionArticle> GetRegionsLinks(int id)
        {
            Throws.IfArgumentNot(id > 0, _ => id);
            var query = GetAllQuery<AbstractItemAbtractItemRegionArticle>().Where(w => w.QPAbstractItem_ID == id);
            return query.ToList();
        }
    }
}
