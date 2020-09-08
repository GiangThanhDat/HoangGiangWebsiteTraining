﻿/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quanlycuahang', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quanlycuahang', {
            url: "/quanlycuahang",
            templateUrl: "/app/conponents/quanlycuahang/QuanLyCuaHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "QuanLyCuaHangController"
        })
            
    }
})();