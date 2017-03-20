if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.add) == "undefined") {
    sitemap.add = (function () {
        var combobox;
        return {
            show: function (options) {
                var dialog = new sitemap.crud.dialog();
                dialog.show({
                    title: SiteMap.AjaxAdd.AddWindowTitle,
                    url: MvcJs.SiteMap.AjaxAdd(),
                    data: { ParentId: options.id, IsVersion: options.isVersion == null ? false : options.isVersion },
                    selector: "<div id=\"addWindow\" class=\"display-none\"></div>",
                    callback: options.callback,
                    onClose: function () {
                        if (combobox !== null && combobox !== undefined) {
                            combobox.destroy();
                        }
                    },
                    onready: function (form) {
                        QP.Data.loadDiscriminators(form, true);

                        $(form).find(".button-refresh").bind("click", function () {
                            QP.Data.loadDiscriminators(form, true);
                        });

                        //var button = $(form).find(".button-refresh");
                        combobox = $(form).find("#DiscriminatorId").data("kendoComboBox");

                        combobox.bind(
                            "select", function (e) {
                                var dataItem = this.dataItem(e.item.index());
                                $(form).find("#PreferredContentId").val(
                                    (dataItem.PreferredContentId == null ||
                                    dataItem.PreferredContentId == "" ||
                                    dataItem.PreferredContentId == "0") ? "0" : dataItem.PreferredContentId);
                            }
                        );

                        //if ($(form).find("#VersionTypeId_Content").val() == Enums.VersionTypes.Content) {
                        //    combobox.enable(false);
                        //    button.addClass("k-state-disabled");
                        //}

                        //$(form).find("#VersionTypeId_Content").bind("click", function () {
                        //    combobox.enable(false);
                        //    button.addClass("k-state-disabled");
                        //});

                        //$(form).find("#VersionTypeId_Structural").bind("click", function () {
                        //    combobox.enable(true);
                        //    button.removeClass("k-state-disabled");
                        //});

                        if (!options.canChangeType) {
                            $(form).find("#VersionTypeId_Structural").attr('disabled', true);
                        }

                        if (jQuery.type(options.typeId) != "undefined") {
                            $(form).find("#VersionTypeId_Structural").prop('checked', true);
                            $(form).find("#VersionTypeId_Structural").trigger("click");
                            combobox.value(options.typeId);
                        }
                    },
                    cancelBtn: "#btnAddCancel",
                    validateForm: true/*,
                    beforeValidate: function (form) {
                        return $(form).find("input[name=VersionTypeId]:checked").val() != Enums.VersionTypes.Content;
                    }*/
                });
            }
        }
    })();
}
