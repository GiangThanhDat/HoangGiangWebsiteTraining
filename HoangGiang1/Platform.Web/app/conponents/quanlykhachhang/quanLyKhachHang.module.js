/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlykhachhang', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlykhachhang', {
            url: "/quanlykhachhang",
            templateUrl: "/app/conponents/quanlykhachhang/quanLyKhachhangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyKhachhangController"
        })
         .state('themkhachhang', {
             url: "/themkhachhang",
            templateUrl: "/app/conponents/quanlykhachhang/themKhachHangView.html?v=" + window.appVersion,
            parent: 'base',
             controller: "themKhachHangController"
        })
            
    }
})();