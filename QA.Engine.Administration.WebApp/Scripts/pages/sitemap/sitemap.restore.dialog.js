if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.restore) == "undefined") {
    sitemap.restore = (function () {
        return {
            show: function (id) {
                common.confirm({
                    okCallback: function () {
                        var dialog = new sitemap.crud.dialog();
                        dialog.show({
                            title: SiteMap.AjaxRestore.RestoreWindowTitle,
                            url: MvcJs.SiteMap.AjaxRestore(),
                            data: { Id: id },
                            selector: "#archiveRestoreWindow",
                            callback: sitemap.archive.restore,
                            onready: function (form) {
                                if ($(form).find("#IsPage").val().toLowerCase() == "false" ||
                                    $(form).find("#IsVersion").val().toLowerCase() == "true") {
                                    $(form).find("#IsRestoreAllVersions").addClass("k-state-disabled");
                                    $(form).find("#IsRestoreAllVersions").prop("disabled", true);

                                    $(form).find("#IsRestoreWidgets").addClass("k-state-disabled");
                                    $(form).find("#IsRestoreWidgets").prop("disabled", true);

                                    $(form).find("#IsRestoreContentVersions").addClass("k-state-disabled");
                                    $(form).find("#IsRestoreContentVersions").prop("disabled", true);

                                    if ($(form).find("#IsVersion").val().toLowerCase() == "true") {
                                        $(form).find("#IsRestoreAllChildren").addClass("k-state-disabled");
                                        $(form).find("#IsRestoreAllChildren").prop("disabled", true);
                                    }
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
