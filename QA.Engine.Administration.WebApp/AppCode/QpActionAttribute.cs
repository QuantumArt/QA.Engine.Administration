using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using QA.Core;
using QA.Core.Web;
using QA.Core.Web.Qp;
using QA.Engine.Administration.WebApp.Configuration;
using QA.Engine.Administration.Data;

namespace QA.Engine.Administration.WebApp.AppCode
{
    public class QpActionAttribute : AuthorizeAttribute, IActionFilter
    {
        //private readonly IQpHelper _qpHelper;
        public QpActionAttribute()
        {
           
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var _qpHelper = new WebAppQpHelper();
            if (!httpContext.Request.IsAjaxRequest())
            {
                if (string.IsNullOrWhiteSpace(_qpHelper.CustomerCode))
                {
                    throw new Exception("Customer code should not be empty");
                }

                
            }
            SiteConfiguration.Set(_qpHelper.CustomerCode, _qpHelper.SiteId);
       

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
