/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlychiphiseo', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlychiphiseo', {
            url: "/quanlychiphiseo",
            templateUrl: "/app/conponents/quanlychiphiseo/quanLyChiPhiSeoView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "quanLyChiPhiSeoController"
        }).state('themcoso', {
            url: "/themcoso",
            templateUrl: "/app/conponents/quanlychiphiseo/themCoSo.html?v=" + window.appVersion,
            parent: 'base',
            controller: "themcosoController"
        })
    }
})();