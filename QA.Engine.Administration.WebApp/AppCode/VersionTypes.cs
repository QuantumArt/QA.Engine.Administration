using QA.Core;
using QA.Engine.Administration.WebApp.App_LocalResources;

namespace QA.Engine.Administration.WebApp.AppCode
{
    public enum VersionTypes
    {
        [LocalizedEnum("VersionTypes_Content", NameResourceType = typeof(EnumStrings))]
        Content = 0,

        [LocalizedEnum("VersionTypes_Structural", NameResourceType = typeof(EnumStrings))]
        Structural = 1
    }
}
