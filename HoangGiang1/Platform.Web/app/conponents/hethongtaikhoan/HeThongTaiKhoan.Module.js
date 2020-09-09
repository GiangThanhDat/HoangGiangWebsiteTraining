/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.hethongtaikhoan', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('hethongtaikhoan', {
            url: "/hethongtaikhoan",
            templateUrl: "/app/conponents/hethongtaikhoan/HeThongTaiKhoanView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "HeThongTaiKhoanController"
        })
    }
})();