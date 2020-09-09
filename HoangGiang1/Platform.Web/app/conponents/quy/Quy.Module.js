/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.quy', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('quy', {
            url: "/quy",
            templateUrl: "/app/conponents/quy/QuyView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "QuyController"
        }),
            $stateProvider.state('thongtintonghop', {
            url: "/thongtintonghop",
            templateUrl: "/app/conponents/quy/ThongTinTongHopView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongTinTongHopController"
        }),
             $stateProvider.state('thutien', {
                 url: "/thutien",
                 templateUrl: "/app/conponents/quy/ThuTienView.html?v=" + window.appVersion,
            parent: 'base',
                 controller: "ThuTienController"
        }),
             $stateProvider.state('thutienkhachhang', {
                 url: "/thutienkhachhang",
                 templateUrl: "/app/conponents/quy/ThuTienKhachHangView.html?v=" + window.appVersion,
            parent: 'base',
                 controller: "ThuTienKhachHangController"
        }),
             $stateProvider.state('thutienkhachhanghangloat', {
                 url: "/thutienkhachhanghangloat",
                 templateUrl: "/app/conponents/quy/ThuTienKhachHangHangLoatView.html?v=" + window.appVersion,
            parent: 'base',
                 controller: "ThuTienKhachHangHangLoatController"
        }),
            $stateProvider.state('chitien', {
                url: "/chitien",
                templateUrl: "/app/conponents/quy/ChiTienView.html?v=" + window.appVersion,
            parent: 'base',
                controller: "ChiTienController"
        }),
             $stateProvider.state('tratiennhacungcap', {
                 url: "/tratiennhacungcap",
                 templateUrl: "/app/conponents/quy/TraTienNhaCungCapView.html?v=" + window.appVersion,
            parent: 'base',
                 controller: "TraTienNhaCungCapController"
        }),
             $stateProvider.state('nopthue', {
                 url: "/nopthue",
                 templateUrl: "/app/conponents/quy/NopThueView.html?v=" + window.appVersion,
            parent: 'base',
                 controller: "NopThueController"
        }),
             $stateProvider.state('nopbaohiem', {
                 url: "/nopbaohiem",
                 templateUrl: "/app/conponents/quy/NopBaoHiemView.html?v=" + window.appVersion,
            parent: 'base',
                 controller: "NopBaoHiemController"
        }),
            $stateProvider.state('traluong', {
                url: "/traluong",
                templateUrl: "/app/conponents/quy/TraLuongView.html?v=" + window.appVersion,
            parent: 'base',
                controller: "TraLuongController"
        }),
            $stateProvider.state('kiemke', {
                url: "/kiemke",
                templateUrl: "/app/conponents/quy/KiemKeView.html?v=" + window.appVersion,
            parent: 'base',
                controller: "KiemKeController"
        })

    }
})();