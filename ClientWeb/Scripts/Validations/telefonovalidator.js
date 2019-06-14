$(function () {

    jQuery.validator.addMethod('telefonovalidator', function (value, element, params) {
        return false;
    }, '');

    jQuery.validator.unobtrusive.adapters.add('telefonovalidator', function (options) {
        options.rules['telefonovalidator'] = {};
        options.messages['telefonovalidator'] = options.message;
    });

}(jQuery));