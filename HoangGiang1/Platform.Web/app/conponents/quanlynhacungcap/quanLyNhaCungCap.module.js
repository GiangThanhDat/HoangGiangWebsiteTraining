/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlynhacungcap', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');


    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlynhacungcap', {
            url: "/quanlynhacungcap",
            templateUrl: "/app/conponents/quanlynhacungcap/quanLyNhaCungCapView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyNhaCungCapController"
        })

    }
})();