/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlykho', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlykho', {
            url: "/quanlykho",
            templateUrl: "/app/conponents/quanlykho/quanLyKhoView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyKhoController"
        })
            
    }
})();