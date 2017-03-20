using System.Collections.Generic;
using QA.Core.Data.Repository;
using QA.Core.Engine.QPData;

namespace QA.Engine.Administration.Data
{
    /// <summary>
    /// Контракт репозитория карты сайта
    /// </summary>
    public interface ISiteMapRepository : IRepository<QPAbstractItem, int>
    {
        /// <summary>
        /// Возвращает главную страницу
        /// </summary>
        QPAbstractItem GetRootPage();

        /// <summary>
        /// Возвращает список элементов сайта
        /// </summary>
        /// <param name="type">Тип элементов</param>
        /// <param name="parentId">Предок</param>
        /// <param name="cultureId">Культура</param>
        /// <param name="isArchive">Учитывать заархивированные элементы</param>
        /// <param name="regions">Регион</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageIndex">Индекс страницы</param>
        /// <param name="useHierarchyRegionsFilter">Использовать иерархический фильтр по регионам</param>
        List<QPAbstractItem> GetSiteMapItems(SiteMapItemType type, int? parentId, int? cultureId, int[] regions, bool isArchive, int? pageSize, int? pageIndex, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Возвращает список виджетов сайта
        /// </summary>
        List<QPAbstractItem> GetWidgets(int? parentId, int? cultureId, int[] regions, int? pageSize, int? pageIndex, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Возвращает количество элементов сайта
        /// </summary>
        int GetSiteMapItemsCount(SiteMapItemType type, int? parentId, int? cultureId, int[] regions, bool isArchive, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Возвращает количество виджетов сайта
        /// </summary>
        int GetWidgetsCount(int? parentId, int? cultureId, int[] regions, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Возвращает признак наличия предка у элемента
        /// </summary>
        /// <param name="id">Идентфиикатор элемента</param>
        bool HasParent(int id);

        /// <summary>
        /// Проверяет является ли элемент предком для другого элемента
        /// </summary>
        /// <param name="id">Идентификатор элемента, который проверяет на наличии в иерархии</param>
        /// <param name="parentId">Элемент, для которого проверяемые элемент является потомком на любом уровне иерархии</param>
        bool IsHierarchyConstainsItem(int id, int parentId);

        /// <summary>
        /// Перенос элемента
        /// </summary>
        /// <param name="itemId">Идентификатор переносимого элемента</param>
        /// <param name="newParentId">Идентификатор элемента, в который происходит перенос</param>
        void ChangeSiteMapItemParent(int itemId, int newParentId);

        /// <summary>
        /// Публикует раздел
        /// </summary>
        /// <param name="itemId">Идентификато раздела</param>
        void PublishSiteMapItem(int itemId);

        /// <summary>
        /// Публикует раздел
        /// </summary>
        /// <param name="itemIds">Идентификаторы разделов</param>
        void PublishSiteMapItems(int[] itemIds);

        /// <summary>
        /// Сохраняет раздел
        /// </summary>
        void EditItem(int itemId, string title);

        /// <summary>
        /// Возвращает элемент по идентификаторам
        /// </summary>
        List<QPAbstractItem> GetByIds(int[] ids);

        /// <summary>
        /// Создает раздел
        /// </summary>
        /// <param name="title">Заголовок</param>
        /// <param name="discriminatorId">Идентификатор типа раздела</param>
        /// <param name="status">Статус</param>
        /// <param name="name">Название</param>
        /// <param name="parentId">Идентификатор раздела-предка</param>
        QPAbstractItem Create(string title, string name, int discriminatorId, int parentId, StatusType status);

        /// <summary>
        /// Проверяет возможность вхождения раздела в другой раздел
        /// </summary>
        /// <param name="itemId">Раздел, для которого проверяем</param>
        /// <param name="parentItemId">Раздел-приемник</param>
        bool CanItemBeIncludeToItem(int itemId, int parentItemId);

        /// <summary>
        /// Возвращает список регионов элемента
        /// </summary>
        List<QPRegion> GetRegions(int id, int? pageSize, int? pageIndex);

        /// <summary>
        /// Возвращает количество регионов
        /// </summary>
        int GetRegionsCount(int id);

        /// <summary>
        /// Возвращает список ссылок на регионы элемента
        /// </summary>
        List<AbstractItemAbtractItemRegionArticle> GetRegionsLinks(int id);

        /// <summary>
        /// Возвращает информацию о количестве потомков у разделов
        /// </summary>
        List<SiteMapChildrenCountResult> GetChildrenCountByParents(SiteMapItemType type, int[] parentIds, int? cultureId, int[] regions, bool isArchive, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Возвращает список элементов по названию
        /// </summary>
        List<QPAbstractItem> GetByName(string name);

        /// <summary>
        /// Возвращает список элементов по названию
        /// </summary>
        List<QPAbstractItem> GetByName(string name, int parentId);

        /// <summary>
        /// Возвращает элемент по идентификатору
        /// </summary>
        QPAbstractItem GetById(int id, bool isArchive);
    }
}
