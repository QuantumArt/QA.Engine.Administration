using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using QA.Core;
using QA.Core.Engine;
using QA.Core.Engine.QPData;
using QA.Core.Service.Interaction;
using QA.Core.Web;
using QA.Engine.Administration.Services;
using QA.Engine.Administration.WebApp.App_LocalResources;
using QA.Engine.Administration.WebApp.AppCode;
using QA.Engine.Administration.WebApp.Configuration;
using QA.Engine.Administration.WebApp.Models.Dictionary;

namespace QA.Engine.Administration.WebApp.Models.SiteMap
{
    public class SiteMapModel : ModelBase
    {
        public ListViewModelBase<SiteMapViewModel> GetSiteMapItemsViewModel(FilterViewModel filter)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<ListViewModelBase<SiteMapViewModel>>(ErrorMessages.InternalErrorMessage);
            }

            int[] regions = null;
            if (!string.IsNullOrEmpty(filter?.Regions))
            {
                var regionResult = ClientUtils.Resolve<IDictionaryService>().GetRegionListByNames(UserContext, filter.Regions);
                if (regionResult == null)
                {
                    return Error<ListViewModelBase<SiteMapViewModel>>(ErrorMessages.InternalErrorMessage);
                }

                if (!regionResult.IsSucceeded)
                {
                    return BusinessError<ListViewModelBase<SiteMapViewModel>>(regionResult.Error);
                }

                regions = regionResult.Result?.Select(s => s.Id).ToArray();
            }

            var result = service.GetSiteMapItems(UserContext, filter.Type, filter.ParentId == null || filter.ParentId == 0 ? null : filter.ParentId, filter.CultureId, regions, true, filter.IsArchive, null, useHierarchyRegionsFilter);
            if (result == null)
            {
                return Error<ListViewModelBase<SiteMapViewModel>>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<ListViewModelBase<SiteMapViewModel>>(result.Error);
            }

