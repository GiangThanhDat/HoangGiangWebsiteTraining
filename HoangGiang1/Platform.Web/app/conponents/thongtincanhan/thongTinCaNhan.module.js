/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.thongtincanhan', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('thongtincanhan', {
            url: "/thongtincanhan",
            templateUrl: "/app/conponents/thongtincanhan/thongTinCaNhanView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "thongTinCaNhanController"
        }),
            $stateProvider.state('hoanthanhcongviec', {
                url: "/hoanthanhcongviec",
                templateUrl: "/app/conponents/thongtincanhan/HoanThanhCongViecView.html?v=" + window.appVersion,
                parent: 'base',
                controller: "HoanThanhCongViecController"
            }),
             $stateProvider.state('lichsulamviec', {
                 url: "/lichsulamviec",
                 templateUrl: "/app/conponents/thongtincanhan/LichSuLamViecView.html?v=" + window.appVersion,
                parent: 'base',
                 controller: "LichSuLamViecController"
            }),
             $stateProvider.state('ngonngu', {
                 url: "/ngonngu",
                 templateUrl: "/app/conponents/thongtincanhan/NgonNguView.html?v=" + window.appVersion,
                parent: 'base',
                 controller: "NgonNguController"
            }),
              $stateProvider.state('quanlycongtac', {
                  url: "/quanlycongtac",
                  templateUrl: "/app/conponents/thongtincanhan/QuanLyCongTacView.html?v=" + window.appVersion,
                parent: 'base',
                  controller: "QuanLyCongTacController"
            }),
             $stateProvider.state('quanlyngaynghi', {
                 url: "/quanlyngaynghi",
                 templateUrl: "/app/conponents/thongtincanhan/QuanLyNgayNghiView.html?v=" + window.appVersion,
                parent: 'base',
                 controller: "QuanLyNgayNghiController"
            }),
             $stateProvider.state('quanlyquagio', {
                 url: "/quanlyquagio",
                 templateUrl: "/app/conponents/thongtincanhan/QuanLyQuaGioView.html?v=" + window.appVersion,
                parent: 'base',
                 controller: "QuanLyQuaGioController"
            }),
             $stateProvider.state('quatrinhdaodao', {
                 url: "/quatrinhdaodao",
                 templateUrl: "/app/conponents/thongtincanhan/QuaTrinhDaoTaoView.html?v=" + window.appVersion,
                parent: 'base',
                 controller: "QuaTrinhDaoTaoController"
            }),
              $stateProvider.state('the', {
                 url: "/the",
                  templateUrl: "/app/conponents/thongtincanhan/TheView.html?v=" + window.appVersion,
                parent: 'base',
                  controller: "TheController"
            }),
             $stateProvider.state('thongtintuyendung', {
                 url: "/thongtintuyendung",
                 templateUrl: "/app/conponents/thongtincanhan/ThongTinTuyenDungView.html?v=" + window.appVersion,
                parent: 'base',
                 controller: "ThongTinTuyenDungController"
            }),
             $stateProvider.state('quanlytaisanCaNhan', {
                 url: "/quanlytaisanCaNhan",
                 templateUrl: "/app/conponents/thongtincanhan/QuanLyTaiSanView.html?v=" + window.appVersion,
                parent: 'base',
                 controller: "QuanLyTaiSanController"
             })


            
    }
})();