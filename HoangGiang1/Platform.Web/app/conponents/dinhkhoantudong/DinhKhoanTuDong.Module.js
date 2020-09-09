/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.dinhkhoantudong', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('dinhkhoantudong', {
            url: "/dinhkhoantudong",
            templateUrl: "/app/conponents/dinhkhoantudong/DinhKhoanTudongView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "DinhKhoanTuDongController"
        })
    }
})();