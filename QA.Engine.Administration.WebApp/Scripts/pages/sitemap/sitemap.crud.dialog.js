if (jQuery.type(sitemap) == "undefined") {
    var sitemap = {

    };
}

if (jQuery.type(sitemap.crud) == "undefined") {
    sitemap.crud = (function () {

        var dialog = function () {
            var _window;
            var _options;

            function onRefresh() {
                $(_window.element).find(_options.cancelBtn).unbind("click");
                $(_window.element).find(_options.cancelBtn).bind("click", function () {
                    hide();
                });

                if (_options.beforeValidate == null) {
                    _options.beforeValidate = function () {
                        return true;
                    }
                }

                var $form = $($(_window.element).find("form"));

                $form.unbind("submit");

                $form.bind("submit", function (event) {
                    event.preventDefault();

                    if (!_options.validateForm) {
                        _options.callback($form);

                        hide();
                    }
                    else {
                        if (_options.beforeValidate($form)) {
                            //$.validator.unobtrusive.parse($form);

                            if (_options.validator.validate()) {
                                _options.callback($form);

                                hide();
                            }
                        } else {
                            _options.callback($form);

                            hide();
                        }
                    }

                    return false;
                });

                _options.validator = $form.kendoValidator(
                    _options.validatorRules == null ? common.validationrules : _options.validatorRules
                ).data("kendoValidator");

                if (jQuery.type(_options.onready) != "undefined") {
                    _options.onready($form);
                }

                _window.center().open();

                common.hideProgress();
            }

            function hide() {
                if (_options.onClose !== undefined && _options.onClose !== null) {
                    _options.onClose();
                }

                _window.close();
                _window.destroy();
            }

            return {
                show: function (options) {
                    _options = options;
                    if (jQuery.type(options) != "object") {
                        return;
                    }

                    common.showProgress();

                    _window = $(options.selector)
						.kendoWindow({
						    width: "615px",
						    modal: true,
						    title: options.title,
						    refresh: onRefresh,
						    error: ajax.defaultError,
						    animation: false,
						    //TODO: after second close by "Close" background stay blocked
						    actions: {}
						})
						.data("kendoWindow");

                    _window.refresh(
					{
					    url: options.url,
					    data: options.data,
					    options: {
					        contentType: "application/json"
					    }
					});

                }
            }
        };

        dialog.prototype = {

        };

        return {
            dialog: dialog
        };
    })();
}
