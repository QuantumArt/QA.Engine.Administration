using QA.Engine.Administration.WebApp.AppCode;
using QA.Engine.Administration.Data;
using QA.Core;

namespace QA.Engine.Administration.WebApp.Test
{
    class TestMappingResolver : MappingResolver
    {

        public const string qpContextLiveMap = @"App_Data\Mappings\QPContext_Live.map";
        public const string qpContextStageMap = @"App_Data\Mappings\QPContext_Stage.map";

        public TestMappingResolver(IQpHelper qpHelper, bool isUnited, ICacheProvider cacheProvider) : base(qpHelper, isUnited, cacheProvider)
        {
        }

        string _mappingStr;

        public void SetMappingStr(string mapping)
        {
            _mappingStr = mapping;
        }

        public string GetKeyStrPublic(bool isStage)
        {
            return this.GetKeyStr(isStage);
        }

        protected override string GetMappingStr(int siteId, bool isStage)
        {
            return _mappingStr;
        }
    }
}
