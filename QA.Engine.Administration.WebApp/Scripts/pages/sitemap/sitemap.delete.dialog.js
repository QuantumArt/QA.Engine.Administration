if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.del) == "undefined") {
    sitemap.del = (function () {
        return {
            show: function (id) {
                common.confirm({
                    okCallback: function () {
                        var dialog = new sitemap.crud.dialog();
                        dialog.show({
                            title: SiteMap.AjaxDelete.DeleteWindowTitle,
                            url: MvcJs.SiteMap.AjaxDelete(),
                            data: { Id: id },
                            selector: "#archiveDeleteWindow",
                            callback: sitemap.archive.del,
                            onready: function (form) {
                                if ($(form).find("#IsPage").val().toLowerCase() == "false" ||
                                    $(form).find("#IsVersion").val().toLowerCase() == "true") {
                                    $(form).find("#IsDeleteAllVersions").addClass("k-state-disabled");
                                    $(form).find("#IsDeleteAllVersions").prop("disabled", true);
                                }
                            },
                            cancelBtn: "#btnCancel",
                            validateForm: true
                        });
                    }
                });
            }
        }
    })();
}
