/// <reference path="../../../assets/sinhvien/libs/angular/angular.js" />


(function () {
    angular.module('platformTH_GV.nopdon', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('nopdon', {
            url: "/nopdon",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/nopDonView.html?v=" + window.appVersion,
            controller: "nopDonController"
        })
            .state('dondenghikiemtralai', {
                url: "/dondenghikiemtralai",
                parent: 'base',
                templateUrl: "app/conponents/nopdon/donDeNghiKiemTraLaiView.html?v=" + window.appVersion,
                controller: "donDeNghiKiemTraLaiController"
            })
            .state('dondangkythilaitotnghiep', {
                url: "/dondangkythilaitotnghiep",
                parent: 'base',
                templateUrl: "app/conponents/nopdon/donDangKyThiLaiTotnghiepView.html?v=" + window.appVersion,
                controller: "donDangKyThiLaiTotnghiepController"
            })
            .state('dondenghihotrochiphihoctap', {
                url: "/dondenghihotrochiphihoctap",
                parent: 'base',
                templateUrl: "app/conponents/nopdon/donDeNghiHoTroChiPhiHocTapView.html?v=" + window.appVersion,
                controller: "donDeNghiHoTroChiPhiHocTapController"
            })
            
            .state('dondangkyduthitotnghiep', {
                url: "/dondangkyduthitotnghiep",
                parent: 'base',
                templateUrl: "app/conponents/nopdon/donDangKyDuThiTotnghiepView.html?v=" + window.appVersion,
                controller: "donDangKyDuThiTotnghiepController"
            })
            .state('donxincapbangdiemhocky', {
                url: "/donxincapbangdiemhocky",
                parent: 'base',
                templateUrl: "app/conponents/nopdon/donXinCapBangDiemHocKyView.html?v=" + window.appVersion,
                controller: "donXinCapBangDiemHocKyController"
            })
            .state('dodenghimiengiamhocphi', {
                url: "/dodenghimiengiamhocphi",
                parent: 'base',
                templateUrl: "app/conponents/nopdon/donDeNghiMienGiamHocPhiView.html?v=" + window.appVersion,
                controller: "donDeNghiMienGiamHocPhiController"
            }).state('phieucauhoidanhchosinhvien', {
                url: "/phieucauhoidanhchosinhvien",
                parent: 'base',
            templateUrl: "app/conponents/nopdon/phieuCauHoiDanhChoSinhVienView.html?v=" + window.appVersion,
            controller: "phieuCauHoiDanhChoSinhVienController"
        }).state('donxinbaoluuketquahoctap', {
            url: "/donxinbaoluuketquahoctap",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinBaoLuuKetQuaHocTapView.html?v=" + window.appVersion,
            controller: "donXinBaoLuuKetQuaHocTapController"
        }).state('donxincapbangdiemtotnghiep', {
            url: "/donxincapbangdiemtotnghiep",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinCapBangDiemTotNghiepView.html?v=" + window.appVersion,
            controller: "donXinCapBangDiemTotNghiepController"
        }).state('donxincapgiayxacnhanhoanthanhkhoahoc', {
            url: "/donxincapgiayxacnhanhoanthanhkhoahoc",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinCapGiayXacNhanHoanThanhKhoaHocView.html?v=" + window.appVersion,
            controller: "donXinCapGiayXacNhanHoanThanhKhoaHocController"
        }).state('donxincaplaigiayxacnhantotnghieptamthoi', {
            url: "/donxincaplaigiayxacnhantotnghieptamthoi",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinCapLaiGiayXacNhanTotNghiepTamThoiView.html?v=" + window.appVersion,
            controller: "donXinCapLaiGiayXacNhanTotNghiepTamThoiController"
        }).state('donxinchuyentulamkhoaluan_doansanghcomonthaythetot', {
            url: "/donxinchuyentulamkhoaluan_doansanghcomonthaythetot",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinChuyenTuLamKhoaLuan_DoAnSangHocMonThayTheTotView.html?v=" + window.appVersion,
            controller: "donXinChuyenTuLamKhoaLuan_DoAnSangHocMonThayTheTotController"
        }).state('donxinvangthi', {
            url: "/donxinvangthi",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinVangThiView.html?v=" + window.appVersion,
            controller: "donXinVangThiController"
        }).state('phieudangkyhocphan', {
            url: "/phieudangkyhocphan",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/phieuDangKyHocPhanView.html?v=" + window.appVersion,
            controller: "phieuDangKyHocPhanController"
        }).state('phieuyeucaucapgiayxacnhanlasinhviencuatruong', {
            url: "/phieuyeucaucapgiayxacnhanlasinhviencuatruong",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/phieuYeuCauCapGiayXacNhanLaSinhVienCuaTruongView.html?v=" + window.appVersion,
            controller: "phieuYeuCauCapGiayXacNhanLaSinhVienCuaTruongController"
        }).state('dondenghikiemtralaiketquathitotnghiep', {
            url: "/dondenghikiemtralaiketquathitotnghiep",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donDeNghiKiemTraLaiKetQuaThiTotNghiepView.html?v=" + window.appVersion,
            controller: "donDeNghiKiemTraLaiKetQuaThiTotNghiepController"
        }).state('dondenghixettotnghiep_henienche', {
            url: "/dondenghixettotnghiep_henienche",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donDeNghiXetTotNghiep_HeNienCheView.html?v=" + window.appVersion,
            controller: "donDeNghiXetTotNghiep_HeNienCheController"
        }).state('dondenghixettotnghiep_hetinchi', {
            url: "/dondenghixettotnghiep_hetinchi",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donDeNghiXetTotNghiep_HeTinChiView.html?v=" + window.appVersion,
            controller: "donDeNghiXetTotNghiep_HeTinChiController"
        }).state('donxinxacnhandanophocphi', {
            url: "/donxinxacnhandanophocphi",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinXacNhanDaNopHocPhiView.html?v=" + window.appVersion,
            controller: "donXinXacNhanDaNopHocPhiController"
        }).state('donxinhoan_chamnophocphi', {
            url: "/donxinhoan_chamnophocphi",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinHoan_ChamNopHocPhiView.html?v=" + window.appVersion,
            controller: "donXinHoan_ChamNopHocPhiController"
        }).state('donxinmienhoc_mienthi_tamhoancachocphan_gdtc_gdqp', {
            url: "/donxinmienhoc_mienthi_tamhoancachocphan_gdtc_gdqp",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinMienHoc_MienThi_TamHoanCacHocPhan_GDTC_GDQPView.html?v=" + window.appVersion,
            controller: "donXinMienHoc_MienThi_TamHoanCacHocPhan_GDTC_GDQPController"
        }).state('donxinmienhoc_mienthi_tamhoancachocphan_tienganh', {
            url: "/donxinmienhoc_mienthi_tamhoancachocphan_tienganh",
            parent: 'base',
            templateUrl: "app/conponents/nopdon/donXinMienHoc_MienThi_TamHoanCacHocPhan_TiengAnhView.html?v=" + window.appVersion,
            controller: "donXinMienHoc_MienThi_TamHoanCacHocPhan_TiengAnhController"
        });
       
        
    }
})();