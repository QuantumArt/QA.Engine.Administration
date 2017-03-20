using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA.Configuration;
using QA.Core;
using QA.Core.Web;
using QA.Engine.Administration.WebApp.Configuration;

namespace QA.Engine.Administration.WebApp.Models.Home
{
    public class HomeModel : ModelBase
    {
        public static List<SelectListItem> GetSites()
        {
            var service = ObjectFactoryBase.Resolve<IConfigurationService>();
            return service.GetConfigurations<SiteConfiguration>().Select(s => new SelectListItem
            {
                Text = s.SiteDescription,
                Value = s.Name,
                Selected = s.Name == SiteConfiguration.CurrentName
            }).ToList();
        }
    }
}
