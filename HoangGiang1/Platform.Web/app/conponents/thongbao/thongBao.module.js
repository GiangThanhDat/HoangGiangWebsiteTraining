/// <reference path="../../../assets/giaovien/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.thongbao', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('thongbao', {
            url: "/thongbao/:MaSoTB",
            parent: 'base',
            templateUrl: "app/conponents/thongbao/thongBaoView.html?v=" + window.appVersion,
            controller: "thongBaoController"
        });

    }
})();