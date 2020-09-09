/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.muahang', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('donmuahang', {
            url: "/donmuahang",
            templateUrl: "/app/conponents/muahang/DonMuaHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "DonMuaHang"
        }).state('hopdongmuahang', {
            url: "/hopdongmuahang",
            templateUrl: "/app/conponents/muahang/HopDongMuaHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "HopDongMuaHangController"
        })
        .state('muahang', {
            url: "/muahang",
            templateUrl: "/app/conponents/muahang/MuaHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "MuaHangController"
        })
        .state('chungtumuahang', {
            url: "/chungtumuahang",
            templateUrl: "/app/conponents/muahang/ChungTuMuaHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ChungTuMuaHangController"
        }).state('chungtumuahangnhieuhoadon', {
        url: "/chungtumuahangnhieuhoadon",
        templateUrl: "/app/conponents/muahang/ChungTuMuaHangNhieuHoaDonView.html?v=" + window.appVersion,
        parent: 'base',
        controller: "ChungTuMuaHangNhieuHoaDonController"

        }).state('thongkehopdongmuahang', {
            url: "/thongkehopdongmuahang",
            templateUrl: "/app/conponents/muahang/thongKeHopDongMuaHangView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeHopDongMuaHangController"
        })
        .state('thongkechungtumuadichvu', {
            url: "/thongkechungtumuadichvu",
            templateUrl: "/app/conponents/muahang/thongKeChungTuMuaDichVuView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeChungTuMuaDichVuController"
        })
        .state('thongkegiamgiahangmua', {
            url: "/thongkegiamgiahangmua",
            templateUrl: "/app/conponents/muahang/thongKeGiamGiamGiaHangMuaView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeGiamGiaHangMuaController"
        })
        .state('thongkenhanhoadon', {
            url: "/thongkenhanhoadon",
            templateUrl: "/app/conponents/muahang/thongKeNhanHoaDonView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeNhanHoaDonController"
        })
        .state('thongketralaihangmua', {
            url: "/thongketralaihangmua",
            templateUrl: "/app/conponents/muahang/thongKeTraLaiHangMuaView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ThongKeTraLaiHangMuaController"
        })
        .state('tralaihangmua', {
            url: "/tralaihangmua",
            templateUrl: "/app/conponents/muahang/TraLaiHangMuaView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "TraLaiHangMuaController"
        })
        .state('giamgiahangmua', {
            url: "/giamgiahangmua",
            templateUrl: "/app/conponents/muahang/GiamGiaHangMuaView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "GiamGiaHangMuaController"
        }) .state('nhanhoadon', {
            url: "/nhanhoadon",
            templateUrl: "/app/conponents/muahang/NhanHoaDonView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "NhanHoaDonController"
        })
        .state('chungtumuadichvu', {
            url: "/chungtumuadichvu",
            templateUrl: "/app/conponents/muahang/ChungTuMuaDichVuView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "ChungTuMuaDichVuController"
        })

    }
})();