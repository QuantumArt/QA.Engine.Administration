if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.remove) == "undefined") {
    sitemap.remove = (function () {
        function loadVersions(id, form) {
            common.showProgress();

            var dataSource = QP.Data.createDataSource(
                MvcJs.SiteMap.AjaxContentVersions(),
                function (options, operation) {
                    if (operation == "read") {
                        return {
                            Id: id
                        };
                    }
                    return options;
                },
                function (data) {
                    return data.List;
                });

            $(form).find("#ContentVersionId").removeAttr("value");
            $(form).find("#ContentVersionId").kendoComboBox({
                dataTextField: "View",
                dataValueField: "Id",
                dataSource: dataSource
            });
        }

        return {
            show: function (id) {
                common.confirm({
                    okCallback: function () {
                        var dialog = new sitemap.crud.dialog();
                        dialog.show({
                            title: SiteMap.AjaxRemove.DeleteWindowTitle,
                            url: MvcJs.SiteMap.AjaxRemove(),
                            data: { Id: id },
                            selector: "<div id=\"removeWindow\" class=\"display-none\"></div>",
                            callback: treeActions.del,
                            onready: function (form) {
                                loadVersions(id, form);

                                var combobox = $(form).find("#ContentVersionId").data("kendoComboBox");

                                if ($(form).find("#OperationsByContentVersion_Delete").val() == Enums.ContentVersionOperations.Delete) {
                                    combobox.enable(false);
                                }

                                $(form).find("#OperationsByContentVersion_Move").bind("click", function () {
                                    combobox.enable(true);
                                });

                                $(form).find("#OperationsByContentVersion_Delete").bind("click", function () {
                                    combobox.enable(false);
                                });

                                $(form).find(".button-refresh").bind("click", function () {
                                    loadVersions(id, form);
                                });

                                $(form).find("#IsDeleteAllVersions").bind("click", function () {
                                    if ($(this).is(':checked')) {
                                        $(form).find("#blockContentVersions").addClass("k-state-disabled");
                                        $(form).find("#blockContentVersions").prop("disabled", true);
                                    } else {
                                        $(form).find("#blockContentVersions").removeClass("k-state-disabled");
                                        $(form).find("#blockContentVersions").prop("disabled", false);
                                    }
                                });
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
