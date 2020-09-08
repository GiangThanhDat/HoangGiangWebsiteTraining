(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'Kích hoạt';
            else
                return 'Khóa';
        }
    });
    app.filter('Loc', function () {
        return function (input) {
            if (input == true)
                return 'Có';
            else
                return 'Không';
        }
    });
	app.filter('total', function () {
		return function (input, property) {
			var i = input instanceof Array ? input.length : 0;
			if (typeof property === 'undefined' || i === 0) {
				return i;
			} else if (isNaN(input[0][property])) {
				throw 'filter total can count only numeric values';
			} else {
				var total = 0;
				while (i--)
					total += input[i][property];
				return total;
			}
		};
	});
	app.filter('numkeys', function () {
		return function (object) {
			return Object.keys(object).length;
		}
	});
    app.filter('unique', function () {

        return function (items, filterOn) {

            if (filterOn === false) {
                return items;
            }

            if ((filterOn || angular.isUndefined(filterOn)) && angular.isArray(items)) {
                var hashCheck = {}, newItems = [];

                var extractValueToCompare = function (item) {
                    if (angular.isObject(item) && angular.isString(filterOn)) {
                        return item[filterOn];
                    } else {
                        return item;
                    }
                };

                angular.forEach(items, function (item) {
                    var valueToCheck, isDuplicate = false;

                    for (var i = 0; i < newItems.length; i++) {
                        if (angular.equals(extractValueToCompare(newItems[i]), extractValueToCompare(item))) {
                            isDuplicate = true;
                            break;
                        }
                    }
                    if (!isDuplicate) {
                        newItems.push(item);
                    }

                });
                items = newItems;
            }
            return items;
        };
    });

  
})(angular.module('platformTH_GV.common'));