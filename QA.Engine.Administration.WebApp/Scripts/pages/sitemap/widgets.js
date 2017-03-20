if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.widgets) == "undefined") {
    sitemap.widgets = (function () {
        var _columns = [
            {
                width: 35,
                title: "",
                template: "# if (data.IsVisibility == false) { #" +
                "<a class='command is_invisible' href='javascript:void(0);' onclick='return false;'></a>" +
                "# } #"
            },
            {
                width: 35,
                title: "<input id='widgetCheckAll', type='checkbox', class='check-box' />",
                template: "<input type=\"checkbox\" />"

            },
            {
                field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.Id.Id,
                title: SiteMap.Widgets.TitleColumnId,
                width: 100
            },
            {
                field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.Title.Id,
                title: SiteMap.Widgets.TitleColumnTitle
            },
            {
                field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.Name.Id,
                title: SiteMap.Widgets.NameColumnTitle
            },
            {
                field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.ZoneName.Id,
                title: SiteMap.Widgets.NameColumnZoneName
            },
            {
                field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.DiscriminatorTitle.Id,
                title: SiteMap.Widgets.NameColumnDiscriminatorName
            },
            {
                field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.StatusName.Id,
                title: SiteMap.Widgets.NameColumnStatusName
            },
            {
                field: MvcJs.ViewModels.SiteMap.SiteMapViewModel.Props.SortOrderView.Id,
                title: SiteMap.Widgets.NameColumnSortOrder,
                width: 50
            },
            {
                command: [
                  { text: "add", template: "<a id='btnAddWidget' class='command add' href='javascript:void(0);'></a>" },
                  { text: "edit", template: "<a id='btnEditWidget' class='command edit' href='javascript:void(0);' onclick='return false;'></a>" },
                  { text: "publish", template: "<a id='btnPublishWidget' class='command publish' href='javascript:void(0);' onclick='return false;'></a>" },
                  { text: "history", template: "<a id='btnViewHistoryWidget' class='command history' href='javascript:void(0);' onclick='return false;'></a>" },
                  { text: "delete", template: "<a id='btnDeleteWidget' class='command delete' href='javascript:void(0);' onclick='return false;'></a>" },
                  { text: "refresh", template: "<a id='btnWidgetRefresh' class='command refresh' href='javascript:void(0);'></a>" }
                ], title: " "
            }
        ];

        function detailInit(e) {
            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        type: "POST",
                        url: MvcJs.SiteMap.AjaxWidgets(),
                        dataType: "json",
                        contentType: 'application/json; charset=UTF-8',
                        data: { Id: e.data.Id }
                    },
                    parameterMap: function (options, operation) {
                        if (operation == "read") {
                            return {
                                Id: e.data.Id,
                                PageIndex: 1
                            };
                        }
                        return options;
                    }
                },
                batch: false,
                schema: {
                    data: function (data) {
                        if (ajax.showError(data)) {
                            return;
                        }

                        common.hideProgress();

                        return data.List;
                    },
                    errors: ajax.defaultError,
                },
            });

            var grid = $("<div/>").appendTo(e.detailCell).kendoGrid({
                dataSource: dataSource,
                columns: _columns,
                scrollable: false,
                detailInit: detailInit,
                dataBound: function (dbe) {
                    toolbarBindAction(grid, e.data.Id, dataSource);
                }
            });

            $(grid).find(".k-grid-header").hide();
        }

        function toolbarBindAction(grid, parentId, dataSource) {
            grid.find("#btnWidgetRefresh").unbind("click");
            grid.find("#btnAddWidget").unbind("click");
            grid.find("#btnDeleteWidget").unbind("click");
            grid.find("#btnEditWidget").unbind("click");
            grid.find("#btnViewHistoryWidget").unbind("click");
            grid.find("#btnPublishWidget").unbind("click");
            grid.find("#btnPublishAll").unbind("click");
            grid.find("#btnPublishSelected").unbind("click");

            grid.find("#btnWidgetRefresh").bind("click", function () {
                var uid = $(this).parent().parent().attr('data-uid');
                if (uid == null) {
                    dataSource.read();
                } else {
                    var master = $($(this).parent().parent()).prop("className");
                    var detail = $($(this).parent().parent()).next(".k-detail-row");
                    if (detail.length == 0) {
                        if (master != null) {
                            $(grid).data("kendoGrid").expandRow($(this).parent().parent());
                        }
                    } else {
                        var detailGrid = $(detail).find(".k-grid").data("kendoGrid");
                        if (detailGrid != null) {
                            detailGrid.dataSource.read();
                        }
                    }
                }
            });
            grid.find("#btnAddWidget").bind("click", function () {
                var master = $($(this).parent().parent()).prop("className");
                var detail = $($(this).parent().parent()).next(".k-detail-row");
                _row = null;
                var parent;
                if (detail.length == 0) {
                    if (master != null) {
                        _grid = grid;
                        _row = $(this).parent().parent();
                        parent = $(grid).data("kendoGrid").dataItem(
                            $(this).parent().parent());
                    }
                } else {
                    _grid = $(detail).find(".k-grid");
                    parent = $(grid).data("kendoGrid").dataItem(
                            $(this).parent().parent());
                }

                var dialog = new sitemap.crud.dialog();
                dialog.show({
                    title: SiteMap.Widgets.AddWindowTitle,
                    url: MvcJs.SiteMap.AjaxAdd(),
                    data: { ParentId: parent != null ? parent.Id : parentId },
                    selector: "<div id=\"addWindow\" class=\"display-none\"></div>",
                    callback: add,
                    onready: function (form) { QP.Data.loadDiscriminators(form, false); },
                    cancelBtn: "#btnAddCancel",
                    validateForm: true
                });
            });
            grid.find("#btnDeleteWidget").bind("click", function () {
                _row = null;
                var btn = $(this);
                common.confirm({
                    okCallback: function () {
                        var row = btn.parent().parent();
                        del(grid, row);
                    }
                });
            });
            grid.find("#btnEditWidget").bind("click", function () {
                _grid = grid;
                _row = null;
                var row = $(grid).data("kendoGrid").dataItem(
                        $(this).parent().parent());
                edit(row.Id);
            });

            grid.find("#btnViewHistoryWidget").bind("click", function () {
                _grid = grid;
                _row = null;
                var row = $(grid).data("kendoGrid").dataItem(
                        $(this).parent().parent());
                history(row.Id);
            });

            grid.find("#btnPublishWidget").bind("click", function () {
                _grid = grid;
                _row = null;
                var row = $(grid).data("kendoGrid").dataItem(
                        $(this).parent().parent());

                common.confirm({
                    okCallback: function () {
                        common.showProgress();

                        ajax.post(
                            MvcJs.SiteMap.AjaxPublishWidgets(),
                            {
                                id: row.Id
                            },
                            function (result) {
                                if (ajax.showError(result)) {
                                    return;
                                }

                                if (_grid != null) {
                                    var scroll = $(_grid)
                                           .find(".k-grid-content:first")
                                           .scrollTop();
                                    var expandedRows = $(_grid)
                                        .find("tr.k-master-row a.k-minus")
                                        .closest("tr");

                                    if ($(_grid).data("kendoGrid").dataItem(_row) != null) {
                                        $(_grid).data("kendoGrid").expandRow(_row);
                                    } else {
                                        $(_grid).data("kendoGrid").dataSource.read();
                                    }

                                    $.each(expandedRows, function (index, row) {
                                        var r = $(_grid).data("kendoGrid")
                                            .table
                                            .find('tr[data-uid="' + $(row).data("uid") + '"]');
                                        if (r != null) {
                                            $(_grid).data("kendoGrid").expandRow(r);
                                        }
                                    });

                                    $(_grid)
                                        .find(".k-grid-content:first")
                                        .scrollTop(scroll);
                                }

                                common.hideProgress();
                            });
                    }
                });
            });

            grid.find("#btnPublishAll").bind("click", function () {
                common.confirm({
                    okCallback: function () {
                        common.showProgress();

                        ajax.post(
                            MvcJs.SiteMap.AjaxPublishWidgetsByAbstractItem(),
                            {
                                id: parentId
                            },
                            function (result) {
                                if (ajax.showError(result)) {
                                    return;
                                }

                                if (dataSource != null) {
                                    dataSource.read();
                                }

                                common.hideProgress();
                            });
                    }
                });
            });

            grid.find("#btnPublishSelected").bind("click", function () {
                common.confirm({
                    okCallback: function () {
                        common.showProgress();

                        var ids = [];

                        $('#gridWidgets input:checked[type=checkbox][id!=widgetCheckAll]').each(
                            function () {
                                ids.push($(this).parent().next().text());
                            });

                        if (ids.length == 0) {
                            return;
                        }

                        ajax.post(
                            MvcJs.SiteMap.AjaxPublishWidgets(),
                            {
                                id: ids
                            },
                            function (result) {
                                if (ajax.showError(result)) {
                                    return;
                                }

                                if (dataSource != null) {
                                    dataSource.read();
                                }

                                common.hideProgress();
                            });
                    }
                });
            });
        }

        var _grid;
        var _row;
        function addCallback(eventType, args) {
            if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.HostUnbinded == eventType) {
                return;
            }

            if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.ActionExecuted == eventType) {
                if (args.actionCode == QpActionCodes.save_article || args.actionCode == QpActionCodes.save_article_and_up) {
                    if (_grid != null) {

                        var scroll = $(_grid)
                                .find(".k-grid-content:first")
                                .scrollTop();
                        var expandedRows = $(_grid)
                            .find("tr.k-master-row a.k-minus")
                            .closest("tr");

                        if ($(_grid).data("kendoGrid").dataItem(_row) != null) {
                            $(_grid).data("kendoGrid").expandRow(_row);
                        } else {
                            $(_grid).data("kendoGrid").dataSource.read();
                        }

                        $.each(expandedRows, function (index, row) {
                            var r = $(_grid).data("kendoGrid")
                                .table
                                .find('tr[data-uid="' + $(row).data("uid") + '"]');
                            if (r != null) {
                                $(_grid).data("kendoGrid").expandRow(r);
                            }
                        });

                        $(_grid)
                            .find(".k-grid-content:first")
                            .scrollTop(scroll);
                    }

                    return;
                } else if (args.actionCode == QpActionCodes.update_article || args.actionCode == QpActionCodes.update_article_and_up) {
                    editCallback(eventType, args);

                    return;
                }
            }
        }

        function editCallback(eventType, args) {
            if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.CloseBackendHost == eventType) {
                return;
            }

            if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.ActionExecuted == eventType) {
                if (args.actionCode == QpActionCodes.update_article || args.actionCode == QpActionCodes.update_article_and_up) {
                    if (_grid != null) {
                        var scroll = $(_grid)
                               .find(".k-grid-content:first")
                               .scrollTop();
                        var expandedRows = $(_grid)
                            .find("tr.k-master-row a.k-minus")
                            .closest("tr");

                        if ($(_grid).data("kendoGrid").dataItem(_row) != null) {
                            $(_grid).data("kendoGrid").expandRow(_row);
                        } else {
                            $(_grid).data("kendoGrid").dataSource.read();
                        }

                        $.each(expandedRows, function (index, row) {
                            var r = $(_grid).data("kendoGrid")
                                .table
                                .find('tr[data-uid="' + $(row).data("uid") + '"]');
                            if (r != null) {
                                $(_grid).data("kendoGrid").expandRow(r);
                            }
                        });

                        $(_grid)
                            .find(".k-grid-content:first")
                            .scrollTop(scroll);
                    }

                    return;
                }
            }
        }

        function add(form) {
            var observer = QP.Utils.initNew(siteMap.common.addCode, addCallback);
            var options = QP.Utils.initOptions(
                QpActionCodes.new_article,
                QpEntityCodes.article,
                0,
                QpContents.QPAbstractItem.Id,
                common.GUID(),
                observer);

            var typeId = form.find("#DiscriminatorId").val();
            var name = form.find("#Name").val();
            var title = form.find("#Title").val();

            var dropdownlist = $("#DiscriminatorId").data("kendoComboBox");
            var dataItem = dropdownlist.dataItem();

            QP.Utils.setFieldValues(options,
                [
                    { fieldName: QpContents.QPAbstractItem.Fields.Parent.Id, value: form.find("#ParentId").val() },
                    { fieldName: QpContents.QPAbstractItem.Fields.Discriminator.Id, value: typeId },
                    { fieldName: QpContents.QPAbstractItem.Fields.Name.Id, value: name },
                    { fieldName: QpContents.QPAbstractItem.Fields.Title.Id, value: title },
                    { fieldName: QpContents.QPAbstractItem.Fields.IsPage.Id, value: false },
                    {
                        fieldName: QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                        value: (dataItem.PreferredContentId == null ||
                                dataItem.PreferredContentId == "" ||
                                dataItem.PreferredContentId == "0") ? null : dataItem.PreferredContentId
                    },
                ]);

            QP.Utils.setDisabledFields(options,
                [
                    QpContents.QPAbstractItem.Fields.Parent.Id,
                    QpContents.QPAbstractItem.Fields.Discriminator.Id,
                    QpContents.QPAbstractItem.Fields.Name.Id,
                    QpContents.QPAbstractItem.Fields.Title.Id,
                    QpContents.QPAbstractItem.Fields.IsPage.Id,
                    QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                    QpContents.QPAbstractItem.Fields.VersionOf.Id,
                    //QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                    QpContents.QPAbstractItem.Fields.TitleFormat.Id,
                    QpContents.QPAbstractItem.Fields.IsInSiteMap.Id,
                ]);

            var hideFields = [
                //QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                QpContents.QPAbstractItem.Fields.VersionOf.Id,
                QpContents.QPAbstractItem.Fields.IsPage.Id,
                QpContents.QPAbstractItem.Fields.IsInSiteMap.Id,
            ];

            QP.Utils.setHideFields(options,
                hideFields);

            QP.Utils.setDisabledButtons(options,
                [
                    QpActionCodes.move_to_archive_article,
                    QpActionCodes.remove_article,
                    QpActionCodes.list_article_version
                ]);

            QP.Utils.executeWindow(options, QP.Utils.hostId());
        }

        function edit(id) {
            var observer = QP.Utils.initNew(siteMap.common.editCode, editCallback);
            var options = QP.Utils.initOptions(
                QpActionCodes.edit_article,
                QpEntityCodes.article,
                id,
                QpContents.QPAbstractItem.Id,
                common.GUID(),
                observer);

            QP.Utils.setDisabledFields(options,
                [
                    QpContents.QPAbstractItem.Fields.Parent.Id,
                    QpContents.QPAbstractItem.Fields.Discriminator.Id,
                    QpContents.QPAbstractItem.Fields.Name.Id,
                    QpContents.QPAbstractItem.Fields.IsPage.Id,
                    QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                    QpContents.QPAbstractItem.Fields.VersionOf.Id,
                    //QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                    QpContents.QPAbstractItem.Fields.TitleFormat.Id,
                    QpContents.QPAbstractItem.Fields.IsInSiteMap.Id,
                ]);

            var hideFields = [
                //QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                QpContents.QPAbstractItem.Fields.VersionOf.Id,
                QpContents.QPAbstractItem.Fields.IsPage.Id,
                QpContents.QPAbstractItem.Fields.IsInSiteMap.Id,
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

        function history(id) {
            var observer = QP.Utils.initNew(siteMap.common.historyCode, function () { });
            var options = QP.Utils.initOptions(
                QpActionCodes.list_article_version,
                QpEntityCodes.article,
                id,
                QpContents.QPAbstractItem.Id,
                common.GUID(),
                observer);

            QP.Utils.executeWindow(options, QP.Utils.hostId());
        }

        function del(grid, row) {
            common.showProgress();

            var id = $(grid).data("kendoGrid").dataItem(row).Id;

            ajax.post(
                MvcJs.SiteMap.AjaxRemoveItem(),
                { Id: id },
                function (result) {

                    if (ajax.showError(result)) {
                        return;
                    }

                    var scroll = $(_grid)
                               .find(".k-grid-content:first")
                               .scrollTop();
                    var expandedRows = $(_grid)
                        .find("tr.k-master-row a.k-minus")
                        .closest("tr");

                    $(grid).data("kendoGrid").removeRow(row);

                    $.each(expandedRows, function (index, row) {
                        var r = $(_grid).data("kendoGrid")
                            .table
                            .find('tr[data-uid="' + $(row).data("uid") + '"]');
                        if (r != null) {
                            $(_grid).data("kendoGrid").expandRow(r);
                        }
                    });

                    $(_grid)
                        .find(".k-grid-content:first")
                        .scrollTop(scroll);

                    common.hideProgress();
                },
                ajax.defaultError);
        }

        return {
            init: function () {
                var dataSource = new kendo.data.DataSource({
                    transport: {
                        read: {
                            type: "POST",
                            url: MvcJs.SiteMap.AjaxWidgets(),
                            dataType: "json",
                            contentType: 'application/json; charset=UTF-8'
                        },
                        parameterMap: function (options, operation) {
                            if (operation == "read") {
                                return {
                                    Id: $("#SiteMapWidgetsViewModel_AbstractItemId").val(),
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
                    },
                    dataBound: function () {
                        this.expandRow(this.tbody.find("tr.k-master-row").first());
                    }
                });

                var grid = $("#gridWidgets").kendoGrid({
                    dataSource: dataSource,
                    height: 450,
                    columns: _columns,
                    toolbar: kendo.template($("#widgetGridToolbar").html()),
                    pageable: {
                        refresh: true,
                        pageSize: AppSettings.DefaultPageSize
                    },
                    detailInit: detailInit,
                    dataBound: function (e) {
                        toolbarBindAction(grid, $("#SiteMapWidgetsViewModel_AbstractItemId").val(), dataSource);
                    }
                });

                $(document).on("click", "#widgetCheckAll", function () {
                    if (this.checked === true) {
                        $("#btnPublishSelected")
                            .removeAttr("disabled", "disabled")
                            .removeClass("k-state-disabled");
                    }
                    else {
                        $("#btnPublishSelected")
                            .attr("disabled", "disabled")
                            .addClass("k-state-disabled");
                    }

                    $("#gridWidgets tbody input:checkbox").attr("checked", this.checked);
                });

                $(document).on("click", '#gridWidgets input[type=checkbox][id!=widgetCheckAll]', function () {
                    var len = $('#gridWidgets input:checked[type=checkbox][id!=widgetCheckAll]').length;
                    if (len > 0) {
                        $("#btnPublishSelected")
                            .removeAttr("disabled", "disabled")
                            .removeClass("k-state-disabled");
                    }
                    else {
                        $("#btnPublishSelected")
                            .attr("disabled", "disabled")
                            .addClass("k-state-disabled");
                    }
                });

                $("#btnPublishSelected")
                    .attr("disabled", "disabled")
                    .addClass("k-state-disabled");
            },

            resize: function () {
                var gridElement = $("#gridWidgets"),
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
    sitemap.widgets.resize();
});
