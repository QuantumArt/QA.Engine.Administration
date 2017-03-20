using System.Collections.Generic;
using System.Linq;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;

namespace QA.Engine.Administration.Data.Infrastructure.Filters
{
    internal class FlatRegionFilter : SiteMapRegionFilter
    {
        public FlatRegionFilter(QPAbstractItem rootPage, IList<int> selectedRegions, IUnitOfWork uow)
            : base(rootPage, selectedRegions, uow)
        { }

        internal override IList<QPAbstractItem> FilterSiteMapQuery(IList<QPAbstractItem> query)
        {
            if (SelectedRegions == null || !SelectedRegions.Any())
            {
                return query.ToList();
            }

            return query.Where(page => page.Id == RootPage.Id || IsPageInRegionOrItsParent(page, SelectedRegions) || !page.AbstractItemAbtractItemRegionArticles.Any()).ToList();
        }
    }
}
