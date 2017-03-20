using System.Runtime.Serialization;

namespace QA.Engine.Administration.Dto
{
    /// <summary>
    /// Объект-передачи для поля Qp
    /// </summary>
    [DataContract]
    public class QpFieldDto
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
    }
}
