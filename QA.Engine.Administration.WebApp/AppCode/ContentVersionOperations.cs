using QA.Core;
using QA.Engine.Administration.WebApp.App_LocalResources;
using System.Runtime.Serialization;

namespace QA.Engine.Administration.WebApp.AppCode
{
    [DataContract]
    public enum ContentVersionOperations
    {
        [LocalizedEnum("ContentVersionOperations_Delete", NameResourceType = typeof(EnumStrings))]
        [EnumMember]
        Delete = 0,

        [LocalizedEnum("ContentVersionOperations_Move", NameResourceType = typeof(EnumStrings))]
        [EnumMember]
        Move = 1
    }
}
