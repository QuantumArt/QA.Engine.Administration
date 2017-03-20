var toolbar = function () {
    var init = function () {
        $("#btnRefresh")
            .bind("click", function () {
                treeActions.refreshCurrent();
            });

        $("#btnPublish")
            .bind("click", function () {
                var nodeId = window.AdminPage.kendo_tree.currentNodeId();
                if (nodeId == null) {
                    return;
                }

                treeActions.publish(nodeId, window.AdminPage.kendo_tree.currentNode());
            });

        $("#btnAddPage")
            .bind("click", function () {
                var node = window.AdminPage.kendo_tree.currentNode();
                if (node == null) {
                    return;
                }

                sitemap.add.show(
                    {
                        id: window.AdminPage.kendo_tree.instance().dataItem(node).id,
                        callback: function (form) {
                            var name = form.find("#Name").val();

                            ajax.post(
                                    MvcJs.SiteMap.AjaxGetSiteMap(),
                                    {
                                        name: name,
                                        parentId: window.AdminPage.kendo_tree.instance().dataItem(node).id
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


                        }, isVersion: false, canChangeType: false
                    });
            });

        $("#btnEditPage")
            .bind("click", function () {
                var node = window.AdminPage.kendo_tree.currentNode();
                if (node == null) {
                    return;
                }

                treeActions.edit(window.AdminPage.kendo_tree.instance().dataItem(node));
            });

        $("#btnDeletePage")
            .bind("click", function () {
                var nodeId = window.AdminPage.kendo_tree.currentNodeId();
                if (nodeId == null) {
                    return;
                }

                sitemap.remove.show(nodeId);
            });
        $("#btnPreviewPage")
            .bind("click", function () {
                var node = window.AdminPage.kendo_tree.currentNode();
                if (node == null) {
                    return;
                }

                treeActions.preview(window.AdminPage.kendo_tree.instance().dataItem(node));
            });

        $("#btnRefresh,#btnPublish,#btnDeletePage,#btnAddPage,#btnEditPage,#btnPreviewPage")
            .attr("disabled", "disabled")
            .addClass("k-state-disabled");
    };

    var setButtonsStatus = function (
        isPublished,
        id,
        isVersion) {

        if (isPublished == false) {
            $("#btnPublish").removeAttr("disabled", "disabled").removeClass("k-state-disabled");
        } else if (isPublished == true || isPublished == undefined) {
            $("#btnPublish").attr("disabled", "disabled").addClass("k-state-disabled");
        }

        if (isVersion == true || isVersion == undefined) {
            $("#btnAddPage").attr("disabled", "disabled").addClass("k-state-disabled");
        } else if (isVersion == false) {
            $("#btnAddPage").removeAttr("disabled", "disabled").removeClass("k-state-disabled");
        }

        $("#btnRefresh").removeAttr("disabled", "disabled").removeClass("k-state-disabled");

        if (SiteConfiguration.RootPageId == id || id == undefined) {
            $("#btnDeletePage,#btnEditPage,#btnPreviewPage").attr("disabled", "disabled").addClass("k-state-disabled");
        } else {
            $("#btnDeletePage,#btnEditPage,#btnPreviewPage").removeAttr("disabled", "disabled").removeClass("k-state-disabled");
        }
    }

    return {
        init: init,
        setButtonsStatus: setButtonsStatus
    };
}();
