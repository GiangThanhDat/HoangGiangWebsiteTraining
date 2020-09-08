/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.cocautochuc', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('cocautochuc', {
            url: "/cocautochuc",
            templateUrl: "/app/conponents/cocautochuc/CoCauToChucView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "CoCauToChucController"
        })
    }
})();