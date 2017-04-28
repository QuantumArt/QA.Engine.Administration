using QA.Core;
using QA.Engine.Administration.Data;
using Quantumart.QP8.Assembling;
using System;
using System.Data.Linq.Mapping;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QA.Engine.Administration.WebApp.AppCode
{
    public class MappingResolver : Core.Data.Resolvers.ResolverBase
    {

        protected class ValueWtihMD5<T>
        {
            public ValueWtihMD5(T value, string md5)
            {
                Value = value;
                MD5 = md5;
            }

            public T Value { get; private set; }
            public string MD5 { get; private set; }
        }

        readonly bool _isUnited;

        readonly IQpHelper _qpHelper;

        readonly ICacheProvider _cacheProvider;

        public MappingResolver(IQpHelper qpHelper, bool isUnited, ICacheProvider cacheProvider)
        {
            _isUnited = isUnited;
            _qpHelper = qpHelper;
            _cacheProvider = cacheProvider;
        }

        /// <summary>
        /// Получить маппинг с учетом режима доступа к данным live/stage
        /// </summary>
        /// <param name="isStage"></param>
        /// <returns></returns>
        public override XmlMappingSource GetCurrentMapping()
        {
            
            return GetMapping(IsStageMode);
        }


        T GetFromCache<T>(string key)
        {
            return (T)_cacheProvider.Get(key);
        }

        string GetKey(bool isStage)
        {
            return $"MappingResolver.GetMapping?isUnited=${_isUnited}&isStage=${isStage}&siteId=${_qpHelper.SiteId}&connectionString=${_qpHelper.ConnectionString}";
        }


        protected string GetKeyStr(bool isStage)
        {
            return GetKey(isStage) + "str";
        }

        /// <summary>
        /// Получить маппинг с учетом конфигурации
        /// </summary>
        /// <returns></returns>
        public override XmlMappingSource GetMapping(bool isStage)
        {
            var siteId = int.Parse(_qpHelper.SiteId);
            var key = GetKey(isStage);

            var mappingStrWithMd5 = GetMappingStrFromCache(siteId, isStage);
            var mappingWithMd5 = GetFromCache<ValueWtihMD5<XmlMappingSource>>(key);

            if (mappingWithMd5 == null || mappingWithMd5.MD5 != mappingStrWithMd5.MD5)
            {
                var mapping = XmlMappingSource.FromXml(mappingStrWithMd5.Value);
                mappingWithMd5 = new ValueWtihMD5<XmlMappingSource>(mapping, mappingStrWithMd5.MD5);

                _cacheProvider.Invalidate(key);
                _cacheProvider.Set(key, mappingWithMd5, TimeSpan.FromDays(366));
            }

            return mappingWithMd5.Value;
        }

        ValueWtihMD5<string> GetMappingStrFromCache(int siteId, bool isStage)
        {
            var key = GetKeyStr(isStage);
            var result = GetFromCache<ValueWtihMD5<string>>(key);

            if (result == null)
            {
                var mappingStr = GetMappingStr(siteId, isStage);
                if (_isUnited)
                {
                    var strForReplace = isStage ? "_STAGE" : "_LIVE";
                    mappingStr = mappingStr.Replace(strForReplace, "_UNITED");
                }
                result = new ValueWtihMD5<string>(mappingStr, GetMd5Hash(mappingStr));
                _cacheProvider.Set(key, result, TimeSpan.FromMinutes(5));
            }

            return result;
        }

        protected virtual string GetMappingStr(int siteId, bool isStage)
        {
            var cnt = new AssembleContentsController(siteId, _qpHelper.ConnectionString) { IsLive = !isStage };
            return cnt.GetMapping("qpcontext");
        }


        string GetMd5Hash(string input)
        {
            byte[] data;
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}