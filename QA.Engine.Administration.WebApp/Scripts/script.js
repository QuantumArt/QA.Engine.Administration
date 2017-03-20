//#region ajax
var ajax = (function (external) {

    external.inprogress = false;

    external.post = function (url, data, onSuccess, onError) {
        ///<summary>
        ///Вызывает POST запрос к url, результатом которого является выполнение successFunction, либо сообщение об ошибке
        ///</summary>

        return $.ajax({
            url: url,
            data: JSON.stringify(data),
            dataType: "json",
            type: "post",
            contentType: 'application/json; charset=UTF-8',
            //application/x-www-form-urlencoded; charset=UTF-8
            processData: false,
            success: function (data) {
                if (typeof onSuccess == 'function') {
                    onSuccess(restore(data));
                }
            },
            error: function (message) {
                common.hideProgress();

                if (typeof onError == 'function') {
                    onError({
                        status: message.status,
                        xhr: message
                    });
                } else {
                    ajax.defaultError({
                        status: message.status,
                        xhr: message
                    });
                }
            }
        })
    };

    function restore(o) {
        if (typeof (o) == "object") {
            for (var k in o) {
                if (typeof (o[k]) == "object") {
                    o[k] = restore(o[k])
                } else if (typeof (o[k]) == "string") {
                    // Восстановление даты
                    if (o[k].substr(1, 4) == "Date") {
                        o[k] = new Date(parseInt(o[k].replace(/^[\/Date\(]+|\)\/+$/g, '')));
                    }

                }
            }
        }
        return o;
    }

    external.defaultError = function (req, status, error) {
      common.hideProgress();

      if (ajax.showError(req)) {
        return true;
      }

      if (req.statusText && req.status) {
        window.alert(req.status + " " + req.statusText);
        return true;
      } else if (req.xhr && req.xhr.status) {
        window.alert(req.xhr.status + " " + req.xhr.statusText);
        return true;
      } else if (status === 'error') {
        window.alert(Global.ErrorMessages.UnknowErrorMessage);
      }

      return false;
    }

    external.showError = function (result) {
      common.hideProgress();

      if (!result) {
        return true;
      }

      if (!result.IsSucceeded) {
        if (result.Error && result.Error.ErrorMessage) {
          window.alert(result.Error.ErrorMessage);
        } else {
          window.alert(Global.ErrorMessages.UnknowErrorMessage);
        }

        return true;
      }

      return false;
    }

    return external;
}(ajax || {}));
//#endregion
//
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        var val = this.value;
        val = val == 'on' ? true : val == 'off' ? false : val;
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(val || '');
        } else {
            o[this.name] = val || '';
        }
    });
    return o;
};

$.fn.deserializeObject = function (data) {
    if (data == null) {
        return;
    }
    $.each(data, function (i, n) {
        var elem = $("[name='" + i + "']");
        if (elem.length > 0) {
            if (elem.attr("type") == "checkbox") {
                elem.attr("checked", n);
            } else {
                elem.val(n);
            }
        }
    });
};

var common = (function (external) {
    external.showProgress = function () {
        kendo.ui.progress($("body"), true);
    }

    external.hideProgress = function () {
        kendo.ui.progress($("body"), false);
    }

    external.GUID = function () {
        var S4 = function () {
            return Math.floor(
                    Math.random() * 0x10000 /* 65536 */
                ).toString(16);
        };

        return (
                S4() + S4() + "-" +
                S4() + "-" +
                S4() + "-" +
                S4() + "-" +
                S4() + S4() + S4()
            );
    }

    external.del = function (obj, prop) {
        obj2 = obj
        obj = {}
        for (i in obj2) {
            if (i != prop) {
                obj[i] = obj2[i]
            }
        }
        return obj;
    }

    external.hasAttribute = function (input, name) {
        if (input.length) {
            return input[0].attributes[name] !== undefined;
        }
        return false;
    },

    external.patternMatcher = function (value, pattern) {
        if (typeof pattern === "string") {
            pattern = new RegExp(pattern);
        }
        return pattern.test(value);
    }

    external.validationrules = {
        messages: {
            required2: Global.ValidationStrings.RequiredErrorMessage,
            min2: Global.ValidationStrings.MinErrorMessage,
            requiredif: Global.ValidationStrings.RequiredIfErrorMessage,
            pattern2: Global.ValidationStrings.PatternErrorMessage
        },

        rules: {
            required2: function (input) {
                var checkbox = input.filter("[type=checkbox]").length && input.attr("checked") !== "checked",
                    value = input.val();

                return !((common.hasAttribute(input, "data-val-required")) && (value === "" || !value || checkbox));
            },
            min2: function (input) {
                if (common.hasAttribute(input, "data-val-range-min")) {
                    var min = parseFloat(input.attr("min")) || 0,
                        val = parseFloat(input.val()) || (min - 1);

                    return min <= val;
                }
                return true;
            },
            requiredif: function (input) {
                if (common.hasAttribute(input, "data-val-requiredif")) {
                    var name = $(input).attr("data-val-requiredif-dependentproperty");
                    var val = $(input).attr("data-val-requiredif-targetvalue");
                    var dep = $('input[name=' + name + ']');

                    var currentVal;
                    if (dep.attr("type") == "radio") {
                        currentVal = $('input[name=' + name + ']:checked').val();
                    }
                    else {
                        currentVal = $('#' + name).val();
                    }

                    if (val == currentVal) {
                        var checkbox = input.filter("[type=checkbox]").length && input.attr("checked") !== "checked";
                        var value = input.val();

                        return !(value === "" || !value || checkbox);
                    }

                    return true;
                }

                return true;
            },
            pattern2: function (input) {
                if (common.hasAttribute(input, "data-val-regex-pattern")) {
                    return common.patternMatcher(input.val(), input.attr("data-val-regex-pattern"));
                }
                return true;
            }
        },

        validateOnBlur: true
    }

    external.confirm = function (
        options) {
        if (options == null) {
            options = {};
        }

        var kendoWindow = $("<div />").kendoWindow({
            title: options.title ? options.title : Global.ConfirmStrings.Title,
            resizable: false,
            modal: true,
            width: 300,
            actions: {},
            animation: false
        });

        kendoWindow.data("kendoWindow")
            .content('<p class="delete-message">' + (options.text ? options.text : Global.ConfirmStrings.Message) + '</p>' +
                '<button class="delete-confirm k-button">' + Global.ConfirmStrings.YesButtonText + '</button> ' +
                '<button class="delete-cancel k-button">' + Global.ConfirmStrings.NoButtonText + '</button>')
            .center().open();

        kendoWindow
            .find(".delete-confirm")
                .click(function () {
                    if (options.okCallback) {
                        options.okCallback();
                    }

                    kendoWindow.data("kendoWindow").close();
                })
                .end();

        kendoWindow
            .find(".delete-cancel")
                .click(function () {
                    kendoWindow.data("kendoWindow").close();
                })
                .end();
    }

    return external;
}(common || {}));

