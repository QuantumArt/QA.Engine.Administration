if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}
//TODO: refactoring, use crud.dialog.js
if (jQuery.type(sitemap.move) == "undefined") {
    sitemap.move = (function () {
        var init = function () {
            _window = $("<div id=\"moveWindow\" class=\"display-none\"></div>")
                .kendoWindow({
                    width: "615px",
                    modal: true,
                    title: SiteMap.AjaxMove.MoveDialogTitle,
                    refresh: onRefresh,
                    error: ajax.defaultError,
                    animation: false,
                    url: MvcJs.SiteMap.AjaxMove(),
                })
                .data("kendoWindow");
        };

        function saveMoveWindowOptions() {
            var $form = $("#moveForm");
            $.cookie("moveOptions", JSON.stringify(($form.serializeObject())));
        }

        function restoreMoveWindowOptions() {
            var $form = $("#moveForm");
            $form.deserializeObject(getMoveWindowOptions());
        }

        function getMoveWindowOptions() {
            return JSON.parse($.cookie("moveOptions"));
        }

        function onRefresh() {
            $("#btnCancelMove")
                    .unbind("click");
            $("#btnCancelMove")
                .bind("click", function () {
                    hide();
                });

            $("#btnMove").unbind("click");
            $("#btnMove")
                .bind("click", function () {
                    saveMoveWindowOptions();
                    treeActions.move(_options);
                });

            $("#btnCopy").unbind("click");
            $("#btnCopy")
                .bind("click", function () {
                    treeActions.copy(_options);
                });

            _window.center().open();

            common.hideProgress();
        }

        function hide() {
            _window.close();
            _window.destroy();
        }

        var _options;
        var _window;

        return {
            init: init,

            saveMoveWindowOptions: saveMoveWindowOptions,
            restoreMoveWindowOptions: restoreMoveWindowOptions,
            getMoveWindowOptions: getMoveWindowOptions,

            instance: function () {
                if (_window == null || _window.data("kendoWindow") == null) {
                    return null;
                }
                return _window;
            },

            show: function (options) {
                _options = options;

                common.showProgress();

                init();

                _window.refresh(
                    {
                        url: MvcJs.SiteMap.AjaxMove(),
                        options: {
                            contentType: "application/json"
                        }
                    });
            },

            hide: hide
        }
    })();
}
