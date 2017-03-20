using System.Collections.Generic;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;

namespace QA.Engine.Administration.Data
{
    /// <summary>
    /// Контракт репозитория регионов
    /// </summary>
    public interface IRegionRepository : IRepository<AbstractItemAbtractItemRegionArticle, int>
    {
        /// <summary>
        /// Возвращает связь элемента и региона
        /// </summary>
        /// <param name="itemId">Идентфиикатор элемента</param>
        /// <param name="linkId">Идентфиикатор региона</param>
        AbstractItemAbtractItemRegionArticle GetById(int itemId, int linkId);

        /// <summary>
        /// Возвращает список регионов, связанных с элементом
        /// </summary>
        /// <param name="id">Идентификатор элемента</param>
        List<AbstractItemAbtractItemRegionArticle> GetRegionReferences(int id);

        /// <summary>
        ///  Удаляет связь
        /// </summary>
        /// <param name="itemId">Идентификатор элемента</param>
        /// <param name="linkId">Идентификатор региона</param>
        void Delete(int itemId, int linkId);

        /// <summary>
        /// Удаляет связь
        /// </summary>
        /// <param name="link">Связь</param>
        void Delete(AbstractItemAbtractItemRegionArticle link);
    }
}
