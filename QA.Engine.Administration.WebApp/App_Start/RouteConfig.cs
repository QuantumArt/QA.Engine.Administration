using System.Web.Mvc;
using System.Web.Routing;

namespace QA.Engine.Administration.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Proxy", "Proxy/{*queryValues}", new { controller = "Home", action = "Proxy" });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
