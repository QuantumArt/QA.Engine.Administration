using QA.Core.Service.Interaction;
using QA.Engine.Administration.Dto;

namespace QA.Engine.Administration.Services
{
    /// <summary>
    /// Контракт сервиса Qp
    /// </summary>
    public interface IQpService
    {
        /// <summary>
        /// Возвращает список контентов
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        ServiceEnumerationResult<QpContentDto> GetContents(UserContext userContext);

        /// <summary>
        /// Возвращает действие Qp
        /// </summary>
        /// <param name="userContext">Контекст пользователя</param>
        /// <param name="id">Идентфиикатор действия</param>
        ServiceResult<QpActionDto> GetAction(UserContext userContext, int id);
    }
}
