/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlyhanghoa', ['platformTH_GV.common']).config(config);
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlyhanghoa', {
            url: "/quanlyhanghoa",
            templateUrl: "/app/conponents/quanlyhanghoa/quanLyHangHoaView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyHangHoaController"
        })
            
    }
})();