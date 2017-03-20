using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QA.Engine.Administration.Dto
{
    /// <summary>
    /// Объект-передачи контентов Qp
    /// </summary>
    [DataContract]
    public class QpContentDto
    {
        /// <summary>
        /// Название
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Идентфикатор
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Поля
        /// </summary>
        [DataMember]
        public List<QpFieldDto> Fields { get; set; }
    }
}