            return new ListViewModelBase<SiteMapViewModel>
            {
                IsSucceeded = true,
                List = MappingHelper.Map<AbstractItem, SiteMapViewModel>(result.Result)
            };
        }

        public AddSiteMapViewModel GetAddViewModel(AddSiteMapViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<AddSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            var result = new AddSiteMapViewModel
            {
                IsSucceeded = true,
                StructuralVersionParentId = 0,
                ParentId = viewModel.ParentId ?? 0,
                IsVersion = viewModel.IsVersion
            };

            if (viewModel.ParentId != null)
            {
                var parent = service.GetSiteMapItem(UserContext, viewModel.ParentId.Value, false, true, useHierarchyRegionsFilter);
                if (parent == null)
                {
                    return Error<AddSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
                }

                if (!parent.IsSucceeded)
                {
                    return BusinessError<AddSiteMapViewModel>(parent.Error);
                }

                result.StructuralVersionParentId = parent.Result.Parent?.Id;
                result.Parent = MappingHelper.Map<AbstractItem, SiteMapViewModel>(parent.Result);
            }

            return result;
        }

        public EditableSiteMapViewModel GetEditViewModel(ReadInfoViewModel viewModel)
        {
            var item = ClientUtils.Resolve<ISiteMapService>().GetSiteMapItem(UserContext, viewModel.Id, viewModel.IsArchive, viewModel.IsArchive, false);
            if (item == null)
            {
                return Error<EditableSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!item.IsSucceeded)
            {
                return BusinessError<EditableSiteMapViewModel>(item.Error);
            }

            var result = MappingHelper.Map<AbstractItem, EditableSiteMapViewModel>(item.Result);
            if (viewModel.Id > 0 & !viewModel.IsArchive)
            {
                if (item.Result.Parent == null)
                {
                    var items = ClientUtils.Resolve<IDictionaryService>().GetDiscriminators(UserContext);
                    result.Discriminators = MappingHelper.Map<DiscriminatorDTO, SelectListItem>(items.Result);
                }
                else
                {
                    var items = ClientUtils.Resolve<ISiteMapService>().GetAllowChildrenDiscriminators(UserContext, item.Result.Parent.Id, item.Result.IsPage);
                    if (items == null)
                    {
                        return Error<EditableSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
                    }

                    if (!items.IsSucceeded)
                    {
                        return BusinessError<EditableSiteMapViewModel>(items.Error);
                    }

                    result.Discriminators = MappingHelper.Map<DiscriminatorDTO, SelectListItem>(items.Result);
                }
            }

            result.IsSucceeded = true;
            return result;
        }

        public SiteMapRegionsViewModel GetSiteMapRegionsViewModel(ReadRegionsViewModel viewModel)
        {
            var result = new SiteMapRegionsViewModel { IsSucceeded = true, Id = viewModel.Id };
            var service = ClientUtils.Resolve<ISiteMapService>();
            var items = service.GetSiteMapItemRegions(UserContext, viewModel.Id, new PageInfo
            {
                PageNumber = viewModel.PageIndex,
                PageSize = AppSettings.DefaultPageSize
            });

            if (items == null)
            {
                return Error<SiteMapRegionsViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!items.IsSucceeded)
            {
                return BusinessError<SiteMapRegionsViewModel>(items.Error);
            }

            result.List = new List<RegionViewModel>();
            if (items.Result.Any())
            {
                result.List.AddRange(MappingHelper.Map<Region, RegionViewModel>(items.Result));
                result.Pager = new PagerViewModel
                {
                    TotalCount = items.PageInfo.TotalCount,
                    CurrentPage = items.PageInfo.PageNumber,
                    PageSize = AppSettings.DefaultPageSize
                };
            }
            else
            {
                if (!SiteConfiguration.Current.IsEmptyRegionListIfNotSelected)
                {
                    result.List.Add(new RegionViewModel
                    {
                        Id = 0,
                        Title = CommonStrings.AllTitle,
                        Alias = CommonStrings.AllName
                    });
                }

                result.Pager = new PagerViewModel
                {
                    CurrentPage = 1,
                    TotalCount = result.List.Count,
                    PageSize = AppSettings.DefaultPageSize
                };
            }

            return result;
        }

        public SiteMapRegionsViewModel GetSiteMapContentVersionsRegionsViewModel(ReadRegionsViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var result = new SiteMapRegionsViewModel { IsSucceeded = true, Id = viewModel.Id };
            var service = ClientUtils.Resolve<ISiteMapService>();
            var items = service.GetSiteMapItems(UserContext, SiteMapItemType.ContentVersion, viewModel.Id, null, null, false, false, null, useHierarchyRegionsFilter);
            if (items == null)
            {
                return Error<SiteMapRegionsViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!items.IsSucceeded)
            {
                return BusinessError<SiteMapRegionsViewModel>(items.Error);
            }

            result.List = new List<RegionViewModel>();
            if (items.Result.Any())
            {
                var regions = new List<Region>();
                items.Result.ForEach(e =>
                {
                    regions.AddRange(e.Regions);
                });

                var total = regions.Distinct().Count();
                regions = regions.Distinct().OrderBy(o => o.Title).Skip((viewModel.PageIndex == 0 ? viewModel.PageIndex : viewModel.PageIndex - 1) * AppSettings.DefaultPageSize).Take(AppSettings.DefaultPageSize).ToList();
                result.List.AddRange(MappingHelper.Map<Region, RegionViewModel>(regions));
                result.Pager = new PagerViewModel
                {
                    TotalCount = total,
                    CurrentPage = viewModel.PageIndex,
                    PageSize = AppSettings.DefaultPageSize
                };
            }
            else
            {
                if (!SiteConfiguration.Current.IsEmptyRegionListIfNotSelected)
                {
                    result.List.Add(new RegionViewModel
                    {
                        Id = 0,
                        Title = CommonStrings.AllTitle,
                        Alias = CommonStrings.AllName
                    });
                }

                result.Pager = new PagerViewModel
                {
                    CurrentPage = 1,
                    TotalCount = result.List.Count,
                    PageSize = AppSettings.DefaultPageSize
                };
            }

            return result;
        }

        public GroupViewModel<SiteMapRegionsGroupViewModel> GetSiteMapRegionsGroupViewModel(ReadRegionsViewModel viewModel)
        {
            var result = new GroupViewModel<SiteMapRegionsGroupViewModel>
            {
                IsSucceeded = true,
                Id = viewModel.Id
            };

            if (viewModel.Id == 0)
            {
                return result;
            }

            result.List = new List<SiteMapRegionsGroupViewModel>
            {
                new SiteMapRegionsGroupViewModel
                {
                    Id = 0,
                    Name = CommonStrings.ItemRegions
                },
                new SiteMapRegionsGroupViewModel
                {
                    Id = 1,
                    Name = CommonStrings.VersionRegions
                }
            };

            return result;
        }

        public SiteMapWidgetsViewModel GetWidgetsViewModel(ReadWidgetsViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var result = new SiteMapWidgetsViewModel { Id = viewModel.Id, IsSucceeded = true };
            if (viewModel.Id > 0)
            {
                var service = ClientUtils.Resolve<ISiteMapService>();
                var items = service.GetWidgets(UserContext, viewModel.Id, null, null, new PageInfo
                {
                    PageSize = AppSettings.DefaultPageSize,
                    PageNumber = viewModel.PageIndex
                }, useHierarchyRegionsFilter);

                if (items == null)
                {
                    return Error<SiteMapWidgetsViewModel>(ErrorMessages.InternalErrorMessage);
                }

                if (!items.IsSucceeded)
                {
                    return BusinessError<SiteMapWidgetsViewModel>(items.Error);
                }

                result.List = MappingHelper.Map<AbstractItem, SiteMapViewModel>(items.Result);
                result.Pager = new PagerViewModel
                {
                    CurrentPage = viewModel.PageIndex,
                    TotalCount = items.PageInfo.TotalCount,
                    PageSize = AppSettings.DefaultPageSize
                };
            }

            return result;
        }

        public ViewModelBase PublishWidgetsByAbstractItem(int id)
        {
            if (id > 0)
            {
                var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
                var service = ClientUtils.Resolve<ISiteMapService>();
                var result = service.GetSiteMapItems(UserContext, SiteMapItemType.Widget, id, null, null, false, false, null, useHierarchyRegionsFilter);
                if (result == null)
                {
                    return Error<SiteMapWidgetsViewModel>(ErrorMessages.InternalErrorMessage);
                }

                if (!result.IsSucceeded)
                {
                    return BusinessError<SiteMapWidgetsViewModel>(result.Error);
                }

                var items = result.Result;
                if (items != null)
                {
                    Action<AbstractItem> processItems = null;
                    processItems = (item) =>
                    {
                        var children = service.GetSiteMapItems(UserContext, SiteMapItemType.Widget, item.Id, null, null, false, false, null, useHierarchyRegionsFilter);
                        if (children?.Result != null && children.Result.Count > 0 && children.IsSucceeded)
                        {
                            items = items.Union(children.Result).ToList();
                            foreach (var i in children.Result)
                            {
                                processItems(i);
                            }
                        }
                    };

                    foreach (var i in items)
                    {
                        processItems(i);
                    }

                    var ids = items.Where(w => w.State != ItemState.Published).Select(s => s.Id).ToArray();
                    service.PublishSiteMapItems(UserContext, ids);
                }
            }

            return new ViewModelBase
            {
                IsSucceeded = true
            };
        }

        public ViewModelBase PublishWidgets(int[] id)
        {
            if (id != null && id.Length > 0)
            {
                var service = ClientUtils.Resolve<ISiteMapService>();
                service.PublishSiteMapItems(UserContext, id);
            }

            return new ViewModelBase
            {
                IsSucceeded = true
            };
        }

        public SiteMapContentVersionsViewModel GetContentVersionsViewModel(ReadContentVersionsViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var result = new SiteMapContentVersionsViewModel
            {
                Id = viewModel.Id,
                IsSucceeded = true
            };

            if (viewModel.Id > 0)
            {
                var service = ClientUtils.Resolve<ISiteMapService>();
                var items = service.GetSiteMapItems(UserContext, SiteMapItemType.ContentVersion, viewModel.Id, null, null, false, false, new PageInfo
                {
                    PageSize = AppSettings.DefaultPageSize,
                    PageNumber = viewModel.PageIndex
                }, useHierarchyRegionsFilter);

                if (items == null)
                {
                    return Error<SiteMapContentVersionsViewModel>(ErrorMessages.InternalErrorMessage);
                }

                if (!items.IsSucceeded)
                {
                    return BusinessError<SiteMapContentVersionsViewModel>(items.Error);
                }

                result.List = MappingHelper.Map<AbstractItem, SiteMapViewModel>(items.Result);
                result.Pager = new PagerViewModel
                {
                    CurrentPage = viewModel.PageIndex,
                    TotalCount = items.PageInfo.TotalCount,
                    PageSize = AppSettings.DefaultPageSize
                };
            }

            return result;
        }

        public ViewModelBase MoveItem(MoveItemViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            if (viewModel == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.ChangeSiteMapItemParent(UserContext, viewModel.ItemId, viewModel.NewParentId, useHierarchyRegionsFilter);
            if (result == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<ViewModelBase>(result.Error);
            }

            return new ViewModelBase
            {
                IsSucceeded = true
            };
        }

        public ViewModelBase ReorderItem(ReorderViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            if (viewModel == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.ReorderItem(UserContext, viewModel.ItemId, viewModel.RelatedItemId, viewModel.IsInsertBefore, useHierarchyRegionsFilter, AppSettings.ReorderItemStep);
            if (result == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<ViewModelBase>(result.Error);
            }

            return new ViewModelBase
            {
                IsSucceeded = true
            };
        }

        public ViewModelBase PublishItem(PublishItemViewModel viewModel)
        {
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.PublishSiteMapItem(UserContext, viewModel.Id);
            if (result == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<ViewModelBase>(result.Error);
            }

            return new ViewModelBase
            {
                IsSucceeded = true
            };
        }

        public ViewModelBase UpdateItemRegions(EditableItemRegionList viewModel)
        {
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.UpdateItemRegions(UserContext, viewModel.Id, viewModel.SelectedRegionIDs);
            if (result == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<ViewModelBase>(result.Error);
            }

            return new ViewModelBase
            {
                IsSucceeded = true
            };
        }

        public SiteMapViewModel EditItem(EditableSiteMapViewModel viewModel)
        {
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.Edit(UserContext, viewModel.Id, viewModel.Title);
            if (result == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<SiteMapViewModel>(result.Error);
            }

            return GetItemViewModel(new ReadSiteMapItemViewModel
            {
                Id = viewModel.Id,
                IsIncludeChildrenCount = true
            });
        }

        public SiteMapViewModel GetItemViewModel(ReadSiteMapItemViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            var items = service.GetSiteMapItem(UserContext, viewModel.Id, false, viewModel.IsIncludeChildrenCount, useHierarchyRegionsFilter);
            if (items == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!items.IsSucceeded)
            {
                return BusinessError<SiteMapViewModel>(items.Error);
            }

            var result = MappingHelper.Map<AbstractItem, SiteMapViewModel>(items.Result);
            result.IsSucceeded = true;
            return result;
        }

        public SiteMapViewModel GetSiteMap(string name, int parentId)
        {
            var service = ClientUtils.Resolve<ISiteMapService>();
            var result = service.GetSiteMapItems(UserContext, name, parentId);
            if (result == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<SiteMapViewModel>(result.Error);
            }

            if (result.Result.Count > 1)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (result.Result.Count == 0)
            {
                return new SiteMapViewModel
                {
                    IsSucceeded = true
                };
            }

            var item = MappingHelper.Map<AbstractItem, SiteMapViewModel>(result.Result.First());
            item.IsSucceeded = true;
            return item;
        }

        public SimpleViewModel<int[]> GetItemRegionIds(SimpleViewModel<int> viewModel)
        {
            var service = ClientUtils.Resolve<ISiteMapService>();
            var result = service.GetSiteMapItemRegions(UserContext, viewModel.Data, null);
            if (result == null)
            {
                return Error<SimpleViewModel<int[]>>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<SimpleViewModel<int[]>>(result.Error);
            }

            return new SimpleViewModel<int[]>
            {
                Data = result.Result.Select(s => s.Id).ToArray(),
                IsSucceeded = true
            };
        }

        public SimpleViewModel<int[]> GetItemCultureIds(SimpleViewModel<int> viewModel)
        {
            var service = ClientUtils.Resolve<IDictionaryService>();
            var result = service.GetCultureList(UserContext);
            if (result == null)
            {
                return Error<SimpleViewModel<int[]>>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<SimpleViewModel<int[]>>(result.Error);
            }

            return new SimpleViewModel<int[]>
            {
                Data = result.Result.Select(s => s.Id).ToArray(),
                IsSucceeded = true
            };
        }

        public virtual ListViewModelBase<DiscriminatorViewModel> GetDiscriminatorsViewModel(ReadDiscriminatorsViewModel viewModel)
        {
            var service = ClientUtils.Resolve<ISiteMapService>();
            var items = viewModel.ParentId > 0
                ? service.GetAllowChildrenDiscriminators(UserContext, viewModel.ParentId, viewModel.IsPage)
                : ClientUtils.Resolve<IDictionaryService>().GetDiscriminators(UserContext);

            if (items == null)
            {
                return Error<ListViewModelBase<DiscriminatorViewModel>>(ErrorMessages.InternalErrorMessage);
            }

            if (!items.IsSucceeded)
            {
                return BusinessError<ListViewModelBase<DiscriminatorViewModel>>(items.Error);
            }

            return new ListViewModelBase<DiscriminatorViewModel>
            {
                IsSucceeded = true,
                List = MappingHelper.Map<DiscriminatorDTO, DiscriminatorViewModel>(items.Result).OrderBy(o => o.Title).ToList()
            };
        }

        public RemoveSiteMapViewModel GetRemoveViewModel(RemoveSiteMapViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<RemoveSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            var items = service.GetSiteMapItems(UserContext, SiteMapItemType.ContentVersion, viewModel.Id, null, null, false, false, null, useHierarchyRegionsFilter);
            if (items == null)
            {
                return Error<RemoveSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!items.IsSucceeded)
            {
                return BusinessError<RemoveSiteMapViewModel>(items.Error);
            }

            var item = service.GetSiteMapItem(UserContext, viewModel.Id, false, false, useHierarchyRegionsFilter);
            if (item == null)
            {
                return Error<RemoveSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!item.IsSucceeded)
            {
                return BusinessError<RemoveSiteMapViewModel>(item.Error);
            }

            return new RemoveSiteMapViewModel
            {
                IsVersion = item.Result.VersionOf != null,
                IsSucceeded = true,
                Id = viewModel.Id,
                ContentVersions = MappingHelper.Map<AbstractItem, SelectListItem>(items.Result)
            };
        }

        public SiteMapViewModel RemoveItem(RemoveSiteMapViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            var item = service.GetSiteMapItem(UserContext, viewModel.Id, false, false, useHierarchyRegionsFilter);
            if (item == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!item.IsSucceeded)
            {
                return BusinessError<SiteMapViewModel>(item.Error);
            }

            var result = item.Result.IsPage
                ? service.Remove(UserContext, viewModel.Id, viewModel.IsDeleteAllVersions ?? false, viewModel.OperationsByContentVersion == ContentVersionOperations.Delete, viewModel.OperationsByContentVersion == ContentVersionOperations.Move ? viewModel.ContentVersionId : null, useHierarchyRegionsFilter)
                : service.Remove(UserContext, viewModel.Id, false, true, null, useHierarchyRegionsFilter);

            if (result == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<SiteMapViewModel>(result.Error);
            }

            if (viewModel.OperationsByContentVersion == ContentVersionOperations.Move)
            {
                return GetItemViewModel(new ReadSiteMapItemViewModel
                {
                    Id = viewModel.ContentVersionId.Value
                });
            }

            return new SiteMapViewModel
            {
                IsSucceeded = true
            };
        }

        public DeleteSiteMapViewModel GetDeleteViewModel(DeleteSiteMapViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<DeleteSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            var item = service.GetSiteMapItem(UserContext, viewModel.Id, false, true, useHierarchyRegionsFilter);
            if (item == null)
            {
                return Error<DeleteSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!item.IsSucceeded)
            {
                return BusinessError<DeleteSiteMapViewModel>(item.Error);
            }

            var result = MappingHelper.Map<AbstractItem, DeleteSiteMapViewModel>(item.Result);
            result.IsSucceeded = true;
            return result;
        }

        public QpViewModelBase DeleteItem(DeleteSiteMapViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.Delete(UserContext, viewModel.Id, viewModel.IsDeleteAllVersions ?? false, useHierarchyRegionsFilter);
            if (result == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<SiteMapViewModel>(result.Error);
            }

            return new SiteMapViewModel
            {
                IsSucceeded = true
            };
        }

        public ViewModelBase DeleteItemRegion(DeleteSiteMapRegionViewModel viewModel)
        {
            var service = ClientUtils.Resolve<ISiteMapService>();
            var result = service.DeleteItemRegion(UserContext, viewModel.Id, viewModel.RegionId);
            if (result == null)
            {
                return Error<ViewModelBase>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<ViewModelBase>(result.Error);
            }

            return new ViewModelBase
            {
                IsSucceeded = true
            };
        }

        public RestoreSiteMapViewModel GetRestoreViewModel(RestoreSiteMapViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<RestoreSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            var item = service.GetSiteMapItem(UserContext, viewModel.Id, false, true, useHierarchyRegionsFilter);
            if (item == null)
            {
                return Error<RestoreSiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!item.IsSucceeded)
            {
                return BusinessError<RestoreSiteMapViewModel>(item.Error);
            }

            var result = MappingHelper.Map<AbstractItem, RestoreSiteMapViewModel>(item.Result);
            result.IsSucceeded = true;
            return result;
        }

        public SiteMapViewModel RestoreItem(RestoreSiteMapViewModel viewModel)
        {
            var useHierarchyRegionsFilter = SiteConfiguration.Current.UseHierarchyRegionsFilter;
            var service = ClientUtils.Resolve<ISiteMapService>();
            if (service == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            var result = service.Restore(UserContext, viewModel.Id, viewModel.IsRestoreAllVersions ?? false, viewModel.IsRestoreAllChildren ?? false, viewModel.IsRestoreContentVersions ?? false, viewModel.IsRestoreWidgets ?? false, useHierarchyRegionsFilter);
            if (result == null)
            {
                return Error<SiteMapViewModel>(ErrorMessages.InternalErrorMessage);
            }

            if (!result.IsSucceeded)
            {
                return BusinessError<SiteMapViewModel>(result.Error);
            }

            return new SiteMapViewModel
            {
                IsSucceeded = true
            };
        }
    }
}
