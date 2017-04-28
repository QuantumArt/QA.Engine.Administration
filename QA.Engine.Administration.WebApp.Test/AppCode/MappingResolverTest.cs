using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.Core;
using System.IO;

namespace QA.Engine.Administration.WebApp.Test.AppCode
{
    [TestClass]
    public class MappingResolverTest
    {


        string GetMappingStr(bool isStage)
        {
            if (isStage)
            {
                return File.ReadAllText(TestMappingResolver.qpContextStageMap);
            }
            return File.ReadAllText(TestMappingResolver.qpContextLiveMap);
        }
        

        [TestMethod]
        public void GetMapping_CacheTest()
        {
            bool isStage = true;
            bool isUnited = false;
            var qpHelper = new QpHelper();
            qpHelper.SiteId = "1";
            qpHelper.ConnectionString = "testConnectionString";
            CacheProvider cache = new CacheProvider();

            TestMappingResolver resolver = new TestMappingResolver(qpHelper, isUnited, cache);
            var mappingStr = GetMappingStr(isStage);
            resolver.SetMappingStr(mappingStr);

            var mapping = resolver.GetMapping(isStage);

            var mappingFromCache = resolver.GetMapping(isStage);

            var strKey = resolver.GetKeyStrPublic(isStage);
            cache.Invalidate(strKey);
            resolver.SetMappingStr(mappingStr + "   ");

            var newMapping = resolver.GetMapping(isStage);

            Assert.AreEqual(mapping, mappingFromCache);

            Assert.AreNotEqual(mapping, newMapping);

        }

    }
}
