window.AdminPage = window.AdminPage || {};
window.AdminPage.debug_mode = false;
window.AdminPage.getTreeNodeName = function(prefix) {
  if (window.AdminPage.debug_mode) {
    return '#: ' + prefix + '.Name # (#: ' + prefix + '.Id #) (#: ' + prefix + '.Title #)';
  } else {
    return '#: ' + prefix + '.Name # (#: ' + prefix + '.Title #)';
  }
}

window.AdminPage.kendo_tree = function () {
    var _template = kendo.template("<span class='icon-container'><img class='k-image' alt='' src='#= data.Icon #'>" +
                "# if (data.HasContentVersions == true) { #" +
                "<img class='k-image versions' alt='' src='#= data.Icon #' />" +
                "# } #" +
                "# if (data.StatusName != Enums.ItemState.Published) { #" +
                "<span class='new'>&nbsp;</span>" +
                "# } #" +
                "</span><span><span class='tree-item #= (data.IsVisible == false & data.Id != SiteConfiguration.RootPageId) ? \"notVisible\" : \"\" #'>" + window.AdminPage.getTreeNodeName('data') + "</span>" +
                " <span class='region'>#: data.RegionsString #</span>" +
                " <span class='culture'>#: data.Culture #</span></span>");

    var init = function () {
        $("#treeview").kendoTreeView({
            dataSource: new kendo.data.HierarchicalDataSource({
                data: [],
                schema: {
                    model: {
                        id: "Id", hasChildren: "HasChildren"
                    }
                }
            }),
            template: kendo.template("<span class='icon-container'><img class='k-image' alt='' src='#= item.Icon #' />" +
                "# if (item.HasContentVersions == true) { #" +
                "<img class='k-image versions' alt='' src='#= item.Icon #' />" +
                "# } #" +
                "# if (item.StatusName != Enums.ItemState.Published) { #" +
                "<span class='new'>&nbsp;</span>" +
                "# } #" +
                "</span><span><span class='tree-item #= (item.IsVisible == false & item.Id != SiteConfiguration.RootPageId) ? \"notVisible\" : \"\" #'>" + window.AdminPage.getTreeNodeName('item') + "</span>" +
                " <span class='region'>#: item.RegionsString #</span>" +
                " <span class='culture'>#: item.Culture #</span></span>"),

            dataTextField: ["Text"],
            dataImageUrlField: "",

            dragAndDrop: true,
            drag: onDragging,
            drop: onDrop,

            expand: onExpand,

            select: onSelect
        });

        initItemDifinitionDataSource();
    };

    var _itemDifinitionDataSource;
    function initItemDifinitionDataSource() {
        _itemDifinitionDataSource = QP.Data.createDataSource(
                MvcJs.Dictionary.AjaxDiscriminatorConstraints(),
                null,
                function (data) {
                    return data.List;
                },
                false,
                null);

        _itemDifinitionDataSource.read();
    }

    function findItemDifinition(id, typeId) {
        if (jQuery.type(_itemDifinitionDataSource) == "undefined") {
            return true;
        }

        var data = _itemDifinitionDataSource.data();
        var hasAll = true;
        var hasType = false;

        $.each(data, function (idx, value) {
            if (value[MvcJs.ViewModels.Dictionary.DiscriminatorConstraintViewModel.Props.SourceId.Id] == id) {
                hasAll = false;
                return;
            }
        });

        if (hasAll) {
            return true;
        }

        $.each(data, function (idx, value) {
            if (value[MvcJs.ViewModels.Dictionary.DiscriminatorConstraintViewModel.Props.SourceId.Id] == id &&
                value[MvcJs.ViewModels.Dictionary.DiscriminatorConstraintViewModel.Props.TargetId.Id] == typeId) {
                hasType = true;
                return;
            }
        });

        return hasType;
    }

    var _cultureId, _regions;
    function onExpand(e) {
        var id = instance().dataItem(e.node).id;

        if ($(e.node).children('ul').children('li').length == 0) {
            loadItems(id, _cultureId, _regions, $(e.node));
        }
    }

    function onDragging(e) {
        try {
            var source = instance().dataItem(e.sourceNode);
            if (source == null) {
                e.setStatusClass("k-denied");
                return;
            }

            if (source.level() < 2) {
                e.setStatusClass("k-denied");
                return;
            }

            var parentNode = instance().dataItem($(e.sourceNode)
                .closest(".k-group")
                .closest(".k-item"));

            if (e.originalEvent == null) {
                e.setStatusClass("k-denied");
                return;
            }

            if (e.originalEvent.shiftKey) {
                if (parentNode != null && e.dropTarget != null) {
                    var targetParentNode = instance().dataItem($(e.dropTarget)
                        .closest(".k-group")
                        .closest(".k-item"));
                    if (targetParentNode == null || parentNode.uid != targetParentNode.uid) {
                        e.setStatusClass("k-denied");
                        return;
                    }
                    else {
                        e.setStatusClass("k-insert-top");
                    }
                }

                return;
            }

            var target = instance().dataItem($(e.dropTarget));

            if (source != null && target != null) {
                if (source.CultureId != target.CultureId && source.CultureId != "" && target.CultureId != "") {
                    e.setStatusClass("k-denied");
                    return;
                }
            }

            if (parentNode != null && target != null) {
                if (target.uid == null) {
                    e.setStatusClass("k-denied");
                    return;
                }

                if (e.dropTarget != null && parentNode.uid == target.uid) {
                    e.setStatusClass("k-denied");
                    return;
                }

                if (e.dropTarget != null && parentNode.CultureId != target.CultureId && parentNode.CultureId != "" && target.CultureId != "") {
                    //console.log("cultures don't equal: parent - " + parentNode.CultureId + ", target - " + target.CultureId);
                    e.setStatusClass("k-denied");
                    return;
                }

                if ($(AdminPage.kendo_tree.instance().element).find(".k-drop-hint").css("visibility") == "visible") {
                    if ($(AdminPage.kendo_tree.instance().element).find(".k-drop-hint").prevAll(".k-in").length > 0 ||
                        $(AdminPage.kendo_tree.instance().element).find(".k-drop-hint").nextAll(".k-in").length > 0) {
                        e.setStatusClass("k-denied");
                        return;
                    }
                }

                if (!findItemDifinition(target.DiscriminatorId, source.DiscriminatorId)) {
                    e.setStatusClass("k-denied");
                    return;
                }
            }
        }
        catch (ex) {
        }
    }

    function onDrop(e) {
        if (e.valid == false) {
            e.setValid(false);
            return;
        }

        //TODO: bug after drop - not render icon for opening node
        var source = instance().dataItem(e.sourceNode);
        if (source == null) {
            e.setValid(false);
            return;
        }

        if (source.level() < 2 || e.destinationNode == null) {
            e.setValid(false);
            return;
        }

        var parentNode = instance().dataItem($(e.sourceNode)
            .closest(".k-group")
            .closest(".k-item"));

        var target = instance().dataItem($(e.destinationNode));
        if (target == null) {
            e.setValid(false);
            return;
        }

        if (e.originalEvent.shiftKey) {
            if (parentNode != null && e.dropTarget != null) {
                var targetParentNode = instance().dataItem($(e.destinationNode)
                    .closest(".k-group")
                    .closest(".k-item"));
                if (parentNode.uid != targetParentNode.uid) {
                    e.setValid(false);
                    return;
                }
            }
            e.preventDefault();
            treeActions.reorder(e);
            return;
        }

        if (e.dropPosition != "over") {
            e.setValid(false);
            return;
        }

        if (source != null && target != null) {
            if (source.CultureId != target.CultureId && source.CultureId != "" && target.CultureId != "") {
                e.setValid(false);
                return;
            }
        }

        if (parentNode != null) {
            if (parentNode.uid == target.uid) {
                e.setValid(false);
                return;
            }

            if (parentNode.CultureId != target.CultureId && parentNode.CultureId != "" && target.CultureId != "") {
                e.setValid(false);
                return;
            }
        }

        if (source.uid == target.uid) {
            e.setValid(false);
            return;
        }

        if (!findItemDifinition(target.DiscriminatorId, source.DiscriminatorId)) {
            e.setValid(false);
            return;
        }

        e.preventDefault();

        sitemap.move.restoreMoveWindowOptions();

        if (sitemap.move.getMoveWindowOptions() != null && sitemap.move.getMoveWindowOptions().IsDoNotAskAgain && !e.originalEvent.ctrlKey) {
            treeActions.move(e);
        }
        else {
            sitemap.move.show({
                sourceNode: e.sourceNode,
                dropPosition: e.dropPosition,
                destinationNode: e.destinationNode
            });
        }
    }

    function loadItems(id, cultureId, regions, node) {
        common.showProgress();

        //TODO: refactoring loading
        ajax.post(MvcJs.SiteMap.AjaxTree(), {
          ParentId: id,
          CultureId: cultureId,
          Regions: regions
        }, function (result) {

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
                    var treeView = $('#treeview');
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
        return $("#treeview").data("kendoTreeView");
    }

    function getCurrentNode() {
        var selected = $("#treeview").find(".k-state-selected");
        if (selected.length == 1) {
            var uid = instance().dataItem($(selected[0])).uid;
            var node = instance().findByUid(uid);
            return node;
        }
        return null;
    }

    function getCurrentNodeId() {
        var selected = $("#treeview").find(".k-state-selected");
        if (selected.length == 1) {
            return instance().dataItem($(selected[0])).id;
        }
        return null;
    }

    function onSelect(e) {
        toolbar.setButtonsStatus(
            instance().dataItem(e.node).StatusName == Enums.ItemState.Published,
            instance().dataItem(e.node).id,
            instance().dataItem(e.node).IsVersion);
        contextMenu.setButtonsStatus(
            instance().dataItem(e.node).StatusName == Enums.ItemState.Published,
            instance().dataItem(e.node).id,
            instance().dataItem(e.node).IsVersion);

        tabs.reload(instance().dataItem(e.node).id);
    }

    function getNodeById(id) {
        var nodes = instance().element.find(".k-in");
        var result = null;
        $.each(nodes, function (idx, value) {
            var node = AdminPage.kendo_tree.instance().dataItem(value);

            if (node.Id == id) {
                result = instance().findByUid(node.uid);
                return;
            }
        });

        return result;
    }

    return {
      redrawNode: function (data) {
        var dataSource = AdminPage.kendo_tree.instance().dataSource;
        var item = dataSource.get(data.Id);

        if (item == undefined) {
          return;
        }

        item.set("Name", data.Name);
        item.set("Title", data.Title);
        item.set("Culture", data.Culture);
        item.set("CultureId", data.CultureId);
        item.set("RegionsString", data.RegionsString);
        item.set("IsVisisble", data.IsVisisble);
        item.set("HasContentVersions", data.HasContentVersions);

        $(AdminPage.kendo_tree.getNodeById(data.Id)).find(".k-in:first").html(_template(data));
      },

      init: init,
      instance: instance,
      load: function (id, cultureId, regions, node) {
        _cultureId = cultureId;
        _regions = regions;
        loadItems(id, _cultureId, _regions, node);
      },

      reloadCurrentNode: function () {
        var selected = $("#treeview").find(".k-state-selected");
        if (selected.length == 1) {
          var uid = instance().dataItem($(selected[0])).uid;
          var id = instance().dataItem($(selected[0])).id;
          var node = instance().findByUid(uid);
          loadItems(id, _cultureId, _regions, node);
        }
      },

      currentNode: function () {
        return getCurrentNode();
      },

      currentNodeId: function () {
        return getCurrentNodeId();
      },

      getNodeById: function (id) {
        return getNodeById(id);
      },

      root: function () {
        return instance().root;
      }
    };
}();

$(document).ready(function () {
    var _archiveLoad = false;

    function onActivate(e) {
        var name = $(e.item).attr("id");

        if (name == "tabArchive" && !_archiveLoad) {
            $('#sitemap-tabstrip').find("#" + name + " .k-link").data(
                'contentUrl', MvcJs.SiteMap.Archive());
            $('#sitemap-tabstrip').data("kendoTabStrip").reload("#" + name);
        }
    }

    function currentTab() {
        return $('#sitemap-tabstrip').data("kendoTabStrip").select();
    }

    function resizeTabs() {
        var outerHeight = $("#main-menu").outerHeight(true) +
                $("#global-toolbar").outerHeight(true);
        var h = $(window).outerHeight(true);

        var tabsHeight = $("#sitemap-tabstrip > .k-tabstrip-items").outerHeight();
        $("#sitemap-tabstrip > div").height((h - tabsHeight) - (outerHeight + 15));
    }

    $("#sitemap-tabstrip").kendoTabStrip({
        animation: false,
        activate: onActivate,
        error: ajax.defaultError,
        contentLoad: function (e) {
            var name = $(e.item).attr("id");

            if (name == "tabArchive" && !_archiveLoad) {
                sitemap.archive.init();
                _archiveLoad = true;
            }
        }
    });

    splitter.init();
    AdminPage.kendo_tree.init();
    filter.init();
    toolbar.init();

    AdminPage.kendo_tree.load();

    contextMenu.init();
    tabs.init();

    splitter.resizeSplitter();
    tabs.resizeTabs();
    resizeTabs();

    $(window).resize(function () {
        splitter.resizeSplitter();
        tabs.resizeTabs();
        resizeTabs();
    });

    var events = {
        onAdd: function (args) {
            treeActions.redrawNode(args.id);
        },

        onRemove: function (args) {
            treeActions.redrawNode(args.id);
        }
    };

    if (Observer != null) {
        Observer.addListener(events, EventNames.addContentVersion, "onAdd");
        Observer.addListener(events, EventNames.deleteContentVersion, "onRemove");
    }
});

siteMap = {};
siteMap.common = function () {
    return {
        addCode: "addAbstractItem",
        editCode: "editAbstractItem",
        previewCode: "previewAbstractItem",
        historyCode: "viewItemHistory",
        copyCode: "copyAbstractItem"
    }
}();
