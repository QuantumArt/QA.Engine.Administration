var splitter = function () {
    var init = function () {
        $("#splitter").kendoSplitter({
            panes: [
                {
                    collapsible: true,
                    size: "520px"
                },
                {}
            ]
        });
    };

    return {
        init: init,

        instance: function () {
            return $("#splitter");
        },

        height: function (h) {
            $("#splitter-container")
                .height(h);
            $("#splitter").data("kendoSplitter").trigger("resize");
        },

        resizeSplitter: function () {
            var tabsHeight = $("#sitemap-tabstrip > .k-tabstrip-items").outerHeight();
            var outerHeight = $("#main-menu").outerHeight(true) +
                $("#filter-container").outerHeight(true) +
                $("#toolbar-container").outerHeight(true) +
                $("#global-toolbar").outerHeight(true);
            var h = $(window).outerHeight(true);
            splitter.height((h - outerHeight) - (tabsHeight + 15));
        }
    };
}();
