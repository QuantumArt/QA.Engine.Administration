using System.Collections.Generic;
using System.Linq;
using QA.Core;
using QA.Core.Data;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;

namespace QA.Engine.Administration.Data
{
    public class RegionRepository : L2SqlRepositoryBase<AbstractItemAbtractItemRegionArticle, int>, IRegionRepository
    {
        public RegionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public AbstractItemAbtractItemRegionArticle GetById(int itemId, int linkId)
        {
            Throws.IfArgumentNot(itemId > 0, _ => itemId);
            Throws.IfArgumentNot(linkId > 0, _ => linkId);

            return GetAllQuery<AbstractItemAbtractItemRegionArticle>().SingleOrDefault(w => w.QPAbstractItem_ID == itemId & w.QPRegion_ID == linkId);
        }

        public void Delete(int itemId, int linkId)
        {
            var item = GetById(itemId, linkId);
            if (item == null || item.QPAbstractItem_ID == 0 || item.QPRegion_ID == 0)
            {
                throw new DataException(ExceptionMessages.ElementNotFound);
            }

            Delete(item);
        }

        public void Delete(AbstractItemAbtractItemRegionArticle link)
        {
            Throws.IfArgumentNot(link != null, _ => link);
            GetDbSet<AbstractItemAbtractItemRegionArticle>().DeleteOnSubmit(link);
        }

        public List<AbstractItemAbtractItemRegionArticle> GetRegionReferences(int id)
        {
            return GetAllQuery<AbstractItemAbtractItemRegionArticle>().Where(w => w.QPAbstractItem_ID == id).ToList();
        }
    }
}
