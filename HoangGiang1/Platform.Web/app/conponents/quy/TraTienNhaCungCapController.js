(function (app) {
    'use strict';

    app.controller('ThongTinTongHopController', ThongTinTongHopController);

    ThongTinTongHopController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', 'dateFilter'];
    function ThongTinTongHopController($scope, apiService, notificationService, $ngBootbox, $filter, dateFilter) {

    }
})(angular.module('platformTH_GV.quy'));