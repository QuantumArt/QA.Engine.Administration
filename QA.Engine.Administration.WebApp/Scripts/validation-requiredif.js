/// <reference path="jquery-1.4.1-vsdoc.js" />
/// <reference path="jquery.validate-vsdoc.js" />
/// <reference path="MicrosoftMvcAjax.debug.js" />
/// <reference path="MicrosoftMvcValidation.debug.js" />

// jQuery version of required-if validation, if that framework is loaded
if (typeof (jQuery) !== "undefined" && typeof (jQuery.validator) !== "undefined") {

    (function ($) {
        $.validator.addMethod('requiredif', function (value, element, parameters) {
            //TODO: smart selector
            var id = '#' + parameters['dependentproperty'];

            // get the target value (as a string, as that's what actual value will be)
            var targetvalue = parameters['targetvalue'];
            targetvalue = (targetvalue == null ? '' : targetvalue).toString();

            // get the actual value of the target control
            var actualvalue = $(id).val();

            // if the condition is true, reuse the existing required field validator functionality
            if (targetvalue != actualvalue)
                return $.validator.methods.required.call(this, value, element, parameters);

            return true;
        });

    })(jQuery);

}

// Microsoft version of required-if validation, if that framework is loaded
if (typeof (Sys) !== "undefined" && typeof (Sys.Mvc) !== "undefined" && typeof (Sys.Mvc.ValidatorRegistry) !== "undefined") {

    (function () {

        Type.registerNamespace('CustomValidation');
        CustomValidation.RequiredIfValidator = function RequiredIfValidator(dependentProperty, targetvalue) {
            // store the id of the property to check
            this._dependentProperty = dependentProperty;
            // store the target value (as a string, as that's what actual value will be)
            this._targetValue = (targetvalue == null ? '' : targetvalue).toString();
        }
        CustomValidation.RequiredIfValidator.create = function create(rule) {
            // function to create a new validator from the rule parameters
            var dependentProperty = rule.ValidationParameters['dependentproperty'];
            var targetvalue = rule.ValidationParameters['targetvalue'];
            var instance = new CustomValidation.RequiredIfValidator(dependentProperty, targetvalue);
            return Function.createDelegate(instance, instance.validate);
        }
        CustomValidation.RequiredIfValidator.prototype = {
            _dependentProperty: null,
            _targetValue: null,

            validate: function validate(value, context) {
                // get the current value of the control to check
                var actual = Sys.UI.DomElement.getElementById(this._dependentProperty);
                // note: next line isn't perfect; i.e. won't work for check box lists etc
                var actualvalue = actual.value;

                if (actualvalue != this._targetValue) {
                    // if the condition holds true, reuse the existing required validator
                    var validatorinstance = Sys.Mvc.ValidatorRegistry.validators.required();
                    return validatorinstance(value, context);
                }
                else
                    return true;
            }
        }

        CustomValidation.RequiredIfValidator.registerClass('CustomValidation.RequiredIfValidator');

        var validators = Sys.Mvc.ValidatorRegistry.validators;
        validators["requiredif"] = Function.createDelegate(null, CustomValidation.RequiredIfValidator.create);
    })();
}
