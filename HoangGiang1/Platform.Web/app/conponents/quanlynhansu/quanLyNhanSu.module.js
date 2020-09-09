/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlynhansu', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlynhansu', {
            url: "/quanlynhansu",
            templateUrl: "/app/conponents/quanlynhansu/quanLyNhanSuView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyNhanSuController"
        }).state('themnhanvienmoi', {
            url: "/themnhanvienmoi",
            templateUrl: "/app/conponents/quanlynhansu/themNhanVienMoiView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "themNhanVienMoiController"
        }).state('quanlycongtacadmin', {
            url: "/quanlycongtacadmin",
            templateUrl: "/app/conponents/quanlynhansu/quanLyCongTacAdminView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyCongTacAdminController"
        }).state('quanlyngaynghiadmin', {
            url: "/quanlyngaynghiadmin",
            templateUrl: "/app/conponents/quanlynhansu/quanLyNgayNghiAdminView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyNgayNghiAdminController"
        }).state('quanlythe', {
            url: "/quanlythe",
            templateUrl: "/app/conponents/quanlynhansu/QuanLyTheView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "QuanLyTheController"
        });      
    }
})();