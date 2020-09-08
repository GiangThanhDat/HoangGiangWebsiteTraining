/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.kho', ['platformTH_GV.common', 'ngTouch']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('nhapkho', {
            url: "/nhapkho",
            templateUrl: "/app/conponents/kho/NhapKhoView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "NhapKhoController"
        })
       .state('xuatkho', {
           url: "/xuatkho",
            templateUrl: "/app/conponents/kho/XuatKhoView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "XuatKhoController"
        })
       .state('lenhsanxuat', {
           url: "/lenhsanxuat",
            templateUrl: "/app/conponents/kho/LenhSanXuatView.html?v=" + window.appVersion,
            parent: 'base',
           controller: "LenhSanXuatController"
        })
        $stateProvider.state('thongkenhapxuatkho', {
            url: "/thongkenhapxuatkho",
            templateUrl: "/app/conponents/kho/ThongKeXuatNhapKhoView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeXuatNhapKhoController"
        })
        $stateProvider.state('thongkechuyenkho', {
            url: "/thongkechuyenkho",
            templateUrl: "/app/conponents/kho/ThongKeChuyenKhoView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeChuyenKhoController"
        })
        $stateProvider.state('thongkelenhsanxuat', {
            url: "/thongkelenhsanxuat",
            templateUrl: "/app/conponents/kho/ThongKeLenhSanXuatView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeLenhSanXuatController"
        })
        $stateProvider.state('thongkelaprapthaodo', {
            url: "/thongkelaprapthaodo",
            templateUrl: "/app/conponents/kho/ThongKeLapRapThaoDoView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeLapRapThaoDoController"
        })
         $stateProvider.state('laprapthaodo', {
             url: "/laprapthaodo",
             templateUrl: "/app/conponents/kho/LapRapThaoDoView.html?v=" + window.appVersion,
            parent: 'base',
             controller: "LapRapThaoDoController"
        })
        

    }
})();