if (jQuery.type(sitemap) === 'undefined') {
  var sitemap = {};
}

if (jQuery.type(sitemap.regions) === 'undefined') {
  sitemap.regions = (function() {
    function regionSelectionCallback(eventType, args) {
      if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.SelectWindowClosed === eventType) {
        return;
      }

      if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.EntitiesSelected === eventType) {
        common.showProgress();
        ajax.post(MvcJs.SiteMap.AjaxUpdateItemRegions(), {
          SelectedRegionIDs: args.selectedEntityIDs,
          Id: $('#SiteMapRegionsViewModel_AbstractItemId').val(),
        }, function(result) {
          if (ajax.showError(result)) {
            return;
          }

          var grid = $('#contentRegions').data('kendoGrid');
          grid.dataSource.read();
          common.hideProgress();
        });
      }
    }

    function deleteRow() {
      var grid = $('#contentRegions').data('kendoGrid');
      var row = grid.select();
      if (!row.length) {
        return;
      }

      common.confirm({
        okCallback: function() {
          common.showProgress();
          ajax.post(MvcJs.SiteMap.AjaxDeleteItemRegion(), {
            Id: $('#SiteMapRegionsViewModel_AbstractItemId').val(),
            RegionId: grid.dataItem(row).Id
          }, function(result) {
            if (ajax.showError(result)) {
              return;
            }

            var grid = $('#contentRegions').data('kendoGrid');
            grid.dataSource.read();
            common.hideProgress();
          });
        }
      });
    }

    function detailInit(e) {
      var detailRow = e.detailRow;
      detailRow.find('#tabStripRegions').kendoTabStrip();

      var grid;
      var dataSource;
      if (+e.data.get('Id') === 0) {
        dataSource = QP.Data.createDataSource(MvcJs.SiteMap.AjaxRegions(), function(options, operation) {
          if (operation === 'read') {
            return {
              Id: $('#SiteMapRegionsViewModel_AbstractItemId').val(),
              PageIndex: options.page
            };
          }

          return options;
        }, function(data) {
          return data.List;
        }, false, function(data) {
          return data.Pager.TotalCount;
        }, AppSettings.DefaultPageSize);

        grid = detailRow.find('#contentRegions').kendoGrid({
          toolbar: kendo.template(
            '<div>' +
              '<button class="k-button" id="btnAdd" type="button">' + SiteMap.Regions.AddButton + '</button>' +
              '<button class="k-button" id="btnDelete" type="button">' + SiteMap.Regions.DeleteButton + '</button>' +
              '<button class="k-button" id="btnRefresh" type="button">' + SiteMap.Regions.RefreshButton + '</button>' +
            '</div>'),
          dataSource: dataSource,
          height: 250,
          columns: [{
            field: MvcJs.ViewModels.Dictionary.RegionViewModel.Props.Id.Id,
            title: SiteMap.Regions.NameColumnId
          }, {
            field: MvcJs.ViewModels.Dictionary.RegionViewModel.Props.Title.Id,
            title: SiteMap.Regions.NameColumnTitle
          }, {
            field: MvcJs.ViewModels.Dictionary.RegionViewModel.Props.Alias.Id,
            title: SiteMap.Regions.NameColumnAlias
          }],
          pageable: {
            refresh: true,
            pageSize: AppSettings.DefaultPageSize
          },
          selectable: 'row',
          navigatable: true
        });

        $(grid).find('#btnRefresh').bind('click', dataSource.read);
        $(grid).find('#btnDelete').bind('click', deleteRow);

        $(grid).find('#btnAdd').bind('click', function() {
          QP.Client.showRegionsSelector($('#SiteMapRegionsViewModel_AbstractItemId').val(), regionSelectionCallback, true);
        });

      } else {
        dataSource = QP.Data.createDataSource(MvcJs.SiteMap.AjaxContentVersionsRegions(), function(options, operation) {
          if (operation === 'read') {
            return {
              Id: $('#SiteMapRegionsViewModel_AbstractItemId').val(),
              PageIndex: options.page
            };
          }

          return options;
        }, function(data) {
          return data.List;
        }, false, function(data) {
          return data.Pager.TotalCount;
        }, AppSettings.DefaultPageSize);

        grid = detailRow.find('#contentRegions').kendoGrid({
          toolbar: kendo.template(
            '<div>' +
              '<button class="k-button" id="btnRefresh" type="button">' + SiteMap.Regions.RefreshButton + '</button>' +
            '</div>'
          ),
          dataSource: dataSource,
          height: 250,
          columns: [{
            field: MvcJs.ViewModels.Dictionary.RegionViewModel.Props.Id.Id,
            title: SiteMap.Regions.NameColumnId
          }, {
            field: MvcJs.ViewModels.Dictionary.RegionViewModel.Props.Title.Id,
            title: SiteMap.Regions.NameColumnTitle
          }, {
            field: MvcJs.ViewModels.Dictionary.RegionViewModel.Props.Alias.Id,
            title: SiteMap.Regions.NameColumnAlias
          }],
          pageable: {
            refresh: true,
            pageSize: AppSettings.DefaultPageSize
          }
        });

        $(grid).find('#btnRefresh').bind('click', function() {
          dataSource.read();
        });
      }
    }

    return {
      init: function() {
        var dataSource = QP.Data.createDataSource(MvcJs.SiteMap.AjaxRegionsGroups(), function(options, operation) {
          if (operation === 'read') {
            return {
              Id: $('#SiteMapRegionsViewModel_AbstractItemId').val()
            };
          }

          return options;
        }, function(data) {
          return data.List;
        });

        var grid = $('#gridRegions').kendoGrid({
          dataSource: dataSource,
          height: 450,
          columns: [{
            field: MvcJs.ViewModels.Models.GroupViewModel.Props.Name.Id,
            title: SiteMap.Regions.NameColumnTitle
          }],
          toolbar: kendo.template($('#regionGridToolbar').html()),
          detailTemplate: kendo.template($('#regionDetailTemplate').html()),
          detailInit: detailInit
        });

        grid.find('#btnRegionRefresh').bind('click', function() {
          dataSource.read();
        });
      },

      resize: function() {
        var gridElement = $('#gridRegions');
        var dataArea = gridElement.find('.k-grid-content');
        var gridHeight = gridElement.innerHeight();
        var otherElements = gridElement.children().not('.k-grid-content');
        var otherElementsHeight = 0;
        otherElements.each(function() {
          otherElementsHeight += $(this).outerHeight();
        });

        dataArea.height(gridHeight - otherElementsHeight);
      }
    }
  })();
}

$(window).resize(function() {
  sitemap.regions.resize();
});
