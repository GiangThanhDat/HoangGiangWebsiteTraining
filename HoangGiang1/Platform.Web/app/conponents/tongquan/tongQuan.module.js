/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.tongquan', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('tongquan', {
            url: "/tongquan",
            templateUrl: "/app/conponents/tongquan/tongQuanView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "tongQuanController"
        })
            
    }
})();