var globalToolbar = function () {
    var init = function () {
        var dataSource = new kendo.data.DataSource({
            transport: {
                read: function(options) {
                    $.ajax({
                        url: MvcJs.Home.AjaxSites(),
                        type: "POST",
                        success: function (result) {
                            options.success(result);

                            var combobox = $("#toolbar_sites").data("kendoComboBox");

                            combobox.select(function (dataItem) {
                                return dataItem.Value === SiteConfiguration.CurrentName;
                            });
                        },
                        error: ajax.defaultError
                    });
                }
            }
        });

        $("#toolbar_sites").kendoComboBox({
            dataTextField: "Text",
            dataValueField: "Value",
            dataSource: dataSource,
            change: function (e) {
                var val = e.sender.dataItem().Value;

                $.ajax({
                    url: MvcJs.Home.AjaxSetSite(),
                    data: {
                        Name: val
                    },
                    type: "POST",
                    success: function (result) {
                        document.location.reload(false);
                    },
                    error: ajax.defaultError,
                    contentType: "application/json"
                });
            }
        });
    };

    return {
        init: init
    };
}();

$(document).ready(function () {
    globalToolbar.init();
});
