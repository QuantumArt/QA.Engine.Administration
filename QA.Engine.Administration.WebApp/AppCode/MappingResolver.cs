using QA.Core;
using QA.Engine.Administration.Data;
using QA.Engine.Administration.WebApp.Configuration;
using Quantumart.QP8.Assembling;
using System;
using System.Collections.Concurrent;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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

            public T Value { get; }
            public string MD5 { get; }
        }

        readonly bool _isUnited;

        readonly ICacheProvider _cacheProvider;

        readonly bool _writeMappings;

        static ConcurrentDictionary<string, Task> _executingUpdateTasks = new ConcurrentDictionary<string, Task>();

        static object _root = new object();

        readonly string _connectionString;
        readonly string _siteId;
        readonly int _siteIdInt;


        public MappingResolver(IQpHelper qpHelper, bool isUnited, ICacheProvider cacheProvider, bool writeMappings)
        {
            _isUnited = isUnited;
            _siteId = qpHelper.SiteId;
            _siteIdInt = int.Parse(qpHelper.SiteId);

            _connectionString = qpHelper.ConnectionString;
            _cacheProvider = cacheProvider;
            _writeMappings = writeMappings;
        }

        public MappingResolver(IQpHelper qpHelper, bool isUnited, ICacheProvider cacheProvider) : this(qpHelper, isUnited, cacheProvider, false)
        {
        }

        /// <summary>
        /// Получить маппинг с учетом режима доступа к данным live/stage
        /// </summary>
        public override XmlMappingSource GetCurrentMapping()
        {
            return GetMapping(IsStageMode);
        }

        void InvalidateCache(string key) => _cacheProvider.Invalidate(key);

        T GetFromCache<T>(string key)
        {
            return (T)_cacheProvider.Get(key);
        }


        T SetToCache<T>(string key, T value, int cacheTime)
        {
            _cacheProvider.Set(key, value, TimeSpan.FromSeconds (cacheTime));
            return value;
        }

        string GetKey(bool isStage)
        {
            return $"MappingResolver.GetMapping?isUnited={_isUnited}&isStage={isStage}&siteId={_siteId}";
        }

        protected string GetMappingFileName(bool isStage)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", $"siteId={_siteId}_isUnited={_isUnited}_isStage={isStage}.xml");
        }


        protected string GetKeyStr(bool isStage)
        {
            return GetKey(isStage) + "str";
        }

        string GetKeyLastMappingUpdate(bool isStage)
        {
            return GetKey(isStage) + "lastMappingUpdate";
        }

        DateTime GetLastMappingUpdateTime(bool isStage)
        {
            var key = GetKeyLastMappingUpdate(isStage);
            var result = GetFromCache<DateTime?>(key);
            return result ?? DateTime.MinValue;
        }

        void SetLastMappingUpdateTime(bool isStage, DateTime val)
        {
            var key = GetKeyLastMappingUpdate(isStage);
            SetToCache(key, val, int.MaxValue);
        }

        /// <summary>
        /// Получить маппинг с учетом конфигурации
        /// </summary>
        /// <returns></returns>
        public override XmlMappingSource GetMapping(bool isStage)
        {
            var siteId = int.Parse(_siteId);
            var key = GetKey(isStage);

            var mappingStrWithMd5 = GetMappingStrFromCache(isStage);
            var mappingWithMd5 = GetFromCache<ValueWtihMD5<XmlMappingSource>>(key);

            if (mappingWithMd5 == null || mappingWithMd5.MD5 != mappingStrWithMd5.MD5)
            {
                var mapping = XmlMappingSource.FromXml(mappingStrWithMd5.Value);
                mappingWithMd5 = new ValueWtihMD5<XmlMappingSource>(mapping, mappingStrWithMd5.MD5);

                _cacheProvider.Invalidate(key);
                _cacheProvider.Set(key, mappingWithMd5, TimeSpan.FromDays(366));
            }

           
            CheckMappingUpdateAsync(isStage);
            return mappingWithMd5.Value;
        }

        protected virtual DateTime? GetActualMappingUpdateTime()
        {

            var query = @"
select max(modified)
from (
	select max(modified) as modified
	from
		content_attribute union all
		select max(modified)
			from content union all
			select max(modified) from site) s";

            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                return (DateTime?)cmd.ExecuteScalar();
            }
        }

        Task CheckMappingUpdateAsync(bool isStage)
        {
            var lastCheckTimeKey = GetKey(isStage) + "checktime";
            var lastCheckTime = GetFromCache<DateTime?>(lastCheckTimeKey) ?? DateTime.MinValue;
            SetToCache(lastCheckTimeKey, DateTime.UtcNow, int.MaxValue);
            if ((DateTime.UtcNow - lastCheckTime) > TimeSpan.FromSeconds(AppSettings.CheckMappingUpdatePeriodicity))
            {
                var key = GetKeyStr(isStage);

                if (_executingUpdateTasks.ContainsKey(key)) { return Task.FromResult(0); }

                lock (_root)
                {
                    if (_executingUpdateTasks.ContainsKey(key)) { return Task.FromResult(0); }

                    var t = Task.Run(() =>
                   {
                       var lastUpdateTime = GetLastMappingUpdateTime(isStage);
                       var actualTime = GetActualMappingUpdateTime();
                       if (!actualTime.HasValue || actualTime > lastUpdateTime)
                       {
                           var updated = UpdateMappingFile(isStage);
                           if (actualTime.HasValue)
                           {
                               SetLastMappingUpdateTime(isStage, actualTime.Value);
                           }

                           InvalidateCache(key); //что бы при след. запросе, считать мапинг из файла
                    }
                   });

                    _executingUpdateTasks[key] = t;

                    return t.ContinueWith((task) => {
                        var res = _executingUpdateTasks.TryRemove(key, out t);
                        return res;
                    }
                    );
                }
            }

            return Task.FromResult(0);

        }

        ValueWtihMD5<string> GetMappingStrFromCache(bool isStage)
        {
            var key = GetKeyStr(isStage);
            var result = GetFromCache<ValueWtihMD5<string>>(key);

            if (result != null) { return result; }

            result = GetMappingStrFromFile(isStage);

            if (result == null)
            {
                result = UpdateMappingFile(isStage);
            }

            return SetToCache(key, result, AppSettings.MappingCacheTime);
        }

        ValueWtihMD5<string> UpdateMappingFile(bool isStage)
        {
            string mappingStr = GetMappingStr(isStage);
            if (_isUnited)
            {
                var strForReplace = isStage ? "_STAGE" : "_LIVE";
                mappingStr = mappingStr.Replace(strForReplace, "_UNITED");
            }
            var result = new ValueWtihMD5<string>(mappingStr, GetMd5Hash(mappingStr));

            File.WriteAllText(GetMappingFileName(isStage), mappingStr);
            return result;
        }

        ValueWtihMD5<string> GetMappingStrFromFile(bool isStage)
        {
            var path = GetMappingFileName(isStage);
            
            if (!File.Exists(path)) { return null; }

            string mappingStr = File.ReadAllText(path);
           
            return new ValueWtihMD5<string>(mappingStr, GetMd5Hash(mappingStr));
        }

        protected virtual string GetMappingStr(bool isStage)
        {
            var cnt = new AssembleContentsController(_siteIdInt, _connectionString) { IsLive = !isStage };
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