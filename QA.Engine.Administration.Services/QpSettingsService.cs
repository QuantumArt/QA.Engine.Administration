using QA.Core;
using QA.Core.Cache;
using QA.Core.Service.Interaction;
using Quantumart.QP8.BLL.Services.API;
using System;


namespace QA.Engine.Administration.Services
{
    public class QpSettingsService : QAServiceBase, IQpSettingsService
    {
        private readonly ICacheProvider _cacheProvider;

        private readonly TimeSpan _cacheTimeSpan = TimeSpan.FromMinutes(5);

        public QpSettingsService(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }

        public string GetSetting(string connectionString, string title)
        {
            string key = "AllQpSettings" + connectionString;

            var dbService = new DbService(connectionString, 1);

            var allSettings = _cacheProvider.GetOrAdd(key, _cacheTimeSpan, dbService.GetAppSettings);

            return allSettings.ContainsKey(title) ? allSettings[title] : null;
        }
    }
}