String.prototype.hashCode = function () {
    for (var ret = 0, i = 0, len = this.length; i < len; i++) {
        ret = (31 * ret + this.charCodeAt(i)) << 0;
    }
    return ret;
};

String.prototype.endsWith = function (pattern) {
    var d = this.length - pattern.length;
    return d >= 0 && this.lastIndexOf(pattern) === d;
};

if (jQuery.type(common.Enums) == "undefined") {
    common.Enums = (function () {
        return {
            CrudType: {
                Add: { Id: 1, Name: "Add" },
                Edit: { Id: 2, Name: "Edit" },
                Delete: { Id: 3, Name: "Delete" },
                Read: { Id: 4, Name: "Read" }
            }
        }
    })();
}

if (jQuery.type(QP) == "undefined") {
    var QP = {

    };
}

if (jQuery.type(QP.Data) == "undefined") {
    QP.Data = (function () {
        return {
            loadDiscriminators: function (form, isPage) {
                common.showProgress();

                var dataSource = QP.Data.createDataSource(
                    MvcJs.Dictionary.AjaxDiscriminators(),
                    function (options, operation) {
                        if (operation === "read") {
                            return {
                                ParentId: form.find("#ParentId").val(),
                                IsPage: isPage
                            };
                        }
                        return options;
                    },
                    function (data) {
                        return data.List;
                    });

                form.find("#DiscriminatorId").removeAttr("value");
                form.find("#DiscriminatorId").kendoComboBox({
                    dataTextField: "Title",
                    dataValueField: "Id",
                    dataSource: dataSource
                });
            },

            createDataSource: function (url, parameterMap, dataMap, serverFiltering, totalMap, pageSize, sort) {
                var read = {
                    url: url,
                    type: "POST",
                    contentType: "application/json"
                };

                var transport = parameterMap == null ? {
                    read: read
                } : {
                    read: read,
                    parameterMap: parameterMap
                };

                var dataSource;
                if (totalMap != null & pageSize != null) {
                    dataSource = new kendo.data.DataSource({
                        transport: transport,
                        serverFiltering: serverFiltering == null ? false : serverFiltering,
                        schema: {
                            data: function (data) {
                                if (ajax.showError(data)) {
                                    return;
                                }

                                common.hideProgress();

                                return dataMap(data);
                            },
                            errors: ajax.defaultError,
                            total: totalMap == null ? undefined : totalMap
                        },
                        pageSize: pageSize,
                        serverPaging: pageSize != null,
                        sort: sort == null ? { } : sort
                    });
                }
                else {
                    dataSource = new kendo.data.DataSource({
                        transport: transport,
                        serverFiltering: serverFiltering == null ? false : serverFiltering,
                        schema: {
                            data: function (data) {
                                if (ajax.showError(data)) {
                                    return;
                                }

                                common.hideProgress();

                                return dataMap(data);
                            },
                            errors: ajax.defaultError
                        },
                        sort: sort == null ? {} : sort
                    });
                }

                return dataSource;
            }
        }
    })();
}

