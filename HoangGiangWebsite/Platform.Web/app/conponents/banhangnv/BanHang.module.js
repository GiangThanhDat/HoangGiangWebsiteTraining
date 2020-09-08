/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.banhangnv', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('banhangnv', {
            url: "/banhangnv",
            templateUrl: "/app/conponents/banhangnv/BanHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "BanHangController"
        })
            
    }
})();