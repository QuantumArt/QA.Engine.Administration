using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using QA.Core;
using QA.Core.Web;
using QA.Core.Web.Qp;
using QA.Engine.Administration.WebApp.Configuration;

namespace QA.Engine.Administration.WebApp.AppCode
{
    public class QpActionAttribute : AuthorizeAttribute, IActionFilter
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.Request.IsAjaxRequest())
            {
                if (string.IsNullOrWhiteSpace(QpHelper.CustomerCode))
                {
                    throw new Exception("Customer code should not be empty");
                }

                SiteConfiguration.Set(QpHelper.QpKey);
            }
            else
            {
                if (httpContext.Request.HttpMethod.ToLower() == "post")
                {
                    var obj = SerializableQpViewModelBase.FromJsonString(httpContext.Request.InputStream);
                    if (obj != null)
                    {
                        SiteConfiguration.Set(obj.QpKey);
                    }
                }
                else
                {
                    SiteConfiguration.Set(QpHelper.QpKey);
                }
            }

            var service = ObjectFactoryBase.Resolve<IAdministrationSecurityChecker>();
            var isAuthorize = service.CheckAuthorization(httpContext);
            var ci = new CultureInfo(httpContext.Session[QPSecurityChecker.UserLanguageKey] as string ?? QpLanguage.Default.GetDescription());

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            return isAuthorize;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            NLog.MappedDiagnosticsContext.Set("customerCode", QpHelper.CustomerCode);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext) { }
    }
}
