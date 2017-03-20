var treeActions = function () {
    function sortingAdd(node, parentNode) {
        var list = [];

        var children = $(parentNode).children('ul').children('li');

        $.each(children, function (idx, value) {
            var data = window.AdminPage.kendo_tree.instance().dataItem(value);

            list.push(data);
        });

        list.push(node);

        list = list.sort(function (a, b) {
            var max = Number.MAX_VALUE;
            var indexA = a.SortOrder == null ? max : a.SortOrder;
            var indexB = b.SortOrder == null ? max : b.SortOrder;
            var nameA = a.Name.toLowerCase();
            var nameB = b.Name.toLowerCase();

            var p0 = (indexA > indexB) ? 1 : (indexA < indexB) ? -1 : 0;
            var p1 = (nameA > nameB) ? 1 : (nameA < nameB) ? -1 : 0;

            return p0 + p1;
        });

        var index = -1;
        var uid = null;

        $.each(list, function (idx, value) {
            if (value.Id == node.Id) {
                index = idx;
                uid = list[index + 1] == null ? null : list[index + 1].uid;
                return false;
            }
        });

        if (index >= 0) {
            if (index == list.length - 1) {
                window.AdminPage.kendo_tree.instance().append(node, parentNode);
            } else {
                window.AdminPage.kendo_tree.instance().insertBefore(node,
                    window.AdminPage.kendo_tree.instance().findByUid(uid));
            }
        }
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
                        Id: args.entityId,
                        IsIncludeChildrenCount: true
                    },
                    function (result) {
                        if (ajax.showError(result)) {
                            return;
                        }

                        if (result.IsVersion == false) {
                            var node = window.AdminPage.kendo_tree.getNodeById(result.ParentId);
                            var children = $(node).children('ul').children('li');

                            if (children.length > 0) {
                                sortingAdd(result, node);
                            } else {
                                treeActions.refresh(result.ParentId, node);
                            }

                            common.hideProgress();
                        } else {
                            treeActions.redrawNode(result.VersionOfId);
                        }
                    });

                return;
            } else if (args.actionCode == QpActionCodes.update_article || args.actionCode == QpActionCodes.update_article_and_up) {
                treeActions.redrawNode(args.entityId);

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
                treeActions.redrawNode(args.entityId);

                return;
            }
        }
    }

    return {
        publish: function (id, node) {
            common.confirm({
                okCallback: function () {
                    common.showProgress();

                    ajax.post(
                        MvcJs.SiteMap.AjaxPublishItem(),
                        {
                            Id: id
                        },
                        function (result) {
                            if (ajax.showError(result)) {
                                return;
                            }

                            if (node != null) {
                                node.find(".new").remove();
                            }

                            common.hideProgress();

                            alert(SiteMap.Index.SuccessfullyPublishingMessage);
                        });
                }
            });
        },

        refreshCurrent: function () {
            window.AdminPage.kendo_tree.reloadCurrentNode();
        },

        refresh: function (id, node) {
            var combobox = $("#culture").data("kendoComboBox");
            var dataItem = combobox.dataItem();

            var autocomplete = $("#region").data("kendoAutoComplete");
            var regions = autocomplete.value();

            window.AdminPage.kendo_tree.load(id, dataItem == null ? null : dataItem.Id, regions, node);
        },

        del: function (form) {
            var $form = form;

            common.showProgress();

            var params = $form.serializeObject();
            var isArray = $.isArray(params["IsDeleteAllVersions"]);
            if (isArray) {
                params["IsDeleteAllVersions"] = params["IsDeleteAllVersions"][0];
            }

            ajax.post(
                MvcJs.SiteMap.AjaxRemoveItem(),
                params,
                function (result) {

                    if (ajax.showError(result)) {
                        return;
                    }

                    var currentNode = window.AdminPage.kendo_tree.getNodeById(params["Id"]);

                    if (params["IsDeleteAllVersions"] == "true") {
                        var name = window.AdminPage.kendo_tree.instance().dataItem(currentNode).Name;
                        var parentId = window.AdminPage.kendo_tree.instance().dataItem(currentNode).ParentId;
                        var nodes = window.AdminPage.kendo_tree.instance().element.find(".k-in");

                        $.each(nodes, function (idx, value) {
                            var node = window.AdminPage.kendo_tree.instance().dataItem(value);

                            if (node != null) {
                                if (node.Name == name && node.ParentId == parentId) {
                                    window.AdminPage.kendo_tree.instance().remove(value);
                                }
                            }
                        });
                    } else if (params["OperationsByContentVersion"] == Enums.ContentVersionOperations.Move) {
                        var node = window.AdminPage.kendo_tree.getNodeById(result.ParentId);
                        sortingAdd(result, node);
                    }

                    window.AdminPage.kendo_tree.instance().remove(currentNode);

                    tabs.reload("");
                    toolbar.setButtonsStatus();

                    common.hideProgress();
                },
                ajax.defaultError);
        },

        add: function (form) {
            var isVersion = form.find("#IsVersion").val();
            var versionType = form.find("input[name=VersionTypeId]:checked").val();
            //var parentExtensionId = form.find("#Parent_ExtensionId").val();
            var parentName = form.find("#Parent_Name").val();
            var parentTitle = form.find("#Parent_Title").val();
            //var parentType = form.find("#Parent_DiscriminatorId").val();

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

            var preferredContentId = form.find("#PreferredContentId").val();

            var fieldValues;
            var disabledFields =
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
                ];

            var hideFields = [
                QpContents.QPAbstractItem.Fields.ZoneName.Id,
                QpContents.QPAbstractItem.Fields.VersionOf.Id,
                QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                QpContents.QPAbstractItem.Fields.IsPage.Id,
            ];

            if (isVersion == null || isVersion == "False" || isVersion == "false" || isVersion == "") {
                fieldValues = [
                    { fieldName: QpContents.QPAbstractItem.Fields.Parent.Id, value: form.find("#ParentId").val() },
                    { fieldName: QpContents.QPAbstractItem.Fields.Discriminator.Id, value: typeId },
                    { fieldName: QpContents.QPAbstractItem.Fields.Name.Id, value: name },
                    { fieldName: QpContents.QPAbstractItem.Fields.Title.Id, value: title },
                    { fieldName: QpContents.QPAbstractItem.Fields.IsPage.Id, value: true },
                    { fieldName: "Data.Schedule.ScheduleType", value: "Visible" },
                    {
                        fieldName: QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                        value: (preferredContentId == null ||
                                preferredContentId == "" ||
                                preferredContentId == "0") ? null : preferredContentId
                    },
                ];
            }
            else if (versionType == Enums.VersionTypes.Structural) {
                fieldValues = [
                    { fieldName: QpContents.QPAbstractItem.Fields.Parent.Id, value: form.find("#StructuralVersionParentId").val() },
                    { fieldName: QpContents.QPAbstractItem.Fields.Discriminator.Id, value: typeId },
                    { fieldName: QpContents.QPAbstractItem.Fields.Name.Id, value: parentName },
                    { fieldName: QpContents.QPAbstractItem.Fields.Title.Id, value: parentTitle },
                    { fieldName: QpContents.QPAbstractItem.Fields.IsPage.Id, value: true },
                    { fieldName: "Data.Schedule.ScheduleType", value: "Visible" },
                    {
                        fieldName: QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                        value: (preferredContentId == null ||
                                preferredContentId == "" ||
                                preferredContentId == "0") ? null : preferredContentId
                    },
                ];

                disabledFields = [
                    QpContents.QPAbstractItem.Fields.Parent.Id,
                    QpContents.QPAbstractItem.Fields.Discriminator.Id,
                    QpContents.QPAbstractItem.Fields.Name.Id,
                    QpContents.QPAbstractItem.Fields.IsPage.Id,
                    QpContents.QPAbstractItem.Fields.ZoneName.Id,
                    QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                    QpContents.QPAbstractItem.Fields.VersionOf.Id,
                    QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                ];
            } else {
                fieldValues = [
                    { fieldName: QpContents.QPAbstractItem.Fields.Parent.Id, value: null },
//                    { fieldName: QpContents.QPAbstractItem.Fields.Discriminator.Id, value: parentType },
                    { fieldName: QpContents.QPAbstractItem.Fields.Discriminator.Id, value: typeId },
                    { fieldName: QpContents.QPAbstractItem.Fields.Name.Id, value: null },
                    { fieldName: QpContents.QPAbstractItem.Fields.Title.Id, value: parentTitle },
                    { fieldName: QpContents.QPAbstractItem.Fields.IsPage.Id, value: true },
                    { fieldName: QpContents.QPAbstractItem.Fields.VersionOf.Id, value: form.find("#ParentId").val() },
                    { fieldName: "Data.Schedule.ScheduleType", value: "Visible" },
                    {
                        fieldName: QpContents.QPAbstractItem.Fields.ExtensionId.Id,
                        value: (preferredContentId == null ||
                                preferredContentId == "" ||
                                preferredContentId == "0") ? null : preferredContentId
                    },
                ];

                hideFields = [
                    QpContents.QPAbstractItem.Fields.ZoneName.Id,
                    QpContents.QPAbstractItem.Fields.IndexOrder.Id,
                    QpContents.QPAbstractItem.Fields.IsPage.Id,
                ];
            }

            QP.Utils.setFieldValues(options,
                fieldValues);
            QP.Utils.setDisabledFields(options,
                disabledFields);
            QP.Utils.setHideFields(options,
                hideFields);

            QP.Utils.setDisabledButtons(options,
                [
                    QpActionCodes.move_to_archive_article,
                    QpActionCodes.remove_article,
                    QpActionCodes.list_article_version
                ]);

            QP.Utils.executeWindow(options, QP.Utils.hostId());
        },

        edit: function (node) {
            var observer = QP.Utils.initNew(siteMap.common.editCode, updateCallback);
            var options = QP.Utils.initOptions(
                QpActionCodes.edit_article,
                QpEntityCodes.article,
                node.Id,
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
                QpContents.QPAbstractItem.Fields.VersionOf.Id,
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
        },

        move: function (options) {
          common.showProgress();
          ajax.post(MvcJs.SiteMap.AjaxTreeMoveItem(), {
            viewModel: {
              ItemId: window.AdminPage.kendo_tree.instance().dataItem(options.sourceNode).id,
              NewParentId: options.dropPosition == "over" || window.AdminPage.kendo_tree.instance().dataItem(options.destinationNode).level() > 0 ? window.AdminPage.kendo_tree.instance().dataItem(options.destinationNode).id : null
            }
          }, function (result) {
            if (ajax.showError(result)) {
              return;
            }

            window.AdminPage.kendo_tree.instance().detach($(options.sourceNode));
            if (options.dropPosition == "over") {
              window.AdminPage.kendo_tree.instance().append($(options.sourceNode), $(options.destinationNode));
            }
            else if (options.dropPosition == "before") {
              window.AdminPage.kendo_tree.instance().insertBefore($(options.sourceNode), $(options.destinationNode));
            }
            else if (options.dropPosition == "after") {
              window.AdminPage.kendo_tree.instance().insertAfter($(options.sourceNode), $(options.destinationNode));
            }

            var nodeData = window.AdminPage.kendo_tree.instance().dataItem(options.sourceNode);
            var uid = nodeData.uid;
            $('li[data-uid="' + uid + '"]').bind("contextmenu", function () {
              event.stopPropagation();
            });

            sitemap.move.hide();
            common.hideProgress();
          }, ajax.defaultError);
        },

        copy: function (options) {
            if (options.dropPosition !== "over") {
                return;
            }

            var copyCallback = function (eventType, args) {
                if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.HostUnbinded == eventType) {
                    return;
                }

                if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.ActionExecuted == eventType) {
                    var copy = window.AdminPage.kendo_tree.instance().dataItem(options.sourceNode).toJSON();
                    copy.expaned = false;
                    copy.HasChildren = false;
                    copy.HasContentVersions = false;
                    window.AdminPage.kendo_tree.instance().append(copy, $(options.destinationNode));

                    sitemap.move.hide();
                }
            }

            var observer = QP.Utils.initNew(siteMap.common.copyCode, copyCallback);
            var copyOptions = QP.Utils.initOptions(
                QpActionCodes.copy_article,
                QpEntityCodes.article,
                window.AdminPage.kendo_tree.instance().dataItem(options.sourceNode).id,
                QpContents.QPAbstractItem.Id,
                common.GUID(),
                observer);

            QP.Utils.executeWindow(copyOptions, QP.Utils.hostId());
        },

        reorder: function (e) {
            common.showProgress();

            ajax.post(
                MvcJs.SiteMap.AjaxTreeReorderItem(),
                {
                    viewModel: {
                        ItemId: window.AdminPage.kendo_tree.instance().dataItem(e.sourceNode).id,
                        RelatedItemId: window.AdminPage.kendo_tree.instance().dataItem(e.destinationNode).id,
                        IsInsertBefore: e.dropPosition == "over" || e.dropPosition == "before"
                    }
                },
                function (result) {
                    if (ajax.showError(result)) {
                        return;
                    }

                    window.AdminPage.kendo_tree.instance().detach($(e.sourceNode));
                    if (e.dropPosition == "over" || e.dropPosition == "before") {
                        window.AdminPage.kendo_tree.instance().insertBefore($(e.sourceNode), $(e.destinationNode));
                    }
                    else if (e.dropPosition == "after") {
                        window.AdminPage.kendo_tree.instance().insertAfter($(e.sourceNode), $(e.destinationNode));
                    }
                    var nodeData = window.AdminPage.kendo_tree.instance().dataItem(e.sourceNode);
                    var uid = nodeData.uid;
                    $('li[data-uid="' + uid + '"]').bind(
                        "contextmenu", function () {
                            event.stopPropagation();
                        });

                    common.hideProgress();
                },
                ajax.defaultError);
        },

        preview: function (node) {
            QP.Client.showCulturesSelector(
                node.Id,
                function (eventType, args) {

                    if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.SelectWindowClosed == eventType) {
                        return;
                    }
                    if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.EntitiesSelected == eventType) {
                        QP.Client.showRegionsSelector(
                            node.Id,
                            function (eventType1, args1) {

                                if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.SelectWindowClosed == eventType1) {
                                    return;
                                }

                                if (Quantumart.QP8.Interaction.BackendEventObserver.EventType.EntitiesSelected == eventType1) {
                                    if (jQuery.type(args1.selectedEntityIDs) == "array" && args1.selectedEntityIDs.length > 0) {
                                        var observer = QP.Utils.initNew(siteMap.common.previewCode, function () { });
                                        var options = QP.Utils.initOptions(
                                            AppSettings.ItemPreviewActionCode,
                                            QpEntityCodes.site,
                                            SiteConfiguration.SiteId,
                                            1,
                                            common.GUID(),
                                            observer);

                                        var params = {};
                                        params[AppSettings.ItemPreviewItemIdParamName] = node.Id;
                                        params[AppSettings.ItemPreviewChosenRegionParamName] =
                                             args1.selectedEntityIDs[0];

                                        if (jQuery.type(args.selectedEntityIDs) == "array" && args.selectedEntityIDs.length > 0) {
                                            params[AppSettings.ItemPreviewChosenCultureParamName] =
                                                QpCultures["culture" + args.selectedEntityIDs[0]].Name;
                                        }

                                        QP.Utils.setAdditionalParams(options,
                                           params);

                                        QP.Utils.executeTab(options, QP.Utils.hostId());
                                    }
                                }
                            },
                            false);
                    }
                },
                false);

        },

        redrawNode: function (id) {
          ajax.post(MvcJs.SiteMap.AjaxGetItem(), {
            Id: id,
            IsIncludeChildrenCount: true
          }, function (result) {
            if (!ajax.showError(result)) {
              window.AdminPage.kendo_tree.redrawNode(result);
              common.hideProgress();
            }
          });
        },

        history: function (node) {
            var observer = QP.Utils.initNew(siteMap.common.historyCode, function () { });
            var options = QP.Utils.initOptions(
                QpActionCodes.list_article_version,
                QpEntityCodes.article,
                node.Id,
                QpContents.QPAbstractItem.Id,
                common.GUID(),
                observer);

            QP.Utils.executeWindow(options, QP.Utils.hostId());
        }
    }
}();
