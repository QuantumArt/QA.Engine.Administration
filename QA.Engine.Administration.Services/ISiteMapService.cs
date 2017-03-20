using System.ServiceModel;
using QA.Core.Engine;
using QA.Core.Engine.QPData;
using QA.Core.Service.Interaction;

namespace QA.Engine.Administration.Services
{
    /// <summary>
    /// Контракт сервиса карты сайта
    /// </summary>
    [ServiceContract(Namespace = "http://qa.admin.sitemapservice")]
    public interface ISiteMapService
    {
        /// <summary>
        /// Возвращает список элементов сайта
        /// </summary>
        [OperationContract]
        ServiceEnumerationResult<AbstractItem> GetSiteMapItems(UserContext userContext, SiteMapItemType type, int? parentId, int? cultureId, int[] regions, bool includeChildrenCount, bool isArchive, PageInfo pageInfo, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Возвращает список виджетов сайта
        /// </summary>
        [OperationContract]
        ServiceEnumerationResult<AbstractItem> GetWidgets(UserContext userContext, int? parentId, int? cultureId, int[] regions, PageInfo pageInfo, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Возвращает список регионов элемента сайта
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="id">Идентификатор элемента</param>
        /// <param name="pageInfo">Параметры постраничной выборки</param>
        [OperationContract]
        ServiceEnumerationResult<Region> GetSiteMapItemRegions(UserContext userContext, int id, PageInfo pageInfo);

        /// <summary>
        /// Возвращает элемент сайта
        /// </summary>
        [OperationContract]
        ServiceResult<AbstractItem> GetSiteMapItem(UserContext userContext, int id, bool isArchive, bool includeChildrenCount, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Возвращает главную страницу
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        [OperationContract]
        ServiceResult<AbstractItem> GetRootPage(UserContext userContext);

        /// <summary>
        /// Возвращает элементы
        /// </summary>
        [OperationContract]
        ServiceEnumerationResult<AbstractItem> GetSiteMapItems(UserContext userContext, string name, int parentId);

        /// <summary>
        /// Возвращает список доступных типов страниц для раздела
        /// </summary>
        [OperationContract]
        ServiceEnumerationResult<DiscriminatorDTO> GetAllowChildrenDiscriminators(UserContext userContext, int itemId, bool? isPage);

        /// <summary>
        /// Переносит один элемент карты сайта в другой
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="itemId">Идентификатор переносимого элемента</param>
        /// <param name="newParentId">Идентификатор элемента, в который происходит перенос</param>
        /// <param name="useHierarchyRegionsFilter">Использовать иерархический фильтр по регионам</param>
        [OperationContract]
        IServiceResult<object> ChangeSiteMapItemParent(UserContext userContext, int itemId, int newParentId, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Изменяет порядок элементов
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="itemId">Элемент, для которого меняется позиция</param>
        /// <param name="relatedItemId">Элемент, относительно которого меняется позиция</param>
        /// <param name="isInsertBefore">Признак вставки до или после элемента relatedItemId. True - вставка до, False - после</param>
        /// <param name="useHierarchyRegionsFilter">Использовать иерархический фильтр по регионам</param>
        [OperationContract]
        ServiceResult<object> ReorderItem(UserContext userContext, int itemId, int relatedItemId, bool isInsertBefore, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Публикует раздел
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="itemId">Идентификатор раздела</param>
        [OperationContract]
        ServiceResult<object> PublishSiteMapItem(UserContext userContext, int itemId);

        [OperationContract]
        ServiceResult<object> PublishSiteMapItems(UserContext userContext, int[] itemIds);

        /// <summary>
        /// Добавялет элемент и публикует его
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="title">Заголовок</param>
        /// <param name="discriminatorId">Идентификатор типа раздела</param>
        /// <param name="name">Название</param>
        /// <param name="parentId">Идентификатор раздела-предка</param>
        [OperationContract]
        ServiceResult<AbstractItem> AddItem(UserContext userContext, string title, string name, int discriminatorId, int parentId);

        /// <summary>
        /// Отправляет раздел в архив
        /// </summary>
        [OperationContract]
        ServiceResult<object> Remove(UserContext userContext, int id, bool isDeleteAllVersions, bool isDeleteContentVersions, int? contentVersionId, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Удаляет раздел
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="id">Идентификатор элемента</param>
        /// <param name="isDeleteAllVersions">Признак удаления всех версий</param>
        /// <param name="useHierarchyRegionsFilter">Использовать иерархический фильтр по регионам</param>
        [OperationContract]
        ServiceResult<object> Delete(UserContext userContext, int id, bool isDeleteAllVersions, bool useHierarchyRegionsFilter);

        /// <summary>
        /// Сохранение элемента
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="id">Идентификатор раздела</param>
        /// <param name="title">Заголовок</param>
        [OperationContract]
        ServiceResult<object> Edit(UserContext userContext, int id, string title);

        /// <summary>
        /// Редактирование списка регионов для элемента
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="id">Идентификатор раздела</param>
        /// <param name="selectedRegionIDs">Выбранные регионы</param>
        [OperationContract]
        ServiceResult<object> UpdateItemRegions(UserContext userContext, int id, int[] selectedRegionIDs);

        /// <summary>
        /// Редактирование списка регионов для элемента
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="id">Идентификатор раздела</param>
        /// <param name="regionId">Идентификатор региона</param>
        [OperationContract]
        ServiceResult<object> DeleteItemRegion(UserContext userContext, int id, int regionId);

        /// <summary>
        /// Восстанавливает раздел
        /// </summary>
        [OperationContract]
        ServiceResult<object> Restore(UserContext userContext, int id, bool isRestoreAllVersions, bool isRestoreChildren, bool isRestoreContentVersions, bool isRestoreWidgets, bool useHierarchyRegionsFilter);
    }
}
