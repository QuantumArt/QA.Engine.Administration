using System.ServiceModel;
using QA.Core.Engine;
using QA.Core.Service.Interaction;
using QA.Engine.Administration.Dto;

namespace QA.Engine.Administration.Services
{
    /// <summary>
    /// Контракт сервиса справочников
    /// </summary>
    [ServiceContract(Namespace = "http://qa.admin.dictionaryservice")]
    public interface IDictionaryService
    {
        /// <summary>
        /// Возвращает список типов страниц
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        [OperationContract]
        ServiceEnumerationResult<DiscriminatorDTO> GetDiscriminators(UserContext userContext);

        /// <summary>
        /// Возвращает список доступных типов страниц для раздела
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        [OperationContract]
        ServiceEnumerationResult<DiscriminatorConstraintDto> GetDiscriminatorConstraints(UserContext userContext);

        /// <summary>
        /// Возвращает список регионов
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="namePart">Часть имени региона</param>
        /// <param name="pageInfo">Параметры постраничной выборки</param>
        [OperationContract]
        ServiceEnumerationResult<Region> GetRegionList(UserContext userContext, string namePart, PageInfo pageInfo);

        /// <summary>
        /// Возвращает список регионов
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="names">Имена регионов</param>
        [OperationContract]
        ServiceEnumerationResult<Region> GetRegionListByNames(UserContext userContext, string names);

        /// <summary>
        /// Возвращает список культур
        /// </summary>
        [OperationContract]
        ServiceEnumerationResult<Culture> GetCultureList(UserContext userContext);
    }
}
