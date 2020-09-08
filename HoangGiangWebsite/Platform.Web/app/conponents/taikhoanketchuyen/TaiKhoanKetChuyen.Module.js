/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.taikhoanketchuyen', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('taikhoanketchuyen', {
            url: "/taikhoanketchuyen",
            templateUrl: "/app/conponents/taikhoanketchuyen/TaiKhoanKetChuyenView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "TaiKhoanKetChuyenController"
        })
    }
})();