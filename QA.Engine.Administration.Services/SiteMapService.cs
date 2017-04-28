using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using QA.Core;
using QA.Core.Data.QP;
using QA.Core.Data.Repository;
using QA.Core.Engine;
using QA.Core.Engine.QPData;
using QA.Core.Service.Interaction;
using QA.Engine.Administration.Data;

namespace QA.Engine.Administration.Services
{
    public class SiteMapService : QAServiceBase, ISiteMapService
    {
        public SiteMapService()
        {
            MappingBootstrapper.Initialize();
        }

        public virtual ServiceEnumerationResult<AbstractItem> GetSiteMapItems(UserContext userContext, SiteMapItemType type, int? parentId, int? cultureId, int[] regions, bool includeChildrenCount, bool isArchive, PageInfo pageInfo, bool useHierarchyRegionsFilter)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var repository = Resolve<ISiteMapRepository>(isArchive ? UnitOfWorkNames.QpArchive.GetDescription() : null);
                var count = repository.GetSiteMapItemsCount(type, parentId, cultureId, regions, isArchive, useHierarchyRegionsFilter);

                int? pageSize = null;
                int? pageNumber = null;
                if (pageInfo != null)
                {
                    pageSize = pageInfo.PageSize;
                    if (count <= pageInfo.PageSize * (pageInfo.PageNumber - 1))
                    {
                        pageNumber = pageInfo.PageNumber - 1;
                    }
                    else
                    {
                        pageNumber = pageInfo.PageNumber;
                    }
                }

                var pageInfoVm = pageInfo == null ? null : new PageInfo
                {
                    PageSize = pageSize.Value,
                    PageNumber = pageNumber.Value,
                    TotalCount = count
                };

                var items = repository.GetSiteMapItems(type, parentId, cultureId, regions, isArchive, pageSize, pageNumber, useHierarchyRegionsFilter);
                if (items == null || !items.Any())
                {
                    return new ServiceEnumerationResult<AbstractItem>
                    {
                        IsSucceeded = true,
                        Result = new List<AbstractItem>(),
                        PageInfo = pageInfoVm
                    };
                }

                var result = MappingHelper.Map<QPAbstractItem, AbstractItem>(items);
                if (includeChildrenCount && pageInfoVm == null)
                {
                    var childrenCounts = repository.GetChildrenCountByParents(type, items.Select(s => s.Id).ToArray(), cultureId, regions, isArchive, useHierarchyRegionsFilter);
                    result = result.Select(s =>
                    {
                        s.HasChildren = childrenCounts.Any(a => a.Id == s.Id & a.ChildrenCount > 0);
                        return s;
                    }).ToList();

                    var contentVersions = repository.GetChildrenCountByParents(SiteMapItemType.ContentVersion, items.Select(s => s.Id).ToArray(), null, null, isArchive, useHierarchyRegionsFilter);
                    result = result.Select(s =>
                    {
                        s.HasContentVersions = contentVersions.Any(a => a.Id == s.Id & a.ChildrenCount > 0);
                        return s;
                    }).ToList();
                }

