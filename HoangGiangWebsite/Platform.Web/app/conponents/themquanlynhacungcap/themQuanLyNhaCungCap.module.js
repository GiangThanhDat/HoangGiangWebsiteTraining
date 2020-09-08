/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.themquanlynhacungcap', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');


    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('themquanlynhacungcap', {
            url: "/themquanlynhacungcap",
            templateUrl: "/app/conponents/themquanlynhacungcap/themQuanLyNhaCungCapView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "themQuanLyNhaCungCapController"
        })

    }
})();