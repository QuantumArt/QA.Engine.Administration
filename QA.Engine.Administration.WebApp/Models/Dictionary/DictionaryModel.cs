using QA.Core;
using QA.Core.Engine;
using QA.Core.Web;
using QA.Engine.Administration.Dto;
using QA.Engine.Administration.Services;
using QA.Engine.Administration.WebApp.App_LocalResources;
using QA.Engine.Administration.WebApp.AppCode;

namespace QA.Engine.Administration.WebApp.Models.Dictionary
{
    public class DictionaryModel : ModelBase
    {
        public virtual ListViewModelBase<RegionViewModel> GetRegionsViewModel(string namePart)
        {
            var service = ClientUtils.Resolve<IDictionaryService>();
            if (service == null)
            {
                return Error<ListViewModelBase<RegionViewModel>>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.GetRegionList(UserContext, namePart, null);
            if (result == null)
            {
                return Error<ListViewModelBase<RegionViewModel>>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<ListViewModelBase<RegionViewModel>>(result.Error);
            }

            return new ListViewModelBase<RegionViewModel>
            {
                IsSucceeded = true,
                List = MappingHelper.Map<Region, RegionViewModel>(result.Result)
            };
        }

        public virtual ListViewModelBase<DiscriminatorConstraintViewModel> GetDiscriminatorConstraintsViewModel()
        {
            var service = ClientUtils.Resolve<IDictionaryService>();
            var items = service.GetDiscriminatorConstraints(UserContext);
            if (items == null)
            {
                return Error<ListViewModelBase<DiscriminatorConstraintViewModel>>(ErrorMessages.InternalErrorMessage);
            }

            if (!items.IsSucceeded)
            {
                return BusinessError<ListViewModelBase<DiscriminatorConstraintViewModel>>(items.Error);
            }

            return new ListViewModelBase<DiscriminatorConstraintViewModel>
            {
                IsSucceeded = true,
                List = MappingHelper.Map<DiscriminatorConstraintDto, DiscriminatorConstraintViewModel>(items.Result)
            };
        }

        public virtual ListViewModelBase<CultureViewModel> GetCulturesViewModel()
        {
            var service = ClientUtils.Resolve<IDictionaryService>();
            if (service == null)
            {
                return Error<ListViewModelBase<CultureViewModel>>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.GetCultureList(UserContext);
            if (result == null)
            {
                return Error<ListViewModelBase<CultureViewModel>>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<ListViewModelBase<CultureViewModel>>(result.Error);
            }

            return new ListViewModelBase<CultureViewModel>
            {
                IsSucceeded = true,
                List = MappingHelper.Map<Culture, CultureViewModel>(result.Result)
            };
        }
    }
}
