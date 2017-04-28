using QA.Core.Web;
using QA.Core.Web.Qp;
using QA.Engine.Administration.Data;
using QA.Engine.Administration.WebApp.Configuration;
using System;
using System.Web;

namespace QA.Engine.Administration.WebApp.AppCode
{
    public class WebAppQpHelper : IQpHelper
    {
        Lazy<SerializableQpViewModelBase> _serializableQpViewModelBaseLazy = new Lazy<SerializableQpViewModelBase>(() =>
        {
            var httpContext = HttpContext.Current;

            if (httpContext.Request.IsAjaxRequest() && httpContext.Request.HttpMethod.ToLower() == "post")
            {
                return SerializableQpViewModelBase.FromJsonString(httpContext.Request.InputStream);
            }
            return null;
        });

        
        public bool IsQpMode => QpHelper.IsQpMode;

        public string HostId
        {
            get
            {
                var obj = _serializableQpViewModelBaseLazy.Value;
                return obj != null ? obj.HostId : QpHelper.HostId;
            }
        }

        public string CustomerCode
        {
            get
            {
                var obj = _serializableQpViewModelBaseLazy.Value;
                return obj != null ? obj.CustomerCode : QpHelper.CustomerCode;
            }
        }

        public string BackendSid
        {
            get
            {
                var obj = _serializableQpViewModelBaseLazy.Value;
                return obj != null ? obj.BackendSid : QpHelper.BackendSid;
            }
        }

        public string QpKey
        {
            get
            {
                var obj = _serializableQpViewModelBaseLazy.Value;
                return obj != null ? obj.QpKey : QpHelper.QpKey;
            }
        }

        public string SiteId
        {
            get
            {
                var obj = _serializableQpViewModelBaseLazy.Value;
                return obj != null ? obj.SiteId : QpHelper.SiteId;
            }
        }

        public string ConnectionString => SiteConfiguration.Current?.ConnectionString;

    }
}