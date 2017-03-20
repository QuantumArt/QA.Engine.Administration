using System.Web.Mvc;
using QA.Core.Web;
using QA.Engine.Administration.WebApp.Configuration;
using QA.Engine.Administration.WebApp.Models.Home;

namespace QA.Engine.Administration.WebApp.Controllers
{
    public partial class HomeController : QAControllerBase
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxSites()
        {
            return Json(HomeModel.GetSites());
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxSetSite(SetCurrentSiteViewModel viewModel)
        {
            SiteConfiguration.Set(viewModel.Name);
            return Json(null);
        }

        [AjaxOnly]
        public virtual ActionResult NoData()
        {
            return PartialView();
        }
    }
}
