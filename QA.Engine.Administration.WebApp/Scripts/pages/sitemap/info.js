if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.info) == "undefined") {
    sitemap.info = (function () {
        return {
            init: function () {
                $("#btnEdit").bind("click", function () {
                    common.showProgress();

                    var $form = $("#EditForm");

                    $form.unbind("submit");

                    $form.bind("submit", function (event) {
                        event.preventDefault();

                        $.validator.unobtrusive.parse($form);

                        if ($form.valid()) {
                            ajax.post(
                                MvcJs.SiteMap.AjaxEditItem(),
                                $form.serializeObject(),
                                function (result) {
                                    if (ajax.showError(result)) {
                                        return;
                                    }

                                    if (window.AdminPage.kendo_tree != null) {
                                        window.AdminPage.kendo_tree.redrawNode(result);
                                    }

                                    common.hideProgress();
                                });
                        }

                        return false;
                    });
                });

                $("#EditForm").find("#btnRefresh").bind("click", function () {
                    tabs.reload($("#EditForm").find("#Id").val());
                });
            }
        }
    })();
}
