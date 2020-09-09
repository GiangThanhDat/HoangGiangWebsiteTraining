/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlyvangmat', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlyvangmat', {
            url: "/quanlyvangmat",
            templateUrl: "/app/conponents/quanlyvangmat/quanLyVangMatView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyVangMatController"
        })
            
    }
})();