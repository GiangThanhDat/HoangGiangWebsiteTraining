/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.thongke', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('thongke', {
            url: "/thongke",
            templateUrl: "/app/conponents/thongke/thongKeView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "thongKeController"
        })
            
    }
})();