/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.banhang', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('baogia', {
            url: "/baogia",
            templateUrl: "/app/conponents/banhang/BaoGiaView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "BaoGiaController"
        })
        .state('dondathang', {
            url: "/dondathang",
            templateUrl: "/app/conponents/banhang/DonDatHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "DonDatHangController"
        })
        .state('chungtubanhang', {
            url: "/chungtubanhang",
            templateUrl: "/app/conponents/banhang/ChungTuBanHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ChungTuBanHangController"
        }).state('thongkebanhang', {
            url: "/thongkebanhang",
            templateUrl: "/app/conponents/banhang/ThongKeBanHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeBanHangController"
        })
           .state('thongkedondathang', {
                url: "/thongkedondathang",
                templateUrl: "/app/conponents/banhang/ThongKeDonDatHangView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "ThongKeDonDatHangController"
            })
            .state('thongkegiamgiabanhang', {
                url: "/thongkegiamgiabanhang",
                templateUrl: "/app/conponents/banhang/ThongKeGiamGiaHangBanView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "ThongKeGiamGiaHangBanController"
            })
            .state('thongketralaihangban', {
                url: "/thongketralaihangban",
                templateUrl: "/app/conponents/banhang/ThongKeTraLaiHangBanView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "ThongkeTraLaiHangBanController"
            })
            .state('thongkexuathoadon', {
                url: "/thongkexuathoadon",
                templateUrl: "/app/conponents/banhang/ThongKeXuatHoaDonView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "ThongKeXuatHoaDonController"
            }).state('banhang', {
                url: "/banhang",
                templateUrl: "/app/conponents/banhang/BanHangView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "BanHangController"
            })
            .state('hoadon', {
                url: "/hoadon",
                templateUrl: "/app/conponents/banhang/HoaDonView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "HoaDonController"
                })
            .state('giamgiahangban', {
                url: "/giamgiahangban",
                templateUrl: "/app/conponents/banhang/GiamGiaHangBanView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "GiamGiaHangBanController"
                })
            .state('tralaihangban', {
                url: "/tralaihangban",
                templateUrl: "/app/conponents/banhang/TraLaiHangBanView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "TraLaiHangBanController"
            })

    }
})();