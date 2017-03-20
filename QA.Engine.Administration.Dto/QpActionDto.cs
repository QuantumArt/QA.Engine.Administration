using System.Runtime.Serialization;

namespace QA.Engine.Administration.Dto
{
    /// <summary>
    /// Объект передачи действия Qp
    /// </summary>
    [DataContract]
    public class QpActionDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        [DataMember]
        public string Code { get; set; }
    }
}
