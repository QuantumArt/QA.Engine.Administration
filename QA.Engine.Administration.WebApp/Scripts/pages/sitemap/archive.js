if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.archive) == "undefined") {
    sitemap.archive = (function () {
        function onExpand(e) {
            var id = instance().dataItem(e.node).id;

            if ($(e.node).children('ul').children('li').length == 0) {
                loadItems(id, $(e.node));
            }
        }

        function reload(url) {
            $('#archive-tabstrip').find("#tabCommon .k-link").data(
                'contentUrl', url);
            $('#archive-tabstrip').data("kendoTabStrip").reload("#tabCommon");
        }

        function onSelect(e) {
            reload(MvcJs.SiteMap.ArchiveInfo() + "?Id=" + instance().dataItem(e.node).id);
            setButtonsStatus(
                instance().dataItem(e.node).id,
                instance().dataItem(e.node).level());
        }

        function loadItems(id, node) {
            common.showProgress();

            //TODO: refactoring loading
            ajax.post(
                MvcJs.SiteMap.AjaxArchiveTree(),
                {
                    ParentId: id
                },
                function (result) {

                    if (ajax.showError(result)) {
                        return;
                    }

                    if (node != null) {
                        var children = $(node).children('ul').children('li');
                        if (children.length > 0) {
                            for (var i = 0; i <= children.length - 1; i++) {
                                instance().remove($(children[i]));
                            }
                        }
                    }
                    else {
                        var treeView = $('#archive-treeview');
                        var treeViewData = instance();
                        treeView.each(function (n, root) {
                            for (var i = root.childNodes[0].childNodes.length - 1; i >= 0; i--) {
                                treeViewData.remove(root.childNodes[0].childNodes[i]);
                            }
                        });
                    }

                    instance().append(result.List, node);

                    common.hideProgress();
                });
        }

        function instance() {
            return $("#archive-treeview").data("kendoTreeView");
        }

        function height(h) {
            $("#archive-splitter-container")
                .height(h);
            $("#archive-splitter").data("kendoSplitter").trigger("resize");
        }

        var setButtonsStatus = function (id, level) {
            $("#archive-toolbar-container")
                .find("#btnRefresh")
                .removeAttr("disabled", "disabled")
                .removeClass("k-state-disabled");

            if (id != null) {
                if (level > 0) {
                    $("#archive-toolbar-container")
                       .find("#btnRestore")
                       .attr("disabled", "disabled")
                       .addClass("k-state-disabled");
                }
                else {
                    $("#archive-toolbar-container")
                        .find("#btnRestore")
                        .removeAttr("disabled", "disabled")
                        .removeClass("k-state-disabled");
                }

                $("#archive-toolbar-container")
                    .find("#btnDelete")
                    .removeAttr("disabled", "disabled")
                    .removeClass("k-state-disabled");
            }
            else {
                $("#archive-toolbar-container")
                    .find("#btnDelete,#btnRestore")
                    .attr("disabled", "disabled")
                    .addClass("k-state-disabled");
            }
        }

        var setMenuButtonsStatus = function (id, level) {
            if (id == null) {
                $("#archive-contextmenu")
                    .find("li#refreshItem,li#deleteItem,li#restoreItem")
                    .prop("disabled", true)
                    .addClass("disabled");
            } else {
                $("#archive-contextmenu")
                    .find("li#refreshItem,li#deleteItem")
                    .prop("disabled", false)
                    .removeClass("disabled");

                if (level > 0) {
                    $("#archive-contextmenu")
                        .find("li#restoreItem")
                        .prop("disabled", true)
                        .addClass("disabled");
                } else {
                    $("#archive-contextmenu")
                        .find("li#restoreItem")
                        .prop("disabled", false)
                        .removeClass("disabled");
                }
            }
        }

        function reloadCurrentNode() {
            var selected = $("#archive-treeview").find(".k-state-selected");
            if (selected.length == 1) {
                var uid = instance().dataItem($(selected[0])).uid;
                var id = instance().dataItem($(selected[0])).id;
                var node = instance().findByUid(uid);
                loadItems(id, node);
            }
        }

        function getCurrentNodeId() {
            var selected = $("#archive-treeview").find(".k-state-selected");
            if (selected.length == 1) {
                return instance().dataItem($(selected[0])).id;
            }
            return null;
        }

        function getNodeById(id) {
            var nodes = instance().element.find(".k-in");
            var result = null;
            $.each(nodes, function (idx, value) {
                var node = instance().dataItem(value);

                if (node.Id == id) {
                    result = instance().findByUid(node.uid);
                    return;
                }
            });

            return result;
        }

        function initContentMenu() {
            $('#archive-treeview li[data-uid]').jeegoocontext('archive-contextmenu', {
                livequery: true,
                onSelect: function (e, context) {
                    var node = instance().findByUid(instance().dataItem(context).uid);
                    if (node == null) {
                        return;
                    }

                    if ($(this).hasClass("k-state-disabled")) {
                        return;
                    }

                    switch ($(this).attr('id')) {
                        case 'refreshItem':
                            loadItems(instance().dataItem(context).id, node);
                            break;
                        case 'restoreItem':
                            sitemap.restore.show(instance().dataItem(context).id);
                            break;
                        case 'deleteItem':
                            sitemap.del.show(instance().dataItem(context).id);
                            break;
                        default:
                            break;
                    }
                },

                onShow: function (e, context) {
                    var node = instance().dataItem(context);
                    setMenuButtonsStatus(
                        node.id,
                        node.level());
                }
            });

            var itemFormat = "<li id=\"{0}\" class=\"icon\"><span class=\"icon {1}\"></span>{2}</li>";
            var separator = "<li class=\"separator\"></li>";
            $('#archive-contextmenu').append(
                jQuery.validator.format(itemFormat, "refreshItem", "refresh", SiteMap.Archive.RefreshItem));
            $('#archive-contextmenu').append(separator);
            $('#archive-contextmenu').append(
                jQuery.validator.format(itemFormat, "restoreItem", "restore", SiteMap.Archive.RestoreItem));
            $('#archive-contextmenu').append(
                jQuery.validator.format(itemFormat, "deleteItem", "delete", SiteMap.Archive.DeleteItem));

            $("#archive-contextmenu li#deleteItem,#archive-contextmenu li#restoreItem,#archive-contextmenu li#refreshItem")
                .prop("disabled", true)
                .addClass("disabled");
        }

        return {
            init: function () {
                $("#archive-splitter").kendoSplitter({
                    panes: [
                        {
                            collapsible: true,
                            size: "520px"
                        },
                        {}
                    ]
                });

                $("#archive-treeview").kendoTreeView({
                    dataSource: new kendo.data.HierarchicalDataSource({
                        data: [],
                        schema: {
                            model: {
                                id: "Id", hasChildren: "HasChildren"
                            }
                        }
                    }),
                    template: kendo.template("<span class='icon-container'><img class='k-image' alt='' src='#= item.Icon #'>" +
                        "# if (item.StatusName != Enums.ItemState.Published) { #" +
                        "<span class='new'>&nbsp;</span>" +
                        "# } #" +
                        "</span><span><span class='tree-item'>#: item.Name # (#: item.Title #)</span>" +
                        " <span class='region'>#: item.RegionsString #</span>" +
                        " <span class='culture'>#: item.Culture #</span></span>"),

                    dataTextField: ["Text"],
                    dataImageUrlField: "",

                    select: onSelect,
                    expand: onExpand
                });

                loadItems();

                $("#archive-tabstrip").kendoTabStrip({
                    animation: false,
                    error: ajax.defaultError,
                    contentLoad: function () {
                        $("#arhiveViewForm").find("#btnRefresh").bind("click", function () {
                            reload(MvcJs.SiteMap.ArchiveInfo() + "?Id=" + $("#arhiveViewForm").find("#Id").val());
                        });
                    }
                });

                $("#archive-toolbar-container")
                    .find("#btnDelete,#btnRestore")
                    .attr("disabled", "disabled")
                    .addClass("k-state-disabled");

                $("#archive-toolbar-container").find("#btnRefresh")
                    .bind("click", function () {
                        loadItems();
                    });

                $("#archive-toolbar-container").find("#btnDelete")
                   .bind("click", function () {
                       var nodeId = getCurrentNodeId();
                       if (nodeId == null) {
                           return;
                       }

                       sitemap.del.show(nodeId);
                   });

                $("#archive-toolbar-container").find("#btnRestore")
                   .bind("click", function () {
                       var nodeId = getCurrentNodeId();
                       if (nodeId == null) {
                           return;
                       }

                       sitemap.restore.show(nodeId);
                   });

                sitemap.archive.resizeSplitter();

                initContentMenu();

                $(window).resize(function () {
                    sitemap.archive.resizeSplitter();
                });
            },

            resizeSplitter: function () {
                var tabsHeight = $("#sitemap-tabstrip > .k-tabstrip-items").outerHeight();
                var outerHeight = $("#main-menu").outerHeight(true) +
                    $("#archive-toolbar-container").outerHeight(true) +
                    $("#global-toolbar").outerHeight(true);
                var h = $(window).outerHeight(true);
                height((h - outerHeight) - (tabsHeight + 30));
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
                    MvcJs.SiteMap.AjaxDeleteItem(),
                    params,
                    function (result) {

                        if (ajax.showError(result)) {
                            return;
                        }

                        var currentNode = getNodeById(params["Id"]);

                        if (params["IsDeleteAllVersions"] == "true") {
                            var name = instance().dataItem(currentNode).Name;
                            var nodes = instance().element.find(".k-in");

                            $.each(nodes, function (idx, value) {
                                var node = instance().dataItem(value);

                                if (node != null) {
                                    if (node.Name == name) {
                                        instance().remove(value);
                                    }
                                }
                            });
                        }

                        instance().remove(currentNode);

                        reload(MvcJs.SiteMap.ArchiveInfo());

                        setButtonsStatus(null);

                        common.hideProgress();
                    },
                    ajax.defaultError);
            },

            restore: function (form) {
                var $form = form;

                common.showProgress();

                var params = $form.serializeObject();
                var isArray = $.isArray(params["IsRestoreAllVersions"]);
                if (isArray) {
                    params["IsRestoreAllVersions"] = params["IsRestoreAllVersions"][0];
                }

                isArray = $.isArray(params["IsRestoreWidgets"]);
                if (isArray) {
                    params["IsRestoreWidgets"] = params["IsRestoreWidgets"][0];
                }

                isArray = $.isArray(params["IsRestoreContentVersions"]);
                if (isArray) {
                    params["IsRestoreContentVersions"] = params["IsRestoreContentVersions"][0];
                }

                isArray = $.isArray(params["IsRestoreAllChildren"]);
                if (isArray) {
                    params["IsRestoreAllChildren"] = params["IsRestoreAllChildren"][0];
                }

                ajax.post(
                    MvcJs.SiteMap.AjaxRestoreItem(),
                    params,
                    function (result) {

                        if (ajax.showError(result)) {
                            return;
                        }

                        //var currentNode = getNodeById(params["Id"]);

                        function moveUpChildren(htmlNode) {
                            var node = instance().dataItem(htmlNode);
                            htmlNode = instance().findByUid(node.uid);
                            var children = $(htmlNode).children('ul').children('li');

                            if (children.length > 0) {
                                for (var i = 0; i <= children.length - 1; i++) {
                                    var child = instance().dataItem(children[i]);

                                    if (child == null) {
                                        continue;
                                    }

                                    if (params["IsRestoreAllVersions"] == "false" && child.IsPage) {
                                        instance().detach($(children[i]));
                                        instance().insertBefore($(children[i]), $(htmlNode));
                                    } else if (params["IsRestoreWidgets"] == "false" && !child.IsPage) {
                                        instance().detach($(children[i]));
                                        instance().insertBefore($(children[i]), $(htmlNode));
                                    } else if (params["IsRestoreContentVersions"] == "false" && child.IsVersion) {
                                        instance().detach($(children[i]));
                                        instance().insertBefore($(children[i]), $(htmlNode));
                                    }
                                }
                            }
                        }

                        loadItems();

                        //TODO: ?
                        /*if (params["IsRestoreAllVersions"] == "true") {
                            var name = instance().dataItem(currentNode).Name;
                            var parentId = instance().dataItem(currentNode).ParentId;
                            var nodes = instance().element.find(".k-in");

                            $.each(nodes, function (idx, value) {
                                var node = instance().dataItem(value);

                                if (node != null) {
                                    if (node.Name == name & node.IsPage & node.ParentId == parentId) {
                                        if (params["IsRestoreWidgets"] == "false" ||
                                            params["IsRestoreContentVersions"] == "false" ||
                                            params["IsRestoreAllChildren"] == "false") {
                                            moveUpChildren(value);
                                        }

                                        instance().remove(value);
                                    }
                                }
                            });
                        }
                        else {
                            if (params["IsRestoreWidgets"] == "false" ||
                                params["IsRestoreContentVersions"] == "false" ||
                                params["IsRestoreAllChildren"] == "false") {
                                moveUpChildren(currentNode);
                            }

                            instance().remove(currentNode);
                        }*/

                        reload(MvcJs.SiteMap.ArchiveInfo());

                        setButtonsStatus(null);

                        common.hideProgress();
                    },
                    ajax.defaultError);
            }
        }
    })();
}
