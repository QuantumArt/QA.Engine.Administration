using System;
using System.Collections.Generic;
using System.Linq;
using QA.Core;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;

namespace QA.Engine.Administration.Data
{
    public class DictionaryRepository : L2SqlRepositoryBase<QPDiscriminator, int>, IDictionaryRepository
    {
        public DictionaryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public List<QPDiscriminator> GetDiscriminators()
        {
            return GetAllQuery<QPDiscriminator>().ToList();
        }

        public List<QPItemDefinitionConstraint> GetItemDefinitionConstraints()
        {
            return GetAllQuery<QPItemDefinitionConstraint>().ToList();
        }

        public List<QPRegion> GetRegionList(string namePart, int? pageIndex, int? pageSize)
        {
            var query = GetAllQuery<QPRegion>();
            if (!string.IsNullOrEmpty(namePart))
            {
                query = query.Where(w => w.Title.Contains(namePart));
            }

            query = query.OrderBy(o => o.Title);
            if (pageSize != null && pageIndex != null)
            {
                ApplyPaging(ref query, pageIndex, pageSize);
            }

            return query.ToList();
        }

        public List<QPRegion> GetRegionList(string names)
        {
            Throws.IfArgumentNullOrEmpty(names, _ => names);
            var items = names.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
            return GetAllQuery<QPRegion>().Where(w => items.Contains(w.Title)).ToList();
        }

        public int GetRegionCount(string namePart)
        {
            var query = GetAllQuery<QPRegion>();
            if (!string.IsNullOrEmpty(namePart))
            {
                query = query.Where(w => w.Title.Contains(namePart));
            }

            return query.Count();
        }

        public List<QPCulture> GetCultureList()
        {
            return GetAllQuery<QPCulture>().OrderBy(o => o.Title).ToList();
        }

        public List<StatusType> GetStatusTypeList(int siteId)
        {
            Throws.IfArgumentNot(siteId > 0, _ => siteId);
            return GetAllQuery<StatusType>().Where(w => w.SiteId == siteId).OrderBy(o => o.Name).ToList();
        }

        public StatusType GetStatusType(int siteId, string statusName)
        {
            Throws.IfArgumentNot(siteId > 0, _ => siteId);
            Throws.IfArgumentNullOrEmpty(statusName, _ => statusName);
            return GetAllQuery<StatusType>().SingleOrDefault(w => w.SiteId == siteId & w.Name == statusName);
        }

        public StatusType GetStatusType(int siteId, int statusId)
        {
            Throws.IfArgumentNot(siteId > 0, _ => siteId);
            Throws.IfArgumentNot(statusId > 0, _ => statusId);
            return GetAllQuery<StatusType>().SingleOrDefault(w => w.SiteId == siteId & w.Id == statusId);
        }
    }
}
