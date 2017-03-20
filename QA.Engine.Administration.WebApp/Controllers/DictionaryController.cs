using System.Web.Mvc;
using QA.Core.Web;
using QA.Engine.Administration.WebApp.Models.Dictionary;
using QA.Engine.Administration.WebApp.Models.SiteMap;

namespace QA.Engine.Administration.WebApp.Controllers
{
    public partial class DictionaryController : QAControllerBase
    {
        [NoCache, AjaxOnly]
        public virtual ActionResult AjaxCultures()
        {
            return Json(new DictionaryModel().GetCulturesViewModel());
        }

        [NoCache, AjaxOnly]
        public virtual ActionResult AjaxDiscriminators(ReadDiscriminatorsViewModel viewModel)
        {
            return Json(new SiteMapModel().GetDiscriminatorsViewModel(viewModel));
        }

        [NoCache, AjaxOnly]
        public virtual ActionResult AjaxDiscriminatorConstraints()
        {
            return Json(new DictionaryModel().GetDiscriminatorConstraintsViewModel());
        }

        // TODO: fix naming
        [NoCache, AjaxOnly]
        public virtual ActionResult AjaxKendoUIRegions(ReadRegionsViewModel viewModel)
        {
            if (viewModel == null)
            {
                return Json(null);
            }

            if (viewModel.filter?.filters == null || viewModel.filter.filters.Length == 0)
            {
                return AjaxRegions(viewModel.Copy(new ReadRegionsViewModel
                {
                    Text = string.Empty
                }));
            }

            return AjaxRegions(viewModel.Copy(new ReadRegionsViewModel
            {
                Text = viewModel.filter.filters[0].value
            }));
        }

        [NoCache, AjaxOnly]
        public virtual ActionResult AjaxRegions(ReadRegionsViewModel viewModel)
        {
            return Json(new DictionaryModel().GetRegionsViewModel(viewModel.Text));
        }
    }
}
