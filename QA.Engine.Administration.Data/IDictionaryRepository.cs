using System.Collections.Generic;
using QA.Core.Engine.QPData;

namespace QA.Engine.Administration.Data
{
    /// <summary>
    /// Контракт репозитория справочников
    /// </summary>
    public interface IDictionaryRepository
    {
        /// <summary>
        /// Возвращает список типов разделов
        /// </summary>
        List<QPDiscriminator> GetDiscriminators();

        /// <summary>
        /// Возвращает список сопоставлений типов разделов
        /// </summary>
        List<QPItemDefinitionConstraint> GetItemDefinitionConstraints();

        /// <summary>
        /// Возвращает список регионов
        /// </summary>
        /// <param name="namePart">Часть имени региона</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageIndex">Номер стартового элемента</param>
        List<QPRegion> GetRegionList(string namePart, int? pageIndex, int? pageSize);

        /// <summary>
        /// Возвращает список регионов по их именам (разделитель запятая)
        /// </summary>
        /// <param name="names">Имена регионов (разделитель запятая)</param>
        List<QPRegion> GetRegionList(string names);

        /// <summary>
        /// Возвращает количество регионов
        /// </summary>
        /// <param name="namePart">Часть имени региона</param>
        int GetRegionCount(string namePart);

        /// <summary>
        /// Возвращает список культур
        /// </summary>
        List<QPCulture> GetCultureList();

        /// <summary>
        /// Возвращает список типов статусов
        /// </summary>
        /// <param name="siteId">Идентификатор сайта</param>
        List<StatusType> GetStatusTypeList(int siteId);

        /// <summary>
        /// Возвращает тип статуса
        /// </summary>
        /// <param name="siteId">Идентификатор сайта</param>
        /// <param name="statusName">Название статуса</param>
        StatusType GetStatusType(int siteId, string statusName);

        /// <summary>
        /// Возвращает тип статуса
        /// </summary>
        /// <param name="siteId">Идентификатор сайта</param>
        /// <param name="statusId">Идентификатор статуса</param>
        StatusType GetStatusType(int siteId, int statusId);
    }
}
