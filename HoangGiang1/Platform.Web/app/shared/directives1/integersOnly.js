(function (app) {
    'use strict';

    app.directive('integersOnly', integersOnly);

    function integersOnly() {
        return {
            restrict: 'A',
            require: 'ngModel',
            scope: {
                min: '=',
                max: '='
            },
            link: function (scope, element, attrs, modelCtrl) {
                function isInvalid(value) {
                    return (value === null || typeof value === 'undefined' || !value.length);
                }

                function replace(value) {
                    if (isInvalid(value)) {
                        return null;
                    }

                    var newValue = [];
                    var chrs = value.split('');
                    var allowedChars = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-'];

                    for (var index = 0; index < chrs.length; index++) {
                        if (_.contains(allowedChars, chrs[index])) {
                            if (index > 0 && chrs[index] === '-') {
                                break;
                            }
                            newValue.push(chrs[index]);
                        }
                    }

                    return newValue.join('') || null;
                }

                modelCtrl.$parsers.push(function (value) {
                    var originalValue = value;

                    value = replace(value);

                    if (value !== originalValue) {
                        modelCtrl.$setViewValue(value);
                        modelCtrl.$render();
                    }

                    return value && isFinite(value) ? parseInt(value) : value;
                });

                modelCtrl.$formatters.push(function (value) {
                    if (value === null || typeof value === 'undefined') {
                        return null;
                    }

                    return parseInt(value);
                });
                modelCtrl.$validators.min = function (modelValue) {
                    if (scope.min !== null && modelValue !== null && modelValue < scope.min) { return false; }
                    return true;
                };
                modelCtrl.$validators.max = function (modelValue) {
                    if (scope.max !== null && modelValue !== null && modelValue > scope.max) { return false; }
                    return true;
                };
                modelCtrl.$validators.hasOnlyChar = function (modelValue) {
                    if (!isInvalid(modelValue) && modelValue === '-') { return false; }
                    return true;
                };
            }
        };
    }
})(angular.module('platformTH_GV.common'));