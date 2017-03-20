var tabs = function () {
    var _id = 0;
    function onActivate(e) {
        if (obsolete($(e.item).attr("id")) == true) {
            var currentName = $(e.item).attr("id");
            reload(currentName, baseUrl(currentName) + "?Id=" + _id);
            obsolete(currentName, false);
        }
    }

    function reload(name, url) {
        $('#tabstrip').find("#" + name + " .k-link").data(
            'contentUrl', url);
        $('#tabstrip').data("kendoTabStrip").reload("#" + name);
    }

    function obsolete(name, val) {
        if (val == null) {
            return $('#tabstrip').find("#" + name + " .k-link").data(
                'isObsolete');
        }
        $('#tabstrip').find("#" + name + " .k-link").data(
            'isObsolete', val);
    }

    function baseUrl(name, val) {
        if (val == null) {
            return $('#tabstrip').find("#" + name + " .k-link").data(
                'baseUrl');
        }
        $('#tabstrip').find("#" + name + " .k-link").data(
            'baseUrl', val);
    }

    function current() {
        return $('#tabstrip').data("kendoTabStrip").select();
    }

    function tabCommonComplete() {
        sitemap.info.init();
    }

    function tabContentVersionsComplete() {
        sitemap.contentversions.init();
    }

    function tabRegionsComplete() {
        sitemap.regions.init();
    }

    function tabWidgetsComplete() {
        sitemap.widgets.init();
    }

    return {
        init: function () {
            $("#tabstrip").kendoTabStrip({
                animation: false,
                activate: onActivate,
                error: ajax.defaultError,
                contentLoad: function (e) {
                    try
                    {
                        eval($(current()).attr("id") + "Complete")();
                    }
                    catch(e)
                    {
                    }
                }
            });

            baseUrl("tabContentVersions", MvcJs.SiteMap.ContentVersions());
            baseUrl("tabRegions", MvcJs.SiteMap.Regions());
            baseUrl("tabWidgets", MvcJs.SiteMap.Widgets());
            baseUrl("tabCommon", MvcJs.SiteMap.Info());
        },

        resizeTabs: function () {
            var paneHeight = $("#tabstrip").closest(".k-pane").innerHeight();
            var tabsHeight = $("#tabstrip > .k-tabstrip-items").outerHeight();
            $("#tabstrip > div").height(paneHeight - tabsHeight - 15);
        },

        reload: function (id) {
            _id = id;
            var currentName = $(current()).attr("id");

            reload(currentName, baseUrl(currentName) + "?Id=" + id);

            obsolete("tabRegions", true)
            obsolete("tabWidgets", true)
            obsolete("tabContentVersions", true)
            obsolete("tabCommon", true)

            obsolete(currentName, false);
        }
    }
}();
