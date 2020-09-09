/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.doituong', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('khachhang', {
            url: "/khachhang",
            templateUrl: "/app/conponents/doituong/KhachhangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "KhachhangController"
        })
        .state('nhomkh_ncc', {
            url: "/nhomkh_ncc",
            templateUrl: "/app/conponents/doituong/NhomKH_NCCView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "NhomKH_NCCController"
        }).state('nhacungcap', {
            url: "/nhacungcap",
            templateUrl: "/app/conponents/doituong/NhaCungCapView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "NhaCungCapController"
        }).state('nhanvien', {
            url: "/nhanvien",
            templateUrl: "/app/conponents/doituong/NhanVienView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "NhanVienController"
        })
        
            
    }
})();