using System.Web.Mvc;
using QA.Core.Web.FluentFilters;
using QA.Engine.Administration.WebApp.AppCode;
using QA.Engine.Administration.WebApp.Controllers;

namespace QA.Engine.Administration.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            FilterProviders.Providers.Add(FluentFiltersBuider.Filters);
            RegisterGlobalFilters(GlobalFilters.Filters, FluentFiltersBuider.Filters);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters, FluentFilterCollection fluentFilters)
        {
            filters.Add(new HandleErrorAttribute());
            fluentFilters.Add<QpActionAttribute>(a =>
            {
                a.Exclude(new ControllerFilterCriteria(HomeController.NameConst))
                    .And(new ActionFilterCriteria(HomeController.ActionNameConstants.NoData))
                    .Or(new ControllerFilterCriteria(ErrorController.NameConst))
                    .And(new ActionFilterCriteria(ErrorController.ActionNameConstants.Error))
                    .Or(new ControllerFilterCriteria(HomeController.NameConst))
                    .And(new ActionFilterCriteria(HomeController.ActionNameConstants.Index));
            });
        }
    }
}
