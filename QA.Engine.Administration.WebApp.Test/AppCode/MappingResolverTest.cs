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

        void RemoveFileIfExist(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        TestMappingResolver _resolver;
        bool _isStage;

        TestMappingResolver GetResolver(QpHelper qpHelper, bool isUnited, CacheProvider cache, bool isStage)
        {
            _resolver = new TestMappingResolver(qpHelper, isUnited, cache);
            _isStage = isStage;
            return _resolver;
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

            TestMappingResolver resolver = GetResolver(qpHelper, isUnited, cache, isStage);
            var mappingStr = GetMappingStr(isStage);
            resolver.SetMappingStr(mappingStr);

            var mapping = resolver.GetMapping(isStage);

            var mappingFromCache = resolver.GetMapping(isStage);

            var strKey = resolver.GetKeyStrPublic(isStage);
            cache.Invalidate(strKey);
            resolver.SetMappingStr(mappingStr + "   ");

            var mappingFromFileCache = resolver.GetMapping(isStage);


            cache.Invalidate(strKey);
            var path = resolver.GetMappingFileNamePublic(isStage);
            RemoveFileIfExist(path);

            var newMapping = resolver.GetMapping(isStage);

            Assert.AreEqual(mapping, mappingFromCache);
            Assert.AreEqual(mapping, mappingFromFileCache);
            Assert.AreNotEqual(mapping, newMapping);

        }


        [TestCleanup()]
        public void Cleanup()
        {
            if (_resolver != null)
            {
                var path = _resolver.GetMappingFileNamePublic(_isStage);
                RemoveFileIfExist(path); RemoveFileIfExist(path);
            }
        }


    }
}
