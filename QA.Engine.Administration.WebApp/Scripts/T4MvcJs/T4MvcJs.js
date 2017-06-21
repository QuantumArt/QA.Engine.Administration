var MvcJs = {
	Dictionary: {
		AjaxCultures: function() {
			var url = "/Dictionary/AjaxCultures";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxDiscriminators: function(viewModel) {
			var url = "/Dictionary/AjaxDiscriminators?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxDiscriminatorConstraints: function() {
			var url = "/Dictionary/AjaxDiscriminatorConstraints";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxKendoUIRegions: function(viewModel) {
			var url = "/Dictionary/AjaxKendoUIRegions?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxRegions: function(viewModel) {
			var url = "/Dictionary/AjaxRegions?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		NameConst: "Dictionary"
	},
	Error: {
		Error: function() {
			var url = "/Error/Error";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		NameConst: "Error"
	},
	Home: {
		Index: function() {
			var url = "/";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxSites: function() {
			var url = "/Home/AjaxSites";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxSetSite: function(viewModel) {
			var url = "/Home/AjaxSetSite?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		NoData: function() {
			var url = "/Home/NoData";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		NameConst: "Home"
	},
	SiteMap: {
		Index: function() {
			var url = "/SiteMap";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		Archive: function() {
			var url = "/SiteMap/Archive";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxTree: function(filter) {
			var url = "/SiteMap/AjaxTree?filter={filter}";

			if (filter) {
			  url = url.replace("{filter}", filter);
			} else {
			  url = url.replace("filter={filter}", "").replace("{filter}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxArchiveTree: function(filter) {
			var url = "/SiteMap/AjaxArchiveTree?filter={filter}";

			if (filter) {
			  url = url.replace("{filter}", filter);
			} else {
			  url = url.replace("filter={filter}", "").replace("{filter}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxGetItem: function(viewModel) {
			var url = "/SiteMap/AjaxGetItem?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxTreeMoveItem: function(viewModel) {
			var url = "/SiteMap/AjaxTreeMoveItem?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		Filter: function() {
			var url = "/SiteMap/Filter";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		Toolbar: function() {
			var url = "/SiteMap/Toolbar";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxTreeReorderItem: function(viewModel) {
			var url = "/SiteMap/AjaxTreeReorderItem?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxPublishItem: function(viewModel) {
			var url = "/SiteMap/AjaxPublishItem?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxAdd: function(viewModel) {
			var url = "/SiteMap/AjaxAdd?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxEdit: function(viewModel) {
			var url = "/SiteMap/AjaxEdit?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxEditItem: function(viewModel) {
			var url = "/SiteMap/AjaxEditItem?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxMove: function() {
			var url = "/SiteMap/AjaxMove";

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxGetSiteMap: function(name, parentId) {
			var url = "/SiteMap/AjaxGetSiteMap?name={name}&parentId={parentId}";

			if (name) {
			  url = url.replace("{name}", name);
			} else {
			  url = url.replace("name={name}", "").replace("{name}", "").replace("?&","?").replace("&&","&");
			}

			if (parentId) {
			  url = url.replace("{parentId}", parentId);
			} else {
			  url = url.replace("parentId={parentId}", "").replace("{parentId}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxUpdateItemRegions: function(viewModel) {
			var url = "/SiteMap/AjaxUpdateItemRegions?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxDeleteItemRegion: function(viewModel) {
			var url = "/SiteMap/AjaxDeleteItemRegion?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxItemRegionIds: function(viewModel) {
			var url = "/SiteMap/AjaxItemRegionIds?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxItemCultureIds: function(viewModel) {
			var url = "/SiteMap/AjaxItemCultureIds?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxCultures: function(viewModel) {
			var url = "/SiteMap/AjaxCultures?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxRemove: function(viewModel) {
			var url = "/SiteMap/AjaxRemove?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxRemoveItem: function(viewModel) {
			var url = "/SiteMap/AjaxRemoveItem?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxDelete: function(viewModel) {
			var url = "/SiteMap/AjaxDelete?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxDeleteItem: function(viewModel) {
			var url = "/SiteMap/AjaxDeleteItem?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxRemoveContentVersion: function(viewModel) {
			var url = "/SiteMap/AjaxRemoveContentVersion?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxRestore: function(viewModel) {
			var url = "/SiteMap/AjaxRestore?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxRestoreItem: function(viewModel) {
			var url = "/SiteMap/AjaxRestoreItem?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		Info: function(viewModel) {
			var url = "/SiteMap/Info?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		ArchiveInfo: function(viewModel) {
			var url = "/SiteMap/ArchiveInfo?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		Regions: function(viewModel) {
			var url = "/SiteMap/Regions?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxRegionsGroups: function(viewModel) {
			var url = "/SiteMap/AjaxRegionsGroups?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxRegions: function(viewModel) {
			var url = "/SiteMap/AjaxRegions?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxContentVersionsRegions: function(viewModel) {
			var url = "/SiteMap/AjaxContentVersionsRegions?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		Widgets: function(viewModel) {
			var url = "/SiteMap/Widgets?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxWidgets: function(viewModel) {
			var url = "/SiteMap/AjaxWidgets?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxPublishWidgetsByAbstractItem: function(id) {
			var url = "/SiteMap/AjaxPublishWidgetsByAbstractItem/{id}";

			if (id) {
			  url = url.replace("{id}", id);
			} else {
			  url = url.replace("id={id}", "").replace("{id}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxPublishWidgets: function(id) {
			var url = "/SiteMap/AjaxPublishWidgets/{id}";

			if (id) {
			  url = url.replace("{id}", id);
			} else {
			  url = url.replace("id={id}", "").replace("{id}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		ContentVersions: function(viewModel) {
			var url = "/SiteMap/ContentVersions?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		AjaxContentVersions: function(viewModel) {
			var url = "/SiteMap/AjaxContentVersions?viewModel={viewModel}";

			if (viewModel) {
			  url = url.replace("{viewModel}", viewModel);
			} else {
			  url = url.replace("viewModel={viewModel}", "").replace("{viewModel}", "").replace("?&","?").replace("&&","&");
			}

			url = url.replace(/^\//, "");
			return url.replace(/([?&]+$)/g, "");
		},
		NameConst: "SiteMap"
	},
	Shared: {

	}};

MvcJs.ViewModels = {
        Models: {
                  SimpleViewModel: {
          Props: {
                      Data: { Id: "Data" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  GroupViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                Name: { Id: "Name" },
                                List: { Id: "List" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
              },
              Dictionary: {
                  DiscriminatorConstraintViewModel: {
          Props: {
                      SourceId: { Id: "SourceId" },
                                TargetId: { Id: "TargetId" },
                              }},
                  ReadDiscriminatorsViewModel: {
          Props: {
                      ParentId: { Id: "ParentId" },
                                IsPage: { Id: "IsPage" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  CultureViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                Title: { Id: "Title" },
                              }},
                  DiscriminatorViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                PreferredContentId: { Id: "PreferredContentId" },
                                Title: { Id: "Title" },
                              }},
                  RegionViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                Title: { Id: "Title" },
                                Alias: { Id: "Alias" },
                              }},
              },
              Home: {
                  SetCurrentSiteViewModel: {
          Props: {
                      Name: { Id: "Name" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
              },
              Kendo: {
                  KendoFilterItemViewModel: {
          Props: {
                      value: { Id: "value" },
                              }},
                  KendoFilterViewModel: {
          Props: {
                      filters: { Id: "filters" },
                              }},
              },
              SiteMap: {
                  DeleteSiteMapRegionViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                RegionId: { Id: "RegionId" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  DeleteSiteMapViewModel: {
          Props: {
                      IsDeleteAllVersions: { Id: "IsDeleteAllVersions" },
                                Id: { Id: "Id" },
                                IsVersion: { Id: "IsVersion" },
                                IsPage: { Id: "IsPage" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  AddSiteMapViewModel: {
          Props: {
                      Title: { Id: "Title" },
                                Name: { Id: "Name" },
                                DiscriminatorId: { Id: "DiscriminatorId" },
                                PreferredContentId: { Id: "PreferredContentId" },
                                StructuralVersionParentId: { Id: "StructuralVersionParentId" },
                                ParentId: { Id: "ParentId" },
                                Parent: { Id: "Parent" },
                                VersionTypeId: { Id: "VersionTypeId" },
                                IsVersion: { Id: "IsVersion" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  RestoreSiteMapViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                IsRestoreAllVersions: { Id: "IsRestoreAllVersions" },
                                IsRestoreWidgets: { Id: "IsRestoreWidgets" },
                                IsRestoreContentVersions: { Id: "IsRestoreContentVersions" },
                                IsVersion: { Id: "IsVersion" },
                                IsPage: { Id: "IsPage" },
                                IsRestoreAllChildren: { Id: "IsRestoreAllChildren" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  SiteMapRegionsViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                List: { Id: "List" },
                                Pager: { Id: "Pager" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  PublishItemViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  ReadInfoViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                IsArchive: { Id: "IsArchive" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  ReadSiteMapItemViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                IsIncludeChildrenCount: { Id: "IsIncludeChildrenCount" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  ReadRegionsViewModel: {
          Props: {
                      Text: { Id: "Text" },
                                Id: { Id: "Id" },
                                filter: { Id: "filter" },
                                PageIndex: { Id: "PageIndex" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  ReadWidgetsViewModel: {
          Props: {
                      PageIndex: { Id: "PageIndex" },
                                Id: { Id: "Id" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  ReadContentVersionsViewModel: {
          Props: {
                      PageIndex: { Id: "PageIndex" },
                                Id: { Id: "Id" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  RegionListViewModel: {
          Props: {
                      List: { Id: "List" },
                                Pager: { Id: "Pager" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  SiteMapContentVersionsViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                List: { Id: "List" },
                                Pager: { Id: "Pager" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  SiteMapWidgetsViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                List: { Id: "List" },
                                Pager: { Id: "Pager" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  EditableSiteMapViewModel: {
          Props: {
                      Title: { Id: "Title" },
                                Name: { Id: "Name" },
                                DiscriminatorId: { Id: "DiscriminatorId" },
                                Discriminators: { Id: "Discriminators" },
                                ParentId: { Id: "ParentId" },
                                Id: { Id: "Id" },
                                TypeName: { Id: "TypeName" },
                                ItemStateName: { Id: "ItemStateName" },
                                CultureName: { Id: "CultureName" },
                                IsVisible: { Id: "IsVisible" },
                                IsInSitemap: { Id: "IsInSitemap" },
                                Icon: { Id: "Icon" },
                                ElementTypeName: { Id: "ElementTypeName" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  RemoveSiteMapViewModel: {
          Props: {
                      OperationsByContentVersion: { Id: "OperationsByContentVersion" },
                                IsDeleteAllVersions: { Id: "IsDeleteAllVersions" },
                                ContentVersionId: { Id: "ContentVersionId" },
                                ContentVersions: { Id: "ContentVersions" },
                                Id: { Id: "Id" },
                                IsVersion: { Id: "IsVersion" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  FilterViewModel: {
          Props: {
                      ParentId: { Id: "ParentId" },
                                CultureId: { Id: "CultureId" },
                                Regions: { Id: "Regions" },
                                IsArchive: { Id: "IsArchive" },
                                Type: { Id: "Type" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  MoveItemViewModel: {
          Props: {
                      ItemId: { Id: "ItemId" },
                                NewParentId: { Id: "NewParentId" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  ReorderViewModel: {
          Props: {
                      ItemId: { Id: "ItemId" },
                                RelatedItemId: { Id: "RelatedItemId" },
                                IsInsertBefore: { Id: "IsInsertBefore" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  SiteMapRegionsGroupViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                Name: { Id: "Name" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
                  SiteMapViewModel: {
          Props: {
                      Id: { Id: "Id" },
                                ParentId: { Id: "ParentId" },
                                Name: { Id: "Name" },
                                Icon: { Id: "Icon" },
                                StatusName: { Id: "StatusName" },
                                StatusIcon: { Id: "StatusIcon" },
                                RegionsString: { Id: "RegionsString" },
                                Regions: { Id: "Regions" },
                                Title: { Id: "Title" },
                                View: { Id: "View" },
                                Culture: { Id: "Culture" },
                                CultureId: { Id: "CultureId" },
                                IsVersion: { Id: "IsVersion" },
                                IsVisible: { Id: "IsVisible" },
                                IsVisibility: { Id: "IsVisibility" },
                                IsPage: { Id: "IsPage" },
                                HasChildren: { Id: "HasChildren" },
                                HasContentVersions: { Id: "HasContentVersions" },
                                ZoneName: { Id: "ZoneName" },
                                DiscriminatorName: { Id: "DiscriminatorName" },
                                DiscriminatorTitle: { Id: "DiscriminatorTitle" },
                                SortOrder: { Id: "SortOrder" },
                                SortOrderView: { Id: "SortOrderView" },
                                DiscriminatorId: { Id: "DiscriminatorId" },
                                ExtensionId: { Id: "ExtensionId" },
                                VersionOfId: { Id: "VersionOfId" },
                                HostId: { Id: "HostId" },
                                BackendSid: { Id: "BackendSid" },
                                CustomerCode: { Id: "CustomerCode" },
                                QpKey: { Id: "QpKey" },
                                SiteId: { Id: "SiteId" },
                                IsSucceeded: { Id: "IsSucceeded" },
                                Error: { Id: "Error" },
                                IsHideControls: { Id: "IsHideControls" },
                                IsAuthenticated: { Id: "IsAuthenticated" },
                              }},
              },
        };




