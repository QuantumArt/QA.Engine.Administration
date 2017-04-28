using System;

namespace QA.Engine.Administration.Data
{
    public interface IQpHelper
    {
        //
        // Summary:
        //     Id бэкенда
        string BackendSid { get; }
        //
        // Summary:
        //     Код поставщика
        string CustomerCode { get; }
        //
        // Summary:
        //     Id хоста
        string HostId { get; }
        //
        // Summary:
        //     Признак запуска через Custom Action Qp
        bool IsQpMode { get; }
        //
        // Summary:
        //     Ключ
        string QpKey { get; }
        //
        // Summary:
        //     Идентификатор сайта
        string SiteId { get; }

        /// <summary>
        /// ConnectionString
        /// </summary>
        string ConnectionString { get; }
    }
}