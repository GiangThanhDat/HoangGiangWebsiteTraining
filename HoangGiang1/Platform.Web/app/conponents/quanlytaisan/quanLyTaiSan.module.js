/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlytaisan', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlytaisan', {
            url: "/quanlytaisan",
            templateUrl: "/app/conponents/quanlytaisan/quanLyTaiSanView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyTaiSanController"
        }),
            $stateProvider.state('nhaptaisan', {
                url: "/nhaptaisan",
                templateUrl: "/app/conponents/quanlytaisan/nhapTaiSanView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "nhapTaiSanController"
        }),         
             $stateProvider.state('thongketaisan', {
                 url: "/thongketaisan",
                 templateUrl: "/app/conponents/quanlytaisan/thongKeTaiSanView.html?v=" + window.appVersion,
                  parent: 'base',
                 controller: "thongKeTaiSanController"
        })
            
    }
})();