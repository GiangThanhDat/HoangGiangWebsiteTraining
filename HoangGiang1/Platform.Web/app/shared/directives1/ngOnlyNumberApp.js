function countDecimalPlaces(value) {
    var decimalPos = String(value).indexOf('.');
    if (decimalPos === -1) {
        return 0;
    } else {
        return String(value).length - decimalPos - 1;
    }
}
(function (app) {
    'use strict';

    app.directive('sbPrecision', sbPrecision);
    app.directive('sbMin', sbMin);
    app.directive('sbMax', sbMax);
    app.directive('sbNumber', sbNumber);
    app.directive('sbMaxPrecision', sbMaxPrecision);

    function sbPrecision() {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attributes, ngModel) {
                var precision = attributes.sbPrecision;

                function setPrecision() {
                    var value = ngModel.$modelValue;

                    //since this is just a mask, don't hide decimal values that
                    //go beyond our precision and don't format empty values
                    if (value && !isNaN(value) && countDecimalPlaces(value) <= precision) {
                        var formatted = Number(value).toFixed(precision);
                        ngModel.$viewValue = formatted;
                        ngModel.$render();
                    }
                }

                element.bind('blur', setPrecision);
                setTimeout(setPrecision, 0); //after initial page render
            }

        };
    }
    function sbMin() {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attributes, ngModel) {

                function minimum(value) {
                    if (!isNaN(value)) {
                        var validity = Number(value) >= attributes.sbMin;
                        ngModel.$setValidity('min-value', validity)
                    }
                    return value;
                }

                ngModel.$parsers.push(minimum);
                ngModel.$formatters.push(minimum);
            }

        };
    }
    function sbMax() {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attributes, ngModel) {


                function maximum(value) {
                    if (!isNaN(value)) {
                        var validity = Number(value) <= attributes.sbMax;
                        ngModel.$setValidity('max-value', validity);
                    }

                    return value;
                }

                ngModel.$parsers.push(maximum);
                ngModel.$formatters.push(maximum);
            }

        };
    }
    function sbNumber() {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attributes, ngModel) {


                function validateNumber(value) {
                    var validity = !isNaN(value);
                    ngModel.$setValidity('number', validity)
                    return value;
                }

                ngModel.$parsers.push(validateNumber);
                ngModel.$formatters.push(validateNumber);
            }

        };
    }
    function sbMaxPrecision() {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attributes, ngModel) {

                function maxPrecision(value) {
                    if (!isNaN(value)) {
                        var validity = countDecimalPlaces(value) <= attributes.sbMaxPrecision;
                        ngModel.$setValidity('max-precision', validity);
                    }

                    return value;
                }

                ngModel.$parsers.push(maxPrecision);
                ngModel.$formatters.push(maxPrecision);
            }

        };
    }


})(angular.module('platformTH_GV.common'));