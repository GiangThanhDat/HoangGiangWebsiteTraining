/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.thongkehanghoa', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('thongkehanghoa', {
            url: "/thongkehanghoa",
            templateUrl: "/app/conponents/thongkehanghoa/ThongKeHangHoaView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeHangHoaController"
        }).state('thietlapgia', {
            url: "/thietlapgia",
            templateUrl: "/app/conponents/thongkehanghoa/ThietLapGiaView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThietLapGiaController"
        })
    }
})();