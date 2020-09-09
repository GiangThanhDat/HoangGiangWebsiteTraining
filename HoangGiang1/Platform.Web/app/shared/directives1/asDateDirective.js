(function (app) {
    'use strict';

    app.directive('asDate', asDate);
    app.directive('fixedTableHeaders', ['$timeout', function ($timeout) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                $timeout(function () {

                  var  container = element.parentsUntil(attrs.fixedTableHeaders);
                    element.stickyTableHeaders({ scrollableArea: container, "fixedOffset": 2 });

                }, 0);
            }
        }
    }]);
    function asDate() {
        return {
            require: '^ngModel',
            restrict: 'A',
            link: function (scope, element, attrs, ctrl) {
                ctrl.$formatters.splice(0, ctrl.$formatters.length);
                ctrl.$parsers.splice(0, ctrl.$parsers.length);
                ctrl.$formatters.push(function (modelValue) {
                    if (!modelValue) {
                        return;
                    }
                    return new Date(modelValue);
                });
                ctrl.$parsers.push(function (modelValue) {
                    return modelValue;
                });
            }
        };
    }
    app.directive('format', ['$filter', function ($filter) {
        return {
            require: '?ngModel',
            link: function (scope, elem, attrs, ctrl) {
                if (!ctrl) return;


                ctrl.$formatters.unshift(function (a) {
                    return $filter(attrs.format)(ctrl.$modelValue)
                });


                ctrl.$parsers.unshift(function (viewValue) {
                    var plainNumber = viewValue.replace(/[^\d|\-+|\.+]/g, '');
                    elem.val($filter(attrs.format)(plainNumber));
                    return plainNumber;
                });
            }
        };
    }]);

    app.directive('fixedColumnTable', fixedColumnTable);

    fixedColumnTable.$inject = ['$timeout'];
    function fixedColumnTable($timeout) {
        return {
            restrict: 'A',
            scope: {
                fixedColumns: "@"
            },
            link: function (scope, element) {
                var container = element[0];

                function activate() {
                    applyClasses('thead tr', 'cross', 'th');
                    applyClasses('tbody tr', 'fixed-cell', 'td');

                    var leftHeaders = [].concat.apply([], container.querySelectorAll('tbody td.fixed-cell'));
                    var topHeaders = [].concat.apply([], container.querySelectorAll('thead th'));
                    var crossHeaders = [].concat.apply([], container.querySelectorAll('thead th.cross'));

                    console.log('line before setting up event handler');

                    container.addEventListener('scroll', function () {
                        console.log('scroll event handler hit');
                        var x = container.scrollLeft;
                        var y = container.scrollTop;

                        //Update the left header positions when the container is scrolled
                        leftHeaders.forEach(function (leftHeader) {
                            leftHeader.style.transform = translate(x, 0);
                        });

                        //Update the top header positions when the container is scrolled
                        topHeaders.forEach(function (topHeader) {
                            topHeader.style.transform = translate(0, y);
                        });

                        //Update headers that are part of the header and the left column
                        crossHeaders.forEach(function (crossHeader) {
                            crossHeader.style.transform = translate(x, y);
                        });

                    });

                    function translate(x, y) {
                        return 'translate(' + x + 'px, ' + y + 'px)';
                    }

                    function applyClasses(selector, newClass, cell) {
                        var arrayItems = [].concat.apply([], container.querySelectorAll(selector));
                        var currentElement;
                        var colspan;

                        arrayItems.forEach(function (row, i) {
                            var numFixedColumns = scope.fixedColumns;
                            for (var j = 0; j < numFixedColumns; j++) {
                                currentElement = angular.element(row).find(cell)[j];
                                currentElement.classList.add(newClass);

                                if (currentElement.hasAttribute('colspan')) {
                                    colspan = currentElement.getAttribute('colspan');
                                    numFixedColumns -= (parseInt(colspan) - 1);
                                }
                            }
                        });
                    }
                }

                $timeout(function () {
                    activate();
                }, 0);

                scope.$on('refreshFixedColumns', function () {
                    $timeout(function () {
                        activate();
                        container.scrollLeft = 0;
                    }, 0);
                });
            }
        };
    }

    app.directive('loading', function () {
        return {
            restrict: 'E',
            replace: true,
            template: '<div class="loading"><img src="http://www.nasa.gov/multimedia/videogallery/ajax-loader.gif" width="20" height="20" />LOADING...</div>',
            link: function (scope, element, attr) {
                scope.$watch('loading', function (val) {
                    if (val)
                        $(element).show();
                    else
                        $(element).hide();
                });
            }
        }
    })
    
})(angular.module('platformTH_GV.common'));