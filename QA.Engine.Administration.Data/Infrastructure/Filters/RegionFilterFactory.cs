using System.Collections.Generic;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;

namespace QA.Engine.Administration.Data.Infrastructure.Filters
{
    internal class RegionFilterFactory
    {
        internal static SiteMapRegionFilter Create(QPAbstractItem rootPage, IList<int> selectedRegions, bool useHierarchyRegionsFilter, IUnitOfWork uow)
        {
            return useHierarchyRegionsFilter ? new HierarchyRegionFilter(rootPage, selectedRegions, uow) : new FlatRegionFilter(rootPage, selectedRegions, uow) as SiteMapRegionFilter;
        }
    }
}
