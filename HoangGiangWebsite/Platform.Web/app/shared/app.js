/// <reference path="../../assets/giaovien/libs/angular/angular.js" />



(function () {
    angular.module('platformTH_GV',
        ['platformTH_GV.common',
            'platformTH_GV.thongbao',
            'ngSanitize',
            'platformTH_GV.quanlychiphiseo',
            'platformTH_GV.quanlyhanghoa',
            'platformTH_GV.quanlykhachhang',
            'platformTH_GV.quanlykho',
            'platformTH_GV.quanlynhansu',
            'platformTH_GV.quanlyquytien',
            'platformTH_GV.thongke',
            'platformTH_GV.thongtincanhan',
            'platformTH_GV.nopdon',
            'ui.bootstrap',
            "checklist-model",
            'ngMaterial',
            'ngMessages',
            'platformTH_GV.application_users',
            'platformTH_GV.application_roles',
            'platformTH_GV.application_groups',
            'platformTH_GV.quanlyvangmat',
            'platformTH_GV.quanlytaisan',
            'platformTH_GV.themquanlynhacungcap',
            'platformTH_GV.quanlynhacungcap',
            'platformTH_GV.xemthongtinnhanvien',
            'platformTH_GV.quy',
            'platformTH_GV.muahang',
            'ngTouch', 'ui.grid', 'ui.grid.pinning', 'ui.grid.resizeColumns',
            'platformTH_GV.banhang',
            'platformTH_GV.doituong',
            'platformTH_GV.kho',
            'platformTH_GV.cocautochuc',
            'platformTH_GV.banhangnv',
            'platformTH_GV.quanlycuahang',
            'platformTH_GV.loaitaisancodinh',
            'platformTH_GV.loaicongcudungcu',
            'platformTH_GV.hethongtaikhoan',
            'platformTH_GV.taikhoanketchuyen',
            'platformTH_GV.dinhkhoantudong',
            'platformTH_GV.thongkehanghoa',
            , 'ngKeypad',
            'platformTH_GV.tongquan'
        ])

        .config(config)
        .config(configAuthentication);
        

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('base', {
            url: '',
            templateUrl: '/app/shared/views/baseView.html?v=' + window.appVersion,
            abstract: true
        }).state('dangnhap', {
            url: "/dangnhap",
            templateUrl: "app/conponents/dangnhap/dangNhapView.html?v=" + window.appVersion,
            controller: "dangNhapController"
        }).state('trangchu', {
            url: "/trangchu",
            parent: 'base',
            templateUrl: "app/conponents/trangchu/trangChuView.html?v=" + window.appVersion,
            controller: "trangChuController"
        });
        $urlRouterProvider.otherwise('/dangnhap');

    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/dangnhap');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status == "401") {
                        $location.path('/dangnhap');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();