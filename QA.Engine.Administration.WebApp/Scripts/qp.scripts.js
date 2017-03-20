if (jQuery.type(QP) == "undefined") {
    var QP = {

    };
}

if (jQuery.type(QP.Utils) == "undefined") {

    QP.Utils = (function () {
        function getParent() {
            if (window.parent == null) {
                alert(Global.ErrorMessages.LogicErrorMessage);
                return;
            }

            return window.parent;
        }

        return {
            initNew: function (name, callback) {
                return new Quantumart.QP8.Interaction.BackendEventObserver(name, callback);
            },

            initOptions: function (action, type, itemId, entityId, actionId, observer) {
                var executeOptions = new Quantumart.QP8.Interaction.ExecuteActionOtions();
                executeOptions.actionCode = action;
                executeOptions.entityTypeCode = type;
                executeOptions.entityId = itemId;
                executeOptions.parentEntityId = entityId;
                executeOptions.actionUID = actionId;
                executeOptions.callerCallback = observer.callbackProcName;

                return executeOptions;
            },

            initSelectOptions: function (isMultiple, entityId, actionId, selectedEntityIDs, observer) {
                var executeOptions = {};
                executeOptions.selectActionCode = isMultiple ? QpActionCodes.multiple_select_article : QpActionCodes.select_article;
                executeOptions.entityTypeCode = QpEntityCodes.article;
                executeOptions.isMultiple = isMultiple == true ? true : false,
                executeOptions.parentEntityId = entityId;
                executeOptions.selectWindowUID = actionId;
                executeOptions.callerCallback = observer.callbackProcName;
                executeOptions.selectedEntityIDs = selectedEntityIDs;

                return executeOptions;
            },

            setFieldValues: function (executeOptions, values) {
                if (executeOptions.options == null) {
                    executeOptions.options = new Quantumart.QP8.Interaction.ArticleFormState();
                }

                executeOptions.options.initFieldValues = values;
            },

            setDisabledFields: function (executeOptions, values) {
                if (executeOptions.options == null) {
                    executeOptions.options = new Quantumart.QP8.Interaction.ArticleFormState();
                }

                executeOptions.options.disabledFields = values;
            },

            setDisabledButtons: function (executeOptions, values) {
                if (executeOptions.options == null) {
                    executeOptions.options = new Quantumart.QP8.Interaction.ArticleFormState();
                }

                executeOptions.options.disabledActionCodes = values;
            },

            setHideFields: function (executeOptions, values) {
                if (executeOptions.options == null) {
                    executeOptions.options = new Quantumart.QP8.Interaction.ArticleFormState();
                }

                executeOptions.options.hideFields = values;
            },

            setAdditionalParams: function (executeOptions, values) {
                if (executeOptions.options == null) {
                    executeOptions.options = new Quantumart.QP8.Interaction.ArticleFormState();
                }

                executeOptions.options.additionalParams = values;
            },

            setFilter: function (executeOptions, value) {
                if (executeOptions.options == null) {
                    executeOptions.options = new Quantumart.QP8.Interaction.ArticleFormState();
                }

                executeOptions.options.filter = value;
            },

            executeWindow: function (options, hostId) {
                var backendWnd = getParent();

                options.isWindow = true;
                options.changeCurrentTab = false;

                Quantumart.QP8.Interaction.executeBackendAction(options, hostId, backendWnd);
            },

            executeTab: function (options, id) {
                var backendWnd = getParent();

                options.isWindow = false;
                options.changeCurrentTab = false;

                Quantumart.QP8.Interaction.executeBackendAction(options, id, backendWnd);
            },

            executeSelectWindow: function (options, id) {
                var backendWnd = getParent();

                Quantumart.QP8.Interaction.openSelectWindow(options, id, backendWnd);
            },

            close: function (action, id) {
                var backendWnd = getParent();
                Quantumart.QP8.Interaction.closeBackendHost(action, id, backendWnd);
            },

            hostId: function () {
                return $("#QpHostId").val();
            }
        }
    })();
}
