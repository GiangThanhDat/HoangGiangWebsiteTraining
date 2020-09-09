/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.xemthongtinnhanvien', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('xemthongtinnhanvien', {
            url: "/xemthongtinnhanvien",
            templateUrl: "/app/conponents/xemthongtinnhanvien/xemThongTinNhanVienView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "xemThongTinNhanVienController"
        })
            

            
    }
})();