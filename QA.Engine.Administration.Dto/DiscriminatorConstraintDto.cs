using System.Runtime.Serialization;

namespace QA.Engine.Administration.Dto
{
    /// <summary>
    /// Соответствие типов разделов
    /// </summary>
    [DataContract]
    public class DiscriminatorConstraintDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [DataMember]
        public int SourceId { get; set; }

        /// <summary>
        /// Идентификатор разрешенного типа
        /// </summary>
        [DataMember]
        public int TargetId { get; set; }
    }
}
