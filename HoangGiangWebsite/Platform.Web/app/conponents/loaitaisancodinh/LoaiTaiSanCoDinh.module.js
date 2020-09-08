/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.loaitaisancodinh', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('loaitaisancodinh', {
            url: "/loaitaisancodinh",
            templateUrl: "/app/conponents/loaitaisancodinh/LoaiTaiSanCoDinhView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "LoaiTaiSanCoDinhController"
        })
            
    }
})();