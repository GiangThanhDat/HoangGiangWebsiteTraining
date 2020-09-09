/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlyquytien', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlyquytien', {
            url: "/quanlyquytien",
            templateUrl: "/app/conponents/quanlyquytien/quanLyQuyTienView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyQuyTienController"
                })
                .state('themphieuthu', {
            url: "/themphieuthu",
            templateUrl: "/app/conponents/quanlyquytien/themPhieuThuView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "themPhieuThuController"
        }).state('themphieuchi', {
            url: "/themphieuchi",
            templateUrl: "/app/conponents/quanlyquytien/themPhieuChiView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "themPhieuChiController"
        })
            
    }
})();