using System;
using System.Collections.Generic;
using System.Linq;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;
using Quantumart.QP8.BLL.Services.API;
using Quantumart.QPublishing.Database;
using QPLibrary = Quantumart.QP8.BLL;

namespace QA.Engine.Administration.Data.Infrastructure.Filters
{
    internal abstract class SiteMapRegionFilter
    {
        internal QPAbstractItem RootPage;
        internal IList<int> SelectedRegions;
        internal IUnitOfWork Uow;

        protected SiteMapRegionFilter(QPAbstractItem rootPage, IList<int> selectedRegions, IUnitOfWork uow)
        {
            RootPage = rootPage;
            SelectedRegions = selectedRegions;
            Uow = uow;
        }

        protected internal bool IsPageInRegionOrItsParent(QPAbstractItem page, IList<int> regionIds)
        {
            return page.AbstractItemAbtractItemRegionArticles.Any(a => regionIds.Contains(a.QPRegion_ID));
        }

        protected internal bool IsPageInRegion(QPAbstractItem page, int regionId)
        {
            return page.AbstractItemAbtractItemRegionArticles.Select(a => a.QPRegion_ID).Contains(regionId);
        }

        protected internal IList<int> GetRegionParentIds(int regionId)
        {
            List<int> result;
            var ctx = Uow.Context as QPContext;
            if (ctx == null)
            {
                throw new InvalidCastException("UnitOfWork.Context in not an instance of type QPContext.");
            }

            using (var scope = new QPLibrary.QPConnectionScope(ctx.ConnectionString))
            {
                var contentId = new DBConnector(scope.DbConnection).GetContentIdByNetName(ctx.SiteId, typeof(QPRegion).Name);
                var articleService = new ArticleService(ctx.ConnectionString, 1);
                var contentService = new ContentService(ctx.ConnectionString, 1);
                var fieldId = contentService.Read(contentId).TreeField.Id;
                result = articleService.GetParentIds(regionId, fieldId).ToList();
            }

            return result;
        }

        internal abstract IList<QPAbstractItem> FilterSiteMapQuery(IList<QPAbstractItem> query);
    }
}
