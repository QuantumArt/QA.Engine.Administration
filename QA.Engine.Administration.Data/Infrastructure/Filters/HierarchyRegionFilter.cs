using System.Collections.Generic;
using System.Linq;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;

namespace QA.Engine.Administration.Data.Infrastructure.Filters
{
    internal class HierarchyRegionFilter : SiteMapRegionFilter
    {
        public HierarchyRegionFilter(QPAbstractItem rootPage, IList<int> selectedRegions, IUnitOfWork uow)
            : base(rootPage, selectedRegions, uow)
        { }

        internal override IList<QPAbstractItem> FilterSiteMapQuery(IList<QPAbstractItem> query)
        {
            if (SelectedRegions == null || !SelectedRegions.Any())
            {
                return query.ToList();
            }

            var result = new List<QPAbstractItem>();
            var root = query.SingleOrDefault(page => page.Id == RootPage.Id);
            if (root != null)
            {
                result.Add(root);
            }

            foreach (var selectedRegion in SelectedRegions.OrderByDescending(id => id))
            {
                var selectedRegionAndItsParents = GetRegionParentIds(selectedRegion);
                foreach (var pageGroups in query.Where(page => page.Id != RootPage.Id).GroupBy(page => new { page.Parent_ID, page.Name }))
                {
                    if (pageGroups.Count() == 1)
                    {
                        // Means that this page doesn't contain structure versions
                        var page = pageGroups.Single();
                        if (IsPageInRegionOrItsParent(page, selectedRegionAndItsParents) || page.Versions.Any(contentPage => IsPageInRegionOrItsParent(contentPage, selectedRegionAndItsParents)))
                        {
                            result = AddPageToResultIfNotExist(page, result);
                        }
                    }
                    else
                    {
                        // Means that this page contains structure versions
                        var isFound = false;
                        for (var i = 0; i < selectedRegionAndItsParents.Count() && !isFound; i++)
                        {
                            var regionId = selectedRegionAndItsParents[i];
                            foreach (var structurePage in pageGroups)
                            {
                                if (IsPageInRegion(structurePage, regionId) || structurePage.Versions.Any(contentPage => IsPageInRegion(contentPage, regionId)))
                                {
                                    result = AddPageToResultIfNotExist(structurePage, result);
                                    isFound = true;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static List<QPAbstractItem> AddPageToResultIfNotExist(QPAbstractItem pageToAdd, IList<QPAbstractItem> result)
        {
            if (result.All(page => page.Id != pageToAdd.Id))
            {
                result.Add(pageToAdd);
            }

            return result.ToList();
        }
    }
}
