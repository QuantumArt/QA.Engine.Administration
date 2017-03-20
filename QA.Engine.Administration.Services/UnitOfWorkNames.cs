using System.ComponentModel;

namespace QA.Engine.Administration.Services
{
    /// <summary>
    /// Перечисление имен контекстов
    /// </summary>
    public enum UnitOfWorkNames
    {
        [Description("Qp")]
        Qp,

        [Description("QpArchive")]
        QpArchive
    }
}