                return new ServiceEnumerationResult<AbstractItem>
                {
                    IsSucceeded = true,
                    Result = result,
                    PageInfo = pageInfoVm
                };
            });
        }

        public virtual ServiceEnumerationResult<AbstractItem> GetWidgets(UserContext userContext, int? parentId, int? cultureId, int[] regions, PageInfo pageInfo, bool useHierarchyRegionsFilter)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var repository = Resolve<ISiteMapRepository>(UnitOfWorkNames.QpArchive.GetDescription());
                var count = repository.GetWidgetsCount(parentId, cultureId, regions, useHierarchyRegionsFilter);

                int? pageSize = null;
                int? pageNumber = null;
                if (pageInfo != null)
                {
                    pageSize = pageInfo.PageSize;
                    if (count <= pageInfo.PageSize * (pageInfo.PageNumber - 1))
                    {
                        pageNumber = pageInfo.PageNumber - 1;
                    }
                    else
                    {
                        pageNumber = pageInfo.PageNumber;
                    }
                }

                var pageInfoVm = pageInfo == null ? null : new PageInfo
                {
                    PageSize = pageSize.Value,
                    PageNumber = pageNumber.Value,
                    TotalCount = count
                };

                var items = repository.GetWidgets(parentId, cultureId, regions, pageSize, pageNumber, useHierarchyRegionsFilter);
                return new ServiceEnumerationResult<AbstractItem>
                {
                    IsSucceeded = true,
                    Result = items == null ? new List<AbstractItem>() : MappingHelper.Map<QPAbstractItem, AbstractItem>(items),
                    PageInfo = pageInfoVm
                };
            });
        }

        public virtual ServiceEnumerationResult<Region> GetSiteMapItemRegions(UserContext userContext, int id, PageInfo pageInfo)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var repository = Resolve<ISiteMapRepository>();
                var count = repository.GetRegionsCount(id);

                int? pageSize = null;
                int? pageNumber = null;
                if (pageInfo != null)
                {
                    pageSize = pageInfo.PageSize;
                    if (count <= pageInfo.PageSize * (pageInfo.PageNumber - 1))
                    {
                        pageNumber = pageInfo.PageNumber - 1;
                    }
                    else
                    {
                        pageNumber = pageInfo.PageNumber;
                    }
                }

                var pageInfoVm = pageInfo == null ? null : new PageInfo
                {
                    PageSize = pageSize.Value,
                    PageNumber = pageNumber.Value,
                    TotalCount = count
                };

                var items = repository.GetRegions(id, pageSize, pageNumber);
                return new ServiceEnumerationResult<Region>
                {
                    IsSucceeded = true,
                    Result = items == null ? new List<Region>() : MappingHelper.Map<QPRegion, Region>(items),
                    PageInfo = pageInfoVm
                };
            });
        }

        public ServiceResult<AbstractItem> GetSiteMapItem(UserContext userContext, int id, bool isArchive, bool includeChildrenCount, bool useHierarchyRegionsFilter)
        {
            return Run2<AbstractItem>(userContext, null, () =>
            {
                var repository = Resolve<ISiteMapRepository>(isArchive ? UnitOfWorkNames.QpArchive.GetDescription() : null);
                var item = repository.GetById(id);
                if (item == null || item.Id == 0)
                {
                    return new ServiceResult<AbstractItem>
                    {
                        IsSucceeded = false,
                        Error = new ServiceError
                        {
                            Type = ServiceErrorType.BusinessLogicMessage,
                            Message = ErrorMessages.ElementNotFound
                        }
                    };
                }

                var result = new ServiceResult<AbstractItem>
                {
                    Result = MappingHelper.Map<QPAbstractItem, AbstractItem>(item),
                    IsSucceeded = true
                };

                if (includeChildrenCount)
                {
                    var childrenCounts = repository.GetChildrenCountByParents(SiteMapItemType.None, new[] { item.Id }, item.Culture_ID, item.RegionsIDs.Select(int.Parse).ToArray(), isArchive, useHierarchyRegionsFilter);
                    result.Result.HasChildren = childrenCounts.Any(a => a.Id == result.Result.Id & a.ChildrenCount > 0);

                    var contentVersions = repository.GetChildrenCountByParents(SiteMapItemType.ContentVersion, new[] { item.Id }, null, null, isArchive, useHierarchyRegionsFilter);
                    result.Result.HasContentVersions = contentVersions.Any(a => a.Id == result.Result.Id & a.ChildrenCount > 0);
                }

                return result;
            });
        }

        public virtual ServiceResult<AbstractItem> GetRootPage(UserContext userContext)
        {
            return Run2(userContext, null, () =>
            {
                var repository = Resolve<ISiteMapRepository>();
                var item = repository.GetRootPage();
                if (item == null || item.Id == 0)
                {
                    return new ServiceResult<AbstractItem>
                    {
                        Result = null,
                        IsSucceeded = true
                    };
                }

                return new ServiceResult<AbstractItem>
                {
                    Result = MappingHelper.Map<QPAbstractItem, AbstractItem>(item),
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceEnumerationResult<AbstractItem> GetSiteMapItems(UserContext userContext, string name, int parentId)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var repository = Resolve<ISiteMapRepository>();
                var result = repository.GetByName(name, parentId);

                return new ServiceEnumerationResult<AbstractItem>
                {
                    Result = MappingHelper.Map<QPAbstractItem, AbstractItem>(result),
                    IsSucceeded = true
                };
            });
        }

        public ServiceEnumerationResult<DiscriminatorDTO> GetAllowChildrenDiscriminators(UserContext userContext, int itemId, bool? isPage)
        {
            return RunEnumeration(userContext, null, () =>
            {
                var item = Resolve<ISiteMapRepository>().GetById(itemId);
                if (item == null || item.Id == 0)
                {
                    throw new NullReferenceException(ValidationMessages.ElementNotFound);
                }

                var items = item.Discriminator.AllowedItemDefinitions1.Count == 0
                    ? Resolve<IDictionaryRepository>().GetDiscriminators()
                    : item.Discriminator.AllowedItemDefinitions1.Select(s => s).ToList();

                return new ServiceEnumerationResult<DiscriminatorDTO>
                {
                    Result = MappingHelper.Map<QPDiscriminator, DiscriminatorDTO>(items.Where(w => isPage == null || (w.IsPage ?? false) == (bool)isPage).ToList()),
                    PageInfo = null,
                    IsSucceeded = true
                };
            });
        }

        public virtual IServiceResult<object> ChangeSiteMapItemParent(UserContext userContext, int itemId, int newParentId, bool useHierarchyRegionsFilter = false)
        {
            return Run2(userContext, null, () =>
            {
                ValidateOnChangeParent(itemId, newParentId, useHierarchyRegionsFilter);
                Resolve<ISiteMapRepository>().ChangeSiteMapItemParent(itemId, newParentId);
                Commit(UnitOfWorkNames.Qp.GetDescription());
                return new ServiceResult<object>
                {
                    Result = null,
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceResult<object> ReorderItem(UserContext userContext, int itemId, int relatedItemId, bool isInsertBefore, bool useHierarchyRegionsFilter)
        {
            return Run2(userContext, null, () =>
            {
                ValidateOnReorder(itemId, relatedItemId);
                var item = Resolve<ISiteMapRepository>().GetById(itemId);
                var list = Resolve<ISiteMapRepository>().GetSiteMapItems(SiteMapItemType.SiteMap, item.Parent_ID, null, null, false, null, null, useHierarchyRegionsFilter);

                var result = MappingHelper.Map<QPAbstractItem, AbstractItem>(list);
                result.Remove(result.SingleOrDefault(w => w.Id == itemId));
                var relatedIndex = result.IndexOf(result.SingleOrDefault(w => w.Id == relatedItemId));
                result.Insert(isInsertBefore ? relatedIndex : (relatedIndex + 1 >= result.Count ? result.Count : relatedIndex + 1), MappingHelper.Map<QPAbstractItem, AbstractItem>(item));

                for (var i = 0; i <= result.Count - 1; i++)
                {
                    var i1 = i;
                    var listItem = list.SingleOrDefault(w => w.Id == result[i1].Id);
                    listItem.IndexOrder = i;
                }

                Commit(UnitOfWorkNames.Qp.GetDescription());
                return new ServiceResult<object>
                {
                    Result = null,
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceResult<object> PublishSiteMapItem(UserContext userContext, int itemId)
        {
            return Run2(userContext, null, () =>
            {
                ValidateOnPublish(itemId);
                var repository = Resolve<ISiteMapRepository>();
                var item = repository.GetById(itemId);
                if (item.ExtensionId != null)
                {
                    var manager = new QPMetadataManager(CurrentServiceToken.ConnectionName);
                    var siteName = manager.GetSiteName(CurrentServiceToken.SiteId);
                    var contentName = manager.GetContentName(item.ExtensionId.Value);
                    Resolve<QPContentManager>()
                        .Connection(manager.ConnectionString)
                        .SiteName(siteName)
                        .IsIncludeArchive(true)
                        .IsShowSplittedArticle(true)
                        .StatusName(string.Join(",", new[]
                        {
                                ContentItemStatus.None,
                                ContentItemStatus.Published,
                                ContentItemStatus.Created,
                                ContentItemStatus.Approved
                        }))
                        .ContentName(contentName)
                        .Where("ItemId = " + itemId)
                        .ChangeStatus(ContentItemStatus.Published);
                }

                repository.PublishSiteMapItem(itemId);
                Commit(UnitOfWorkNames.Qp.GetDescription());
                return new ServiceResult<object>
                {
                    Result = null,
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceResult<object> PublishSiteMapItems(UserContext userContext, int[] itemIds)
        {
            return Run2(userContext, null, () =>
            {
                if (itemIds == null || itemIds.Length == 0)
                {
                    return new ServiceResult<object>
                    {
                        Result = null,
                        IsSucceeded = true
                    };
                }

                var repository = Resolve<ISiteMapRepository>();
                foreach (var id in itemIds)
                {
                    var item = repository.GetById(id);
                    if (item.ExtensionId != null)
                    {
                        var manager = new QPMetadataManager(CurrentServiceToken.ConnectionName);
                        var siteName = manager.GetSiteName(CurrentServiceToken.SiteId);
                        var contentName = manager.GetContentName(item.ExtensionId.Value);
                        Resolve<QPContentManager>()
                            .Connection(manager.ConnectionString)
                            .SiteName(siteName)
                            .IsIncludeArchive(true)
                            .IsShowSplittedArticle(true)
                            .StatusName(string.Join(",", new[]
                            {
                                ContentItemStatus.None,
                                ContentItemStatus.Published,
                                ContentItemStatus.Created,
                                ContentItemStatus.Approved
                            }))
                            .ContentName(contentName)
                            .Where("ItemId = " + id)
                            .ChangeStatus(ContentItemStatus.Published);
                    }
                }

                repository.PublishSiteMapItems(itemIds);
                Commit(UnitOfWorkNames.Qp.GetDescription());
                return new ServiceResult<object>
                {
                    Result = null,
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceResult<AbstractItem> AddItem(UserContext userContext, string title, string name, int discriminatorId, int parentId)
        {
            return Run2(userContext, null, () =>
            {
                ValidateOnAdd(parentId);
                var status = Resolve<IDictionaryRepository>().GetStatusType(CurrentServiceToken.SiteId, ContentItemStatus.Published.GetDescription());
                if (status == null || status.Id == 0)
                {
                    throw new Exception(string.Format(ErrorMessages.StatusNotFound, ContentItemStatus.Published.GetDescription()));
                }

                var item = Resolve<ISiteMapRepository>().Create(title, name, discriminatorId, parentId, status);
                Commit(UnitOfWorkNames.Qp.GetDescription());
                return new ServiceResult<AbstractItem>
                {
                    Result = MappingHelper.Map<QPAbstractItem, AbstractItem>(item),
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceResult<object> Remove(UserContext userContext, int id, bool isDeleteAllVersions, bool isDeleteContentVersions, int? contentVersionId, bool useHierarchyRegionsFilter)
        {
            return Run2(userContext, null, () =>
            {
                ValidateOnRemove(id, isDeleteContentVersions, contentVersionId);
                Resolve<IUnitOfWork>(UnitOfWorkNames.Qp.GetDescription()).BeginTransaction(IsolationLevel.Serializable);

                try
                {
                    var manager = new QPMetadataManager(CurrentServiceToken.ConnectionName);
                    var siteName = manager.GetSiteName(CurrentServiceToken.SiteId);

                    Action<QPAbstractItem> ext = i =>
                    {
                        if (i.ExtensionId != null)
                        {
                            var contentName = manager.GetContentName(i.ExtensionId.Value);
                            Resolve<QPContentManager>().Connection(manager.ConnectionString).SiteName(siteName).ContentName(contentName).StatusName(ContentItemStatus.None).Fields("ExtensionId").Where("ItemId = " + i.Id).Archive();
                            Resolve<QPContentManager>().Connection(manager.ConnectionString).SiteName(siteName).ContentName(contentName).StatusName(ContentItemStatus.Published).Fields("ExtensionId").Where("ItemId = " + i.Id).Archive();
                        }
                    };

                    Action<QPAbstractItem> func = null;
                    func = parent =>
                    {
                        // Удаляем починенные элементы, в том числе виджеты
                        var items = Resolve<ISiteMapRepository>().GetSiteMapItems(SiteMapItemType.None, parent.Id, null, null, false, null, null, useHierarchyRegionsFilter).Where(w => w.VersionOf_ID == null).ToList();
                        foreach (var i in items)
                        {
                            i.Archive = true;
                            func(i);

                            // удаляем контентные версии
                            var contentVersions = Resolve<ISiteMapRepository>().GetSiteMapItems(SiteMapItemType.ContentVersion, i.Id, null, null, false, null, null, useHierarchyRegionsFilter);
                            foreach (var v in contentVersions)
                            {
                                v.Archive = true;
                                ext(v);
                            }

                            ext(i);
                        }
                    };

                    var item = Resolve<ISiteMapRepository>().GetById(id);

                    item.Archive = true;
                    ext(item);

                    // если указано НЕ удаление всех версий элемента, то удаляем только его и всех его потомков
                    if (!isDeleteAllVersions)
                    {
                        func(item);
                        if (isDeleteContentVersions)
                        {
                            // если указано удаление контентных версий, то удаляем контентные версии и всех их потомков
                            var items = Resolve<ISiteMapRepository>().GetSiteMapItems(SiteMapItemType.ContentVersion, item.Id, null, null, false, null, null, useHierarchyRegionsFilter);
                            foreach (var i in items)
                            {
                                i.Archive = true;
                                func(i);
                                ext(i);
                            }
                        }
                        else
                        {
                            // делаем из контентной версии полноценную версию
                            var newStartItem = Resolve<ISiteMapRepository>().GetById(contentVersionId.Value);
                            if (newStartItem.VersionOf_ID != null)
                            {
                                newStartItem.Name = item.Name;
                                newStartItem.Parent_ID = item.Parent_ID;
                                newStartItem.VersionOf_ID = null;
                                newStartItem.IsPage = true;
                            }

                            var items = Resolve<ISiteMapRepository>().GetSiteMapItems(SiteMapItemType.ContentVersion, item.Id, null, null, false, null, null, useHierarchyRegionsFilter);
                            foreach (var i in items)
                            {
                                if (i.Id == newStartItem.Id)
                                {
                                    continue;
                                }

                                i.VersionOf_ID = newStartItem.Id;
                            }
                        }
                    }
                    else
                    {
                        // удаляем все версии данного элемента
                        var items = Resolve<ISiteMapRepository>().GetByName(item.Name, item.Parent_ID ?? -1);
                        func(item);

                        var versions = Resolve<ISiteMapRepository>().GetSiteMapItems(SiteMapItemType.ContentVersion, item.Id, null, null, false, null, null, useHierarchyRegionsFilter);
                        foreach (var i in versions)
                        {
                            i.Archive = true;
                            func(i);
                            ext(i);
                        }

                        foreach (var i in items)
                        {
                            if (i.Id == item.Id)
                            {
                                continue;
                            }

                            i.Archive = true;
                            func(i);
                        }
                    }

                    Commit(UnitOfWorkNames.Qp.GetDescription());
                    Resolve<IUnitOfWork>(UnitOfWorkNames.Qp.GetDescription()).CommitTransaction();
                }
                catch (Exception)
                {
                    Resolve<IUnitOfWork>(UnitOfWorkNames.Qp.GetDescription()).RollbackTransaction();
                    throw;
                }

                return new ServiceResult<object>
                {
                    Result = null,
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceResult<object> Delete(UserContext userContext, int id, bool isDeleteAllVersions, bool useHierarchyRegionsFilter)
        {
            return Run2(userContext, null, () =>
            {
                ValidateOnDelete(id);
                Resolve<IUnitOfWork>(UnitOfWorkNames.QpArchive.GetDescription()).BeginTransaction(IsolationLevel.Serializable);

                try
                {
                    var manager = new QPMetadataManager(CurrentServiceToken.ConnectionName);
                    var siteName = manager.GetSiteName(CurrentServiceToken.SiteId);
                    var repository = Resolve<ISiteMapRepository>(UnitOfWorkNames.QpArchive.GetDescription());

                    Action<QPAbstractItem> ext = i =>
                    {
                        // удаление раширений
                        if (i.ExtensionId != null)
                        {
                            var contentName = manager.GetContentName(i.ExtensionId.Value);
                            Resolve<QPContentManager>().Connection(manager.ConnectionString).SiteName(siteName).StatusName(ContentItemStatus.None).IsIncludeArchive(true).ContentName(contentName).Where("ItemId = " + i.Id + " AND Archive = 1").Delete();
                            Resolve<QPContentManager>().Connection(manager.ConnectionString).SiteName(siteName).StatusName(ContentItemStatus.Published).IsIncludeArchive(true).ContentName(contentName).Where("ItemId = " + i.Id + " AND Archive = 1").Delete();
                        }
                    };

                    Action<QPAbstractItem> func = null;
                    func = parent =>
                    {
                        // Удаляем починенные элементы, в том числе виджеты
                        var items = repository.GetSiteMapItems(SiteMapItemType.None, parent.Id, null, null, true, null, null, useHierarchyRegionsFilter).Where(w => w.VersionOf_ID == null).ToList();
                        foreach (var i in items)
                        {
                            func(i);
                            ext(i);
                            repository.Delete(i.Id);
                        }

                        // удаляем контентные версии
                        var contentVersions = repository.GetSiteMapItems(SiteMapItemType.ContentVersion, parent.Id, null, null, true, null, null, useHierarchyRegionsFilter);
                        foreach (var v in contentVersions)
                        {
                            repository.Delete(v.Id);
                        }
                    };

                    var item = repository.GetById(id);
                    repository.Delete(item.Id);
                    ext(item);

                    // если указано НЕ удаление всех версий элемента, то удаляем только его и всех его потомков или виджет или контентная версия
                    if (!isDeleteAllVersions || item.IsPageExact || item.VersionOf_ID != null)
                    {
                        func(item);
                    }
                    else
                    {
                        // удаляем все версии данного элемента
                        if (!string.IsNullOrEmpty(item.Name))
                        {
                            var items = repository.GetByName(item.Name, item.Parent_ID ?? -1);
                            func(item);
                            foreach (var i in items)
                            {
                                if (i.Id == item.Id)
                                {
                                    continue;
                                }

                                repository.Delete(i.Id);
                                func(i);
                            }
                        }
                    }

                    Commit(UnitOfWorkNames.QpArchive.GetDescription());
                    Resolve<IUnitOfWork>(UnitOfWorkNames.QpArchive.GetDescription()).CommitTransaction();
                }
                catch (Exception)
                {
                    Resolve<IUnitOfWork>(UnitOfWorkNames.QpArchive.GetDescription()).RollbackTransaction();
                    throw;
                }

                return new ServiceResult<object>
                {
                    Result = null,
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceResult<object> Restore(UserContext userContext, int id, bool isRestoreAllVersions, bool isRestoreChildren, bool isRestoreContentVersions, bool isRestoreWidgets, bool useHierarchyRegionsFilter)
        {
            return Run2(userContext, null, () =>
            {
                ValidateOnRestore(id);
                Resolve<IUnitOfWork>(UnitOfWorkNames.QpArchive.GetDescription()).BeginTransaction(IsolationLevel.Serializable);
                var repository = Resolve<ISiteMapRepository>(UnitOfWorkNames.QpArchive.GetDescription());

                try
                {
                    var manager = new QPMetadataManager(CurrentServiceToken.ConnectionName);
                    var siteName = manager.GetSiteName(CurrentServiceToken.SiteId);

                    Action<QPAbstractItem> ext = i =>
                    {
                        // восстановление раширений
                        if (i.ExtensionId != null)
                        {
                            var contentName = manager.GetContentName(i.ExtensionId.Value);
                            Resolve<QPContentManager>().Connection(manager.ConnectionString).SiteName(siteName).StatusName(ContentItemStatus.None).IsIncludeArchive(true).ContentName(contentName).Where("ItemId = " + i.Id + " AND Archive = 1").Restore();
                            Resolve<QPContentManager>().Connection(manager.ConnectionString).SiteName(siteName).StatusName(ContentItemStatus.Published).IsIncludeArchive(true).ContentName(contentName).Where("ItemId = " + i.Id + " AND Archive = 1").Restore();
                        }
                    };

                    Action<QPAbstractItem> func = null;
                    func = parent =>
                    {
                        // Восстановливаем подчиненные элементы, в том числе виджеты
                        var items = repository.GetSiteMapItems(SiteMapItemType.None, parent.Id, null, null, true, null, null, useHierarchyRegionsFilter).Where(w => w.VersionOf_ID == null).ToList();
                        if (isRestoreChildren)
                        {
                            foreach (var i in items)
                            {
                                i.Archive = false;
                                func(i);
                                ext(i);
                            }
                        }

                        if (isRestoreContentVersions)
                        {
                            // Восстановливаем контентные версии
                            var contentVersions = repository.GetSiteMapItems(SiteMapItemType.ContentVersion, parent.Id, null, null, true, null, null, useHierarchyRegionsFilter);
                            foreach (var v in contentVersions)
                            {
                                v.Archive = false;
                                ext(v);
                            }
                        }
                    };

                    var item = repository.GetById(id);
                    item.Archive = false;
                    ext(item);

                    // если указано НЕ восстановление всех версий элемента, то восстанавливаем только его и его потомков
                    if (!isRestoreAllVersions || !item.IsPageExact || item.VersionOf_ID != null)
                    {
                        func(item);
                    }
                    else if (!string.IsNullOrEmpty(item.Name))
                    {
                        // восстанавливаем все версии данного элемента
                        var items = repository.GetByName(item.Name, item.Parent_ID ?? -1);
                        func(item);
                        foreach (var i in items)
                        {
                            if (i.Id == item.Id)
                            {
                                continue;
                            }

                            i.Archive = false;
                            func(i);
                        }
                    }

                    Commit(UnitOfWorkNames.QpArchive.GetDescription());
                    Resolve<IUnitOfWork>(UnitOfWorkNames.QpArchive.GetDescription()).CommitTransaction();
                }
                catch (Exception)
                {
                    Resolve<IUnitOfWork>(UnitOfWorkNames.QpArchive.GetDescription()).RollbackTransaction();
                    throw;
                }

                return new ServiceResult<object>
                {
                    Result = null,
                    IsSucceeded = true
                };
            });
        }

        public virtual ServiceResult<object> Edit(UserContext userContext, int itemId, string title)
        {
            return Run2(userContext, null, () =>
            {
                Resolve<ISiteMapRepository>().EditItem(itemId, title);
                Commit(UnitOfWorkNames.Qp.GetDescription());
                return new ServiceResult<object>
                {
                    Result = null,
                    IsSucceeded = true
                };
            });
        }

        public ServiceResult<object> UpdateItemRegions(UserContext userContext, int id, int[] selectedRegionIDs)
        {
            return Run2(userContext, null, () =>
            {
                BaseSiteMapValidate(id);
                var repository = Resolve<IRegionRepository>();
                var list = repository.GetRegionReferences(id);
                Resolve<IUnitOfWork>(UnitOfWorkNames.Qp.GetDescription()).BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    foreach (var item in list)
                    {
                        repository.Delete(item);
                    }

                    if (selectedRegionIDs != null)
                    {
                        foreach (var s in selectedRegionIDs)
                        {
                            repository.Create(new AbstractItemAbtractItemRegionArticle
                            {
                                QPAbstractItem_ID = id,
                                QPRegion_ID = s
                            });
                        }
                    }


                    Commit(UnitOfWorkNames.Qp.GetDescription());
                    Resolve<IUnitOfWork>(UnitOfWorkNames.Qp.GetDescription()).CommitTransaction();
                    return new ServiceResult<object>
                    {
                        Result = null,
                        IsSucceeded = true
                    };
                }
                catch (Exception)
                {
                    Resolve<IUnitOfWork>(UnitOfWorkNames.Qp.GetDescription()).RollbackTransaction();
                    throw;
                }
            });
        }

        public ServiceResult<object> DeleteItemRegion(UserContext userContext, int id, int regionId)
        {
            return Run2(userContext, null, () =>
              {
                  BaseSiteMapValidate(id);
                  Resolve<IRegionRepository>().Delete(id, regionId);
                  Commit(UnitOfWorkNames.Qp.GetDescription());
                  return new ServiceResult<object>
                  {
                      Result = null,
                      IsSucceeded = true
                  };
              });
        }

        protected virtual void BaseSiteMapValidate(int id)
        {
            Throws.IfArgumentNot(id > 0, _ => id);

            var repository = Resolve<ISiteMapRepository>();
            var item = repository.GetById(id);
            if (item == null || item.Id == 0)
            {
                throw new OperationExecutionException(-1, ValidationMessages.ElementNotFound);
            }
        }

        protected virtual void ValidateOnRemove(int id, bool isDeleteContentVersions, int? contentVersionId)
        {
            Throws.IfArgumentNot(id > 0, _ => id);
            if (!isDeleteContentVersions && contentVersionId == null)
            {
                throw new OperationExecutionException(0, ValidationMessages.ChangingVersionNotSpecified);
            }

            var repository = Resolve<ISiteMapRepository>();
            var item = repository.GetById(id);
            if (item == null || item.Id == 0)
            {
                throw new OperationExecutionException(-1, ValidationMessages.ElementNotFound);
            }

            if (contentVersionId != null)
            {
                var contentVersion = repository.GetById(contentVersionId.Value);
                if (contentVersion == null || contentVersion.Id == 0)
                {
                    throw new OperationExecutionException(-1, ValidationMessages.ContentVersionNotFound);
                }
            }

            var rootPageId = repository.GetRootPage().Id;
            if (id == rootPageId)
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyDeleteRootPage);
            }
        }

        protected virtual void ValidateOnDelete(int id)
        {
            Throws.IfArgumentNot(id > 0, _ => id);

            var repository = Resolve<ISiteMapRepository>(UnitOfWorkNames.QpArchive.GetDescription());
            var item = repository.GetById(id);
            if (item == null || item.Id == 0)
            {
                throw new OperationExecutionException(-1, ValidationMessages.ElementNotFound);
            }

            var rootPageId = repository.GetRootPage().Id;
            if (id == rootPageId)
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyDeleteRootPage);
            }
        }

        protected virtual void ValidateOnPublish(int id)
        {
            Throws.IfArgumentNot(id > 0, _ => id);

            var repository = Resolve<ISiteMapRepository>();
            var item = repository.GetById(id);
            if (item == null || item.Id == 0)
            {
                throw new OperationExecutionException(0, ValidationMessages.ElementNotFound);
            }
        }

        protected virtual void ValidateOnRestore(int id)
        {
            Throws.IfArgumentNot(id > 0, _ => id);

            var repository = Resolve<ISiteMapRepository>(UnitOfWorkNames.QpArchive.GetDescription());
            var item = repository.GetById(id);
            if (item == null || item.Id == 0)
            {
                throw new OperationExecutionException(0, ValidationMessages.ElementNotFound);
            }

            if (item.VersionOf_ID != null || item.Parent_ID != null)
            {
                var parent = Resolve<ISiteMapRepository>().GetById(item.VersionOf_ID ?? item.Parent_ID.Value);
                if (parent == null || parent.Id == 0)
                {
                    throw new OperationExecutionException(0, ValidationMessages.DenyRestoreItemWithoutNonDeleteParentItem);
                }
            }
        }

        protected virtual void ValidateOnAdd(int parentId)
        {
            var repository = Resolve<ISiteMapRepository>();
            var item = repository.GetById(parentId);
            if (item == null || item.Id == 0)
            {
                throw new OperationExecutionException(0, ValidationMessages.ParentElementNotFound);
            }

            if (item.VersionOf_ID != null)
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyAddItemToContentVersion);
            }
        }

        protected virtual void ValidateOnChangeParent(int itemToMoveId, int newParentId, bool useHierarchyRegionsFilter)
        {
            Throws.IfArgumentNot(itemToMoveId > 0, _ => itemToMoveId);
            Throws.IfArgumentNot(newParentId > 0, _ => newParentId);

            var repository = Resolve<ISiteMapRepository>();
            var item = repository.GetById(itemToMoveId);
            if (item == null || item.Id == 0)
            {
                throw new OperationExecutionException(0, ValidationMessages.SourceElementNotFound);
            }

            var parent = repository.GetById(newParentId);
            if (parent == null || parent.Id == 0)
            {
                throw new OperationExecutionException(0, ValidationMessages.TargetElementNotFound);
            }

            if (item.Id == parent.Id)
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyMoveElementToItSelf);
            }

            if (item.Parent_ID == null)
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyMoveMainPage);
            }

            var rootPageId = repository.GetRootPage().Id;
            if (item.Parent_ID == rootPageId)
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyMoveStartPage);
            }

            if (repository.IsHierarchyConstainsItem(itemToMoveId, newParentId))
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyMoveElementToChild);
            }

            if (item.Parent_ID == parent.Id)
            {
                throw new OperationExecutionException(0, ValidationMessages.SourceElementHasCurrentParent);
            }

            if (item.Culture_ID != parent.Culture_ID & parent.Id != rootPageId & item.Culture_ID != null & parent.Culture_ID != null)
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyMoveElementToOtherCulture);
            }

            if (parent.Id != rootPageId)
            {
                if (!repository.CanItemBeIncludeToItem(itemToMoveId, newParentId))
                {
                    throw new OperationExecutionException(0, ValidationMessages.DenyMoveElementToWrongType);
                }
            }

            if (!useHierarchyRegionsFilter && parent.Id != rootPageId && parent.Regions.Count > 0)
            {
                item.Regions.ToList().ForEach(a =>
                {
                    if (parent.Regions.All(r => r.Id != a.Id))
                    {
                        throw new OperationExecutionException(0, ValidationMessages.DenyMoveElementToOtherRegion);
                    }
                });
            }
        }

        protected virtual void ValidateOnReorder(int itemId, int relatedItemId)
        {
            Throws.IfArgumentNot(itemId > 0, _ => itemId);
            Throws.IfArgumentNot(relatedItemId > 0, _ => relatedItemId);

            var item = Resolve<ISiteMapRepository>().GetById(itemId);
            var relatedItem = Resolve<ISiteMapRepository>().GetById(relatedItemId);
            if (item == null || item.Id == 0)
            {
                throw new OperationExecutionException(0, ValidationMessages.SourceElementNotFound);
            }

            if (relatedItem == null || relatedItem.Id == 0)
            {
                throw new OperationExecutionException(0, ValidationMessages.ReferenceElementNotFound);
            }

            if (item.Parent_ID != relatedItem.Parent_ID)
            {
                throw new OperationExecutionException(0, ValidationMessages.DenyMoveElementToOtherParent);
            }
        }
    }
}
