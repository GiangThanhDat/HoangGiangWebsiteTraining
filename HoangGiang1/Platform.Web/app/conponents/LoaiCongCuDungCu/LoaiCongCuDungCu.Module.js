/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.loaicongcudungcu', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('loaicongcudungcu', {
            url: "/loaicongcudungcu",
            templateUrl: "/app/conponents/LoaiCongCuDungCu/LoaiCongCuDungCuView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "LoaiCongCuDungCuController"
        })
    }
})();