if (jQuery.type(QP.Client) == "undefined") {
    function getParent() {
        if (window.parent == null) {
            alert(Global.ErrorMessages.LogicErrorMessage);
            return;
        }

        return window.parent;
    }

    QP.Client = (function () {
        return {
          hostId: function () {
            return $(window.document).find("#QpHostId").val();
          },

          customerCode: function () {
            return $(window.document).find("#CustomerCode").val();
          },

          backendSid: function () {
            return $(window.document).find("#BackendSid").val();
          },

          siteId: function () {
            return $(window.document).find("#SiteId").val();
          },

          showRegionsSelector: function (id, callback, isMultiple) {
            ajax.post(MvcJs.SiteMap.AjaxItemRegionIds(), {
              Data: id,
            }, function (result) {
              if (ajax.showError(result)) {
                return;
              }

              var observer = QP.Utils.initNew(siteMap.common.addCode, callback);
              var options = QP.Utils.initSelectOptions(!!isMultiple, QpContents.QPRegion.Id, common.GUID(), result.Data, observer);

              if (jQuery.type(result.Data) == 'array' && result.Data.length == 1) {
                if (jQuery.type(callback) == 'function') {
                    callback(Quantumart.QP8.Interaction.BackendEventObserver.EventType.EntitiesSelected, {
                    selectedEntityIDs: result.Data
                  });
                }
              }

              if (jQuery.type(result.Data) == 'array' && result.Data.length > 0) {
                QP.Utils.setFilter(options, jQuery.validator.format('c.Archive = 0 and c.content_item_id in ({0})',result.Data.join(',')));
              }

              QP.Utils.executeSelectWindow(options, QP.Utils.hostId());
              common.hideProgress();
            });
          },

          showCulturesSelector: function (id, callback, isMultiple) {
            ajax.post(MvcJs.SiteMap.AjaxItemCultureIds(), {
              Data: id,
            }, function (result) {
              if (ajax.showError(result)) {
                return;
              }

            var observer = QP.Utils.initNew(siteMap.common.addCode, callback);
            var options = QP.Utils.initSelectOptions(!!isMultiple, QpContents.QPCulture.Id, common.GUID(), result.Data, observer);

            if (jQuery.type(result.Data) === 'array' && result.Data.length === 1) {
              if (jQuery.type(callback) === 'function') {
                callback(Quantumart.QP8.Interaction.BackendEventObserver.EventType.EntitiesSelected, {
                  selectedEntityIDs: result.Data
                });

              common.hideProgress();
              return;
            }
          }

          if (jQuery.type(result.Data) === 'array' && result.Data.length > 0) {
            QP.Utils.setFilter(options, jQuery.validator.format('c.Archive = 0 and c.content_item_id in ({0})', result.Data.join(",")));
          }

          QP.Utils.executeSelectWindow(options, QP.Utils.hostId());
          common.hideProgress();
        });
      }
    }
  })();
}

var Observer = (function () {
  function Observer() { }
  Observer.listeners = {};
  Observer.addListener = function addListener(object, evt, callback) {
    if (!Observer.listeners.hasOwnProperty(evt)) {
      Observer.listeners[evt] = [];
    }

    Observer.listeners[evt].push(object[callback]);
  };

  Observer.removeListener = function removeListener(object, evt, callback) {
    if (Observer.listeners.hasOwnProperty(evt)) {
      var i, length;
      for (i = 0, length = Observer.listeners[evt].length; i < length; i += 1) {
        if (Observer.listeners[evt][i] === object[callback]) {
          Observer.listeners[evt].splice(i, 1);
        }
      }
    }
  };

  Observer.triggerEvent = function triggerEvent(evt, args) {
    if (Observer.listeners.hasOwnProperty(evt)) {
      var i, length;
      for (i = 0, length = this.listeners[evt].length; i < length; i += 1) {
        if (jQuery.type(this.listeners[evt][i]) == "function") {
          this.listeners[evt][i](args);
        }
      }
    }
  };

  return Observer;
})();

$.ajaxPrefilter(function (options, originalOptions, jqXHR) {
    var hostId = QP.Client.hostId();
    var customerCode = QP.Client.customerCode();
    var backendSid = QP.Client.backendSid();
    var siteId = QP.Client.siteId();
    var data = {};

    if (jQuery.type(originalOptions.data) === "undefined") {
      options.data = "";
    } else if (originalOptions.data !== null & originalOptions.data !== '' & jQuery.type(originalOptions.data) === "string") {
      data = JSON.parse(originalOptions.data);
    } else if (originalOptions.data !== null & originalOptions.data !== '' & jQuery.type(originalOptions.data) === "object") {
      data = originalOptions.data;
    }

    data["HostId"] = hostId;
    data["CustomerCode"] = customerCode;
    data["BackendSid"] = backendSid;
    data["SiteId"] = siteId;

    if (originalOptions.type === "GET" || originalOptions.type === "get") {
      options.data = $.param(data);
      originalOptions.data = $.param(data);
    } else {
      options.data = JSON.stringify(data);
      originalOptions.data = JSON.stringify(data);
    }
});
