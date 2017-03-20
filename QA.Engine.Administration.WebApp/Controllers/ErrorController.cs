using System.Web.Mvc;

namespace QA.Engine.Administration.WebApp.Controllers
{
    public partial class ErrorController : Controller
    {
        public virtual ActionResult Error()
        {
            return View();
        }
    }
}
