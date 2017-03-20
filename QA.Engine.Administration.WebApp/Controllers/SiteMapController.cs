using System.Web.Mvc;
using QA.Core.Engine.QPData;
using QA.Core.Web;
using QA.Engine.Administration.WebApp.AppCode;
using QA.Engine.Administration.WebApp.Models;
using QA.Engine.Administration.WebApp.Models.SiteMap;

namespace QA.Engine.Administration.WebApp.Controllers
{
    public partial class SiteMapController : QAControllerBase
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Archive()
        {
            return View();
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxTree(FilterViewModel filter)
        {
            filter.Type = SiteMapItemType.SiteMap;
            return JsonResult(new SiteMapModel().GetSiteMapItemsViewModel(filter));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxArchiveTree(FilterViewModel filter)
        {
            filter.Type = SiteMapItemType.None;
            filter.IsArchive = true;
            return JsonResult(new SiteMapModel().GetSiteMapItemsViewModel(filter));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxGetItem(ReadSiteMapItemViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().GetItemViewModel(viewModel));
        }

        [HttpPost, NoCache]
        public virtual ActionResult AjaxTreeMoveItem(MoveItemViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().MoveItem(viewModel));
        }

        [ChildActionOnly]
        public virtual ActionResult Filter()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public virtual ActionResult Toolbar()
        {
            return PartialView();
        }

        [HttpPost, NoCache]
        public virtual ActionResult AjaxTreeReorderItem(ReorderViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().ReorderItem(viewModel));
        }

        [HttpPost, NoCache]
        public virtual ActionResult AjaxPublishItem(PublishItemViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().PublishItem(viewModel));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult AjaxAdd(AddSiteMapViewModel viewModel)
        {
            ModelState.Clear();
            return PartialView(new SiteMapModel().GetAddViewModel(viewModel));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult AjaxEdit(EditableSiteMapViewModel viewModel)
        {
            return PartialView(new SiteMapModel().GetEditViewModel(new ReadInfoViewModel
            {
                Id = viewModel.Id
            }));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxEditItem(EditableSiteMapViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().EditItem(viewModel));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult AjaxMove()
        {
            return PartialView();
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxGetSiteMap(string name, int parentId)
        {
            return JsonResult(new SiteMapModel().GetSiteMap(name, parentId));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxUpdateItemRegions(EditableItemRegionList viewModel)
        {
            return JsonResult(new SiteMapModel().UpdateItemRegions(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxDeleteItemRegion(DeleteSiteMapRegionViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().DeleteItemRegion(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxItemRegionIds(SimpleViewModel<int> viewModel)
        {
            return JsonResult(new SiteMapModel().GetItemRegionIds(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxItemCultureIds(SimpleViewModel<int> viewModel)
        {
            return JsonResult(new SiteMapModel().GetItemCultureIds(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxCultures(SimpleViewModel<int> viewModel)
        {
            return JsonResult(new SiteMapModel().GetItemCultureIds(viewModel));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult AjaxRemove(RemoveSiteMapViewModel viewModel)
        {
            return PartialView(new SiteMapModel().GetRemoveViewModel(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxRemoveItem(RemoveSiteMapViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().RemoveItem(viewModel));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult AjaxDelete(DeleteSiteMapViewModel viewModel)
        {
            return PartialView(new SiteMapModel().GetDeleteViewModel(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxDeleteItem(DeleteSiteMapViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().DeleteItem(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxRemoveContentVersion(RemoveSiteMapViewModel viewModel)
        {
            viewModel.OperationsByContentVersion = ContentVersionOperations.Delete;
            viewModel.IsDeleteAllVersions = false;
            return JsonResult(new SiteMapModel().RemoveItem(viewModel));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult AjaxRestore(RestoreSiteMapViewModel viewModel)
        {
            return PartialView(new SiteMapModel().GetRestoreViewModel(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxRestoreItem(RestoreSiteMapViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().RestoreItem(viewModel));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult Info(ReadInfoViewModel viewModel)
        {
            if (viewModel.Id <= 0)
            {
                return RedirectToAction(HomeController.ActionNameConstants.NoData, HomeController.NameConst);
            }

            var result = new SiteMapModel().GetEditViewModel(viewModel);
            if (!result.IsSucceeded)
            {
                return RedirectToAction(ErrorController.ActionNameConstants.Error, ErrorController.NameConst);
            }

            return PartialView(result);
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult ArchiveInfo(ReadInfoViewModel viewModel)
        {
            viewModel.IsArchive = true;
            if (viewModel.Id <= 0)
            {
                return RedirectToAction(HomeController.ActionNameConstants.NoData, HomeController.NameConst);
            }

            var result = new SiteMapModel().GetEditViewModel(viewModel);
            if (!result.IsSucceeded)
            {
                return RedirectToAction(ErrorController.ActionNameConstants.Error, ErrorController.NameConst);
            }

            return PartialView(result);
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult Regions(ReadRegionsViewModel viewModel)
        {
            if (viewModel.Id <= 0)
            {
                return RedirectToAction(HomeController.ActionNameConstants.NoData, HomeController.NameConst);
            }

            var result = new SiteMapModel().GetSiteMapRegionsGroupViewModel(viewModel);
            if (!result.IsSucceeded)
            {
                return RedirectToAction(ErrorController.ActionNameConstants.Error, ErrorController.NameConst);
            }

            return PartialView(result);
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxRegionsGroups(ReadRegionsViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().GetSiteMapRegionsGroupViewModel(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxRegions(ReadRegionsViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().GetSiteMapRegionsViewModel(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxContentVersionsRegions(ReadRegionsViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().GetSiteMapContentVersionsRegionsViewModel(viewModel));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult Widgets(ReadWidgetsViewModel viewModel)
        {
            if (viewModel.Id <= 0)
            {
                return RedirectToAction(HomeController.ActionNameConstants.NoData, HomeController.NameConst);
            }

            var result = new SiteMapModel().GetWidgetsViewModel(viewModel);
            if (!result.IsSucceeded)
            {
                return RedirectToAction(ErrorController.ActionNameConstants.Error, ErrorController.NameConst);
            }

            return PartialView(result);
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxWidgets(ReadWidgetsViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().GetWidgetsViewModel(viewModel));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxPublishWidgetsByAbstractItem(int id)
        {
            return JsonResult(new SiteMapModel().PublishWidgetsByAbstractItem(id));
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxPublishWidgets(int[] id)
        {
            return JsonResult(new SiteMapModel().PublishWidgets(id));
        }

        [HttpGet, NoCache, AjaxOnly]
        public virtual ActionResult ContentVersions(ReadContentVersionsViewModel viewModel)
        {
            if (viewModel.Id <= 0)
            {
                return RedirectToAction(HomeController.ActionNameConstants.NoData, HomeController.NameConst);
            }

            var result = new SiteMapModel().GetContentVersionsViewModel(viewModel);
            if (!result.IsSucceeded)
            {
                return RedirectToAction(ErrorController.ActionNameConstants.Error, ErrorController.NameConst);
            }

            return PartialView(result);
        }

        [HttpPost, NoCache, AjaxOnly]
        public virtual ActionResult AjaxContentVersions(ReadContentVersionsViewModel viewModel)
        {
            return JsonResult(new SiteMapModel().GetContentVersionsViewModel(viewModel));
        }
    }
}
