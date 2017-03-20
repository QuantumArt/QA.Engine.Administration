var contextMenu = function () {
    var setButtonsStatus = function (
        isPublished,
        id,
        isVersion) {
        if (!isPublished) {
            $("li#publishItem").prop("disabled", false).removeClass("disabled");
        } else {
            $("li#publishItem").prop("disabled", true).addClass("disabled");
        }

        if (SiteConfiguration.RootPageId == id) {
            $("li#deletePageItem,li#editPageItem,li#previewItem").prop("disabled", true).addClass("disabled");
        } else {
            $("li#deletePageItem,li#editPageItem,li#previewItem").prop("disabled", false).removeClass("disabled");
        }

        if (isVersion) {
            $("li#addPageItem,li#addVersionPageItem").prop("disabled", true).addClass("disabled");
        }
        else {
            $("li#addPageItem,li#addVersionPageItem").prop("disabled", false).removeClass("disabled");
        }

        if (SiteConfiguration.RootPageId == id || isVersion) {
            $("li#addVersionPageItem").prop("disabled", true).addClass("disabled");
        }
        else {
            $("li#addVersionPageItem").prop("disabled", false).removeClass("disabled");
        }

        $("li#refreshItem").prop("disabled", false).removeClass("disabled");
        $("li#viewItemVersions").prop("disabled", false).removeClass("disabled");
    }

    return {
        init: function () {
            $('#treeview li[data-uid]').jeegoocontext('contextmenu', {
                livequery: true,
                onSelect: function (e, context) {
                    var node = window.AdminPage.kendo_tree.instance().findByUid(window.AdminPage.kendo_tree.instance().dataItem(context).uid);
                    if (node == null) {
                        return;
                    }

                    if ($(this).hasClass("k-state-disabled")) {
                        return;
                    }

                    switch ($(this).attr('id')) {
                        case 'refreshItem':
                            treeActions.refresh(window.AdminPage.kendo_tree.instance().dataItem(context).id, node);
                            break;
                        case 'publishItem':
                            treeActions.publish(
                                window.AdminPage.kendo_tree.instance().dataItem(context).id,
                                node);
                            break;
                        case 'addPageItem':
                            sitemap.add.show({
                                id: window.AdminPage.kendo_tree.instance().dataItem(context).id,
                                callback: function (form) {
                                    var name = form.find("#Name").val();

                                    ajax.post(
                                            MvcJs.SiteMap.AjaxGetSiteMap(),
                                            {
                                                name: name,
                                                parentId: window.AdminPage.kendo_tree.instance().dataItem(context).id
                                            },
                                            function (result) {
                                                if (ajax.showError(result)) {
                                                    return;
                                                }

                                                if (result.Id == 0) {
                                                    treeActions.add(form);
                                                } else {
                                                    common.confirm({
                                                        text: SiteMap.Toolbar.HasItemWarningMessage,
                                                        okCallback: function () {
                                                            sitemap.add.show({
                                                                id: result.Id,
                                                                callback: treeActions.add,
                                                                isVersion: true,
                                                                canChangeType: true,
                                                                typeId: form.find("#DiscriminatorId").val()
                                                            });
                                                        }
                                                    });
                                                }
                                            });


                                }, isVersion: false, canChangeType: false });
                            break;
                        case 'addVersionPageItem':
                            sitemap.add.show(
                                {
                                    id: window.AdminPage.kendo_tree.instance().dataItem(context).id,
                                    callback: treeActions.add,
                                    isVersion: true,
                                    canChangeType: true
                                });
                            break;
                        case 'editPageItem':
                            treeActions.edit(window.AdminPage.kendo_tree.instance().dataItem(context));
                            break;
                        case 'previewItem':
                            treeActions.preview(window.AdminPage.kendo_tree.instance().dataItem(context));
                            break;
                        case 'deletePageItem':
                            sitemap.remove.show(window.AdminPage.kendo_tree.instance().dataItem(context).id);
                            break;
                        case 'viewItemVersions':
                            treeActions.history(window.AdminPage.kendo_tree.instance().dataItem(context));
                            break;
                        default:
                            break;
                    }
                },

                onShow: function (e, context) {
                    var node = window.AdminPage.kendo_tree.instance().dataItem(context);
                    contextMenu.setButtonsStatus(
                        node.StatusName == Enums.ItemState.Published,
                        node.id,
                        node.IsVersion);
                }
            });

            var itemFormat = "<li id=\"{0}\" class=\"icon\"><span class=\"icon {1}\"></span>{2}</li>";
            var separator = "<li class=\"separator\"></li>";
            $('#contextmenu').append(
                jQuery.validator.format(itemFormat, "refreshItem", "refresh", SiteMap.Toolbar.RefreshItem));
            $('#contextmenu').append(separator);
            $('#contextmenu').append(
                jQuery.validator.format(itemFormat, "publishItem", "done", SiteMap.Toolbar.PublishItem));
            $('#contextmenu').append(
                jQuery.validator.format(itemFormat, "addPageItem", "add", SiteMap.Toolbar.AddChildPageItem));
            $('#contextmenu').append(
                jQuery.validator.format(itemFormat, "addVersionPageItem", "add", SiteMap.Toolbar.AddVersionPageItem));
            $('#contextmenu').append(
                jQuery.validator.format(itemFormat, "editPageItem", "edit", SiteMap.Toolbar.EditPageItem));
            $('#contextmenu').append(separator);
            $('#contextmenu').append(
                jQuery.validator.format(itemFormat, "previewItem", "preview", SiteMap.Toolbar.PreviewItem));
            $('#contextmenu').append(
                jQuery.validator.format(itemFormat, "viewItemVersions", "history", SiteMap.Toolbar.PreviewItemVersions));
            $('#contextmenu').append(separator);
            $('#contextmenu').append(
                jQuery.validator.format(itemFormat, "deletePageItem", "delete", SiteMap.Toolbar.DeletePageItem));

            $("li#viewItemVersions,li#refreshItem,li#publishItem,li#deletePageItem,li#addPageItem,li#editPageItem,li#addVersionPageItem,li#previewItem")
                .prop("disabled", true).addClass("disabled");
        },

        setButtonsStatus: setButtonsStatus
    };
}();
