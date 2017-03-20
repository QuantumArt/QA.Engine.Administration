if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.contentversions) == "undefined") {
    sitemap.contentversions = (function () {

        function changeRegions(grid, id) {
            function regionSelectionCallback(eventType, args) {
                if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.SelectWindowClosed == eventType) {
                    return;
                }

                if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.EntitiesSelected == eventType) {
                    common.showProgress();

                    ajax.post(
                        MvcJs.SiteMap.AjaxUpdateItemRegions(),
                        {
                            SelectedRegionIDs: args.selectedEntityIDs,
                            Id: id,
                        },
                        function (result) {
                            if (ajax.showError(result)) {
                                return;
                            }

                            grid.dataSource.read();

                            common.hideProgress();
                        });
                }
            }

            QP.Client.showRegionsSelector(
                id,
                regionSelectionCallback,
                true);
        }

        function deleteRow(grid, id) {
            var row = grid.select();

            if (row.length == 0) {
                return;
            }

            common.confirm({
                okCallback: function () {
                    common.showProgress();

                    ajax.post(
                        MvcJs.SiteMap.AjaxDeleteItemRegion(),
                        {
                            Id: id,
                            RegionId: grid.dataItem(row).Id
                        },
                        function (result) {
                            if (ajax.showError(result)) {
                                return;
                            }

                            grid.dataSource.read();

                            common.hideProgress();
                        });
                }
            });
        }

        function detailInit(e) {
          e.detailRow.find("#tabStripContentVersions").kendoTabStrip();
          var dataSource = QP.Data.createDataSource(MvcJs.SiteMap.AjaxRegions(), function (options, operation) {
            if (operation == "read") {
              return {
                Id: e.data.Id,
                PageIndex: options.page
              };
            }

            return options;
          }, function (data) {
            return data.List;
          }, false, function (data) {
            return data.Pager.TotalCount;
          }, AppSettings.DefaultPageSize);

          var grid = e.detailRow.find("#contentVersionRegions").kendoGrid({
            toolbar: kendo.template("<div>" +
              "<button class=\"k-button\" id=\"btnAdd\" type=\"button\">" + SiteMap.ContentVersions.SelectButton + "</button>" +
              "<button class=\"k-button\" id=\"btnDelete\" type=\"button\">" + SiteMap.ContentVersions.DeleteButton + "</button>" +
              "<button class=\"k-button\" id=\"btnRefresh\" type=\"button\">" + SiteMap.ContentVersions.RefreshButton + "</button>" +
            "</div>"),
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
            selectable: "row",
            navigatable: true
          });

          $(grid).find('#btnRefresh').bind('click', function () {
            console.log('save state');
            dataSource.read();
          });

          $(grid).find('#btnAdd').bind('click', function () {
            changeRegions(e.detailRow.find('#contentVersionRegions').data('kendoGrid'), e.data.Id);
          });

          $(grid).find('#btnDelete').bind('click', function () {
            deleteRow(e.detailRow.find('#contentVersionRegions').data('kendoGrid'), e.data.Id);
          });
        }

        function addCallback(eventType, args) {
            if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.HostUnbinded == eventType) {
                return;
            }

            if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.ActionExecuted == eventType) {
                if (args.actionCode == QpActionCodes.save_article || args.actionCode == QpActionCodes.save_article_and_up) {

                    ajax.post(
                        MvcJs.SiteMap.AjaxGetItem(),
                        {
                            Id: args.entityId
                        },
                        function (result) {
                            if (ajax.showError(result)) {
                                return;
                            }

                            var grid = $("#gridContentVersions").data("kendoGrid");

                            var scroll = $("#gridContentVersions")
                                .find(".k-grid-content:first")
                                .scrollTop();
                            var expandedRows = $("#gridContentVersions")
                                .find("tr.k-master-row a.k-minus")
                                .closest("tr");
                            var selectRow = grid
                                .select();

                            grid.dataSource.add(result);

                            $.each(expandedRows, function (index, row) {
                                var r = grid.table.find('tr[data-uid="' + $(row).data("uid") + '"]');
                                if (r != null) {
                                    grid.expandRow(r);
                                }
                            });

                            $("#gridContentVersions")
                                .find(".k-grid-content:first")
                                .scrollTop(scroll);

                            if (selectRow != null) {
                                selectRow = grid
                                        .table
                                        .find('tr[data-uid="' + $(selectRow).data("uid") + '"]');

                                if (selectRow != null) {
                                    grid
                                        .select(selectRow);
                                }
                            }

                            if (Observer != null) {
                                Observer.triggerEvent(EventNames.addContentVersion, { id: result.VersionOfId, target: grid });
                            }
                        });

                    return;
                } else if (args.actionCode == QpActionCodes.update_article || args.actionCode == QpActionCodes.update_article_and_up) {
                    updateCallback(eventType, args);

                    return;
                }
            }
        }

        function updateCallback(eventType, args) {
            if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.CloseBackendHost == eventType) {
                return;
            }

            if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.ActionExecuted == eventType) {
                if (args.actionCode == QpActionCodes.update_article || args.actionCode == QpActionCodes.update_article_and_up) {
                    ajax.post(
                        MvcJs.SiteMap.AjaxGetItem(),
                        {
                            Id: args.entityId
                        },
                        function (result) {
                            if (ajax.showError(result)) {
                                return;
                            }

                            var grid = $("#gridContentVersions").data("kendoGrid");
                            var dataSource = grid.dataSource;
                            var data = dataSource.get(result.Id);

                            var scroll = $("#gridContentVersions")
                                .find(".k-grid-content:first")
                                .scrollTop();
                            var expandedRows = $("#gridContentVersions")
                                .find("tr.k-master-row a.k-minus")
                                .closest("tr");
                            var selectRow = grid
                                .select();

                            data.set("Title", result.Title);
                            data.set("Culture", result.Culture);

                            $.each(expandedRows, function (index, row) {
                                var r = grid.table.find('tr[data-uid="' + $(row).data("uid") + '"]');
                                if (r != null) {
                                    grid.expandRow(r);
                                }
                            });

                            $("#gridContentVersions")
                                .find(".k-grid-content:first")
                                .scrollTop(scroll);

                            if (selectRow != null) {
                                selectRow = grid
                                        .table
                                        .find('tr[data-uid="' + $(selectRow).data("uid") + '"]');

                                if (selectRow != null) {
                                    grid
                                        .select(selectRow);
                                }
                            }

                            common.hideProgress();
                        });

                    return;
                }
            }
        }

        function add(form) {
            //var parentExtensionId = form.find("#Parent_ExtensionId").val();
            var parentTitle = form.find("#Parent_Title").val();
            //var parentType = form.find("#Parent_DiscriminatorId").val();
            var versionOf = form.find("#ParentId").val();

            var typeId = form.find("#DiscriminatorId").val();

            var dropdownlist = $("#DiscriminatorId").data("kendoComboBox");
            var dataItem = dropdownlist.dataItem();

            var observer = QP.Utils.initNew(siteMap.common.addCode, addCallback);
            var options = QP.Utils.initOptions(
                QpActionCodes.new_article,
                QpEntityCodes.article,
                0,
                QpContents.QPAbstractItem.Id,
                common.GUID(),
                observer);

            var fieldValues;

            fieldValues = [
                { fieldName: QpContents.QPAbstractItem.Fields.Parent.Id, value: null },
                { fieldName: QpContents.QPAbstractItem.Fields.Discriminator.Id, value: typeId },
                { fieldName: QpContents.QPAbstractItem.Fields.Name.Id, value: null },
                { fieldName: QpContents.QPAbstractItem.Fields.Title.Id, value: parentTitle },
                { fieldName: QpContents.QPAbstractItem.Fields.IsPage.Id, value: true },
                { fieldName: QpContents.QPAbstractItem.Fields.VersionOf.Id, value: versionOf },
                { fieldName: "Data.Schedule.ScheduleType", value: "Visible" },
                {
                    fieldName: QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                    value: (dataItem.PreferredContentId == null ||
                                dataItem.PreferredContentId == "" ||
                                dataItem.PreferredContentId == "0") ? null : dataItem.PreferredContentId
                },
            ];

            QP.Utils.setFieldValues(options,
                fieldValues);

            QP.Utils.setDisabledFields(options,
                [
                    QpContents.QPAbstractItem.Fields.Parent.Id,
                    QpContents.QPAbstractItem.Fields.Discriminator.Id,
                    QpContents.QPAbstractItem.Fields.Name.Id,
                    //QpContents.QPAbstractItem.Fields.Title.Id,
                    QpContents.QPAbstractItem.Fields.IsPage.Id,
                    QpContents.QPAbstractItem.Fields.ZoneName.Id,
                    QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                    QpContents.QPAbstractItem.Fields.VersionOf.Id,
                    QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                    "Data.Schedule.ScheduleType"
                ]);

            var hideFields = [
                QpContents.QPAbstractItem.Fields.ZoneName.Id,
                QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                QpContents.QPAbstractItem.Fields.IsPage.Id,
            ];

            QP.Utils.setDisabledButtons(options,
                [
                    QpActionCodes.move_to_archive_article,
                    QpActionCodes.remove_article,
                    QpActionCodes.list_article_version
                ]);

            QP.Utils.setHideFields(options,
                hideFields);

            QP.Utils.executeWindow(options, QP.Utils.hostId());
        }

        function edit() {
            var observer = QP.Utils.initNew(siteMap.common.editCode, updateCallback);

            var grid = $("#gridContentVersions").data("kendoGrid");
            var row = grid.select();

            if (row == null || row.length == 0) {
                return;
            }

            var data = grid.dataItem(row);

            var options = QP.Utils.initOptions(
                QpActionCodes.edit_article,
                QpEntityCodes.article,
                data.Id,
                QpContents.QPAbstractItem.Id,
                common.GUID(),
                observer);

            QP.Utils.setDisabledFields(options,
                [
                    QpContents.QPAbstractItem.Fields.Parent.Id,
                    QpContents.QPAbstractItem.Fields.Discriminator.Id,
                    QpContents.QPAbstractItem.Fields.Name.Id,
                    QpContents.QPAbstractItem.Fields.IsPage.Id,
                    QpContents.QPAbstractItem.Fields.ZoneName.Id,
                    QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                    QpContents.QPAbstractItem.Fields.VersionOf.Id,
                    QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                    "Data.Schedule.ScheduleType"
                ]);

            var hideFields = [
                QpContents.QPAbstractItem.Fields.ZoneName.Id,
                QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                QpContents.QPAbstractItem.Fields.IsPage.Id,
            ];

            QP.Utils.setHideFields(options,
                hideFields);

            QP.Utils.setDisabledButtons(options,
                [
                    QpActionCodes.move_to_archive_article,
                    QpActionCodes.remove_article/*,
                    QpActionCodes.list_article_version*/
                ]);

            QP.Utils.executeWindow(options, QP.Utils.hostId());
        }

        function history() {
            var grid = $("#gridContentVersions").data("kendoGrid");
            var row = grid.select();

            if (row == null || row.length == 0) {
                return;
            }

            var data = grid.dataItem(row);

            var observer = QP.Utils.initNew(siteMap.common.historyCode, function () { });
            var options = QP.Utils.initOptions(
                QpActionCodes.list_article_version,
                QpEntityCodes.article,
                data.id,
                QpContents.QPAbstractItem.Id,
                common.GUID(),
                observer);

            QP.Utils.executeWindow(options, QP.Utils.hostId());
        }

        function del() {
            var grid = $("#gridContentVersions").data("kendoGrid");
            var row = grid.select();

            if (row == null || row.length == 0) {
                return;
            }

            common.confirm({
                okCallback: function () {

                    common.showProgress();

                    var data = grid.dataItem(row);

                    ajax.post(
                        MvcJs.SiteMap.AjaxRemoveContentVersion(),
                        { Id: data.Id },
                        function (result) {

                            if (ajax.showError(result)) {
                                return;
                            }

                            var scroll = $("#gridContentVersions")
                                .find(".k-grid-content:first")
                                .scrollTop();
                            var expandedRows = $("#gridContentVersions")
                                .find("tr.k-master-row a.k-minus")
                                .closest("tr");

                            grid.removeRow(row);

                            $.each(expandedRows, function (index, row) {
                                var r = grid.table.find('tr[data-uid="' + $(row).data("uid") + '"]');
                                if (r != null) {
                                    grid.expandRow(r);
                                }
                            });

                            $("#gridContentVersions")
                                .find(".k-grid-content:first")
                                .scrollTop(scroll);

                            common.hideProgress();

                            if (Observer != null) {
                                Observer.triggerEvent(EventNames.deleteContentVersion, { id: data.VersionOfId, target: grid });
                            }
                        },
                        ajax.defaultError);
                }
            });
        }

        function preview(data) {
            QP.Client.showRegionsSelector(
                data.Id,
                function (eventType, args) {

                    if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.SelectWindowClosed == eventType) {
                        return;
                    }
                    if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.EntitiesSelected == eventType) {
                        if (jQuery.type(args.selectedEntityIDs) == "array" && args.selectedEntityIDs.length > 0) {
                            var observer = QP.Utils.initNew(siteMap.common.previewCode, function () { });
                            var options = QP.Utils.initOptions(
                                AppSettings.ItemPreviewActionCode,
                                QpEntityCodes.article,
                                0,
                                null,
                                common.GUID(),
                                observer);

                            var params = {};
                            params[AppSettings.ItemPreviewItemIdParamName] = data.Id;
                            params[AppSettings.ItemPreviewChosenRegionParamName] = args.selectedEntityIDs;
                            QP.Utils.setAdditionalParams(options,
                               params);

                            QP.Utils.executeTab(options, QP.Utils.hostId());
                        }
                    }
                },
                false);
        }

        return {
            init: function () {
                var model = kendo.data.Model.define({
                    id: "Id"
                });

                var dataSource = new kendo.data.DataSource({
                    transport: {
                        read: {
                            type: "POST",
                            url: MvcJs.SiteMap.AjaxContentVersions(),
                            dataType: "json",
                            contentType: 'application/json; charset=UTF-8'
                        },
                        parameterMap: function (options, operation) {
                            if (operation == "read") {
                                return {
                                    Id: $("#SiteMapContentVersionsViewModel_AbstractItemId").val(),
                                    PageIndex: options.page
                                };
                            }
                            return options;
                        }
                    },
                    batch: false,
                    pageSize: AppSettings.DefaultPageSize,
                    serverPaging: true,
                    schema: {
                        model: model,
                        data: function (data) {
                            if (ajax.showError(data)) {
                                return;
                            }

                            common.hideProgress();

                            return data.List;
                        },
                        total: function (data) {
                            return data.Pager.TotalCount;
                        },
                        errors: ajax.defaultError,
                    }
                });

                var grid = $("#gridContentVersions").kendoGrid({
                    dataSource: dataSource,
                    height: 450,
                    columns: [
                        {
                            field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.Id.Id,
                            title: SiteMap.ContentVersions.IdColumnTitle,
                            width: "75px"
                        },
                        {
                            field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.Title.Id,
                            title: SiteMap.ContentVersions.TitleColumnTitle
                        },
                        {
                            field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.Culture.Id,
                            title: SiteMap.ContentVersions.CultureColumnTitle
                        },
                        {
                            field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.StatusName.Id,
                            title: SiteMap.ContentVersions.NameColumnStatusName
                        },
                        {
                            field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.DiscriminatorTitle.Id,
                            title: SiteMap.ContentVersions.TypeColumnTitle
                        }
                    ],
                    toolbar: kendo.template($("#contentVersionsGridToolbar").html()),
                    pageable: {
                        refresh: true,
                        pageSize: AppSettings.DefaultPageSize
                    },
                    detailTemplate: kendo.template($("#contentVersionDetailTemplate").html()),
                    detailInit: detailInit,
                    selectable: "row",
                    navigatable: true
                });

                grid.find("#btnContentVersionsRefresh").bind("click", function () {
                    dataSource.read();
                });

                grid.find("#btnAddContentVersion").bind("click", function () {
                    sitemap.add.show({
                        id: $("#SiteMapContentVersionsViewModel_AbstractItemId").val(),
                        callback: add,
                        isVersion: true,
                        canChangeType: false
                    });
                });

                grid.find("#btnEditContentVersion").bind("click", function () {
                    edit();
                });

                grid.find("#btnViewHistoryContentVersion").bind("click", function () {
                    history();
                });

                grid.find("#btnDeleteContentVersion").bind("click", function () {
                    del();
                });

                grid.find("#btnPreview").bind("click", function () {
                    var grid = $("#gridContentVersions").data("kendoGrid");
                    var row = grid.select();

                    if (row == null || row.length == 0) {
                        return;
                    }

                    var data = grid.dataItem(row);

                    preview(data);
                });
            },

            resize: function () {
                var gridElement = $("#gridContentVersions"),
                    dataArea = gridElement.find(".k-grid-content"),
                    gridHeight = gridElement.innerHeight(),
                    otherElements = gridElement.children().not(".k-grid-content"),
                    otherElementsHeight = 0;
                otherElements.each(function () {
                    otherElementsHeight += $(this).outerHeight();
                });
                dataArea.height(gridHeight - otherElementsHeight);
            }
        }
    })();
}

$(window).resize(function () {
    sitemap.contentversions.resize();
});
