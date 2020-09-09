(function (app) {
    'use strict';

    app.controller('themNhanVienMoiController', themNhanVienMoiController);

    themNhanVienMoiController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function themNhanVienMoiController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.allNhanVien = {};
        function getall() {
            apiService.get('/api/nhanvien/getall', null, function (result) {
                if (result.data.length>0) {
                    $scope.allNhanVien = result.data[result.data.length - 1].MaSoNhanVien;
                }
                else {
                    $scope.allNhanVien = 0;
                }
             
                
                var maso = parseInt($scope.allNhanVien);
                
                var str = "" + (maso+1)
                var pad = "0000"
                var ans = pad.substring(0, pad.length - str.length) + str
                

                $scope.AllTrinhDoNgoaiNgu = [{ MaSoNhanVien: ans }];
                $scope.AllThoiGianCongTac = [{ MaSoNhanVien: ans }];
                $scope.AllQuaTrinhDaoTao = [{ MaSoNhanVien: ans }];
                $scope.LichSuLamViec = [{ MaSoNhanVien: ans }];

                $scope.AllVienChucChitiet = {
                    MaSoNhanVien: ans
                }
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        function getChucVu() {
            apiService.get('/api/chucvu/getall', null, function (result) {
                $scope.ChucVu = result.data;
                
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getall();
        getChucVu();
        $scope.msvc = "";
        
        $scope.AllTrinhDoNgoaiNgu = [];
        $scope.AllThoiGianCongTac = []
        $scope.AllQuaTrinhDaoTao = [];
        $scope.LichSuLamViec = [];
        $scope.AddAllThongtinvienchuc = AddAllThongtinvienchuc;
       

        function AddAllThongtinvienchuc() {
            var QTDT = 0;
            var LSLV = 0;
            var TTTD = 0;

            angular.forEach($scope.AllQuaTrinhDaoTao, function (item) {
                if (item.NgayBatDau != null || item.NgayKetThuc!=null) {
                    if (item.NgayBatDau >= item.NgayKetThuc) {
                        QTDT = 1;
                    }
                }
                
            })
            angular.forEach($scope.LichSuLamViec, function (item) {
                if (item.NgayBatDau != null || item.NgayKetThuc != null) {
                    if (item.NgayBatDau >= item.NgayKetThuc) {
                        LSLV = 1;
                    }
                }
            })
            angular.forEach($scope.AllThoiGianCongTac, function (item) {
                if (item.NgayBatDau != null || item.NgayKetThuc != null) {
                    if (item.NgayBatDau >= item.NgayKetThuc) {
                        TTTD = 1;
                    }
                }
            })
            if (QTDT==1) {
                alert("Lỗi quá trình đào tạo: ngày kết thúc phải lớn hơn ngày bắt đầu");
            }
            if (LSLV == 1) {
                alert("Lỗi lịch sử làm việc: ngày kết thúc phải lớn hơn ngày bắt đầu");
            }
            if (TTTD == 1) {
                alert("Lỗi thông tin tuyển dụng: ngày kết thúc phải lớn hơn ngày bắt đầu");
            }

            if (QTDT == 0 && LSLV == 0 && TTTD == 0) {
                $ngBootbox.confirm('Bạn có chắc lưu ?').then(function () {
                    apiService.post('/api/nhanvien/create', $scope.AllVienChucChitiet, function (result) {
                        notificationService.displaySuccess("Thêm thành công");

                        apiService.post('/api/ngonngu/create', $scope.AllTrinhDoNgoaiNgu, function (result) {

                        }, function () {
                            notificationService.displayWarning('Thêm ngôn ngữ thất bại');
                        });
                        apiService.post('/api/thongtintuyendung/create', $scope.AllThoiGianCongTac, function (result) {

                        }, function () {
                            notificationService.displayWarning('Thêm thông tin tuyển dụng thất bại');
                        });
                        apiService.post('/api/QuaTrinhDaoTao/create', $scope.AllQuaTrinhDaoTao, function (result) {

                        }, function () {
                            notificationService.displayWarning('Thêm quá trình đào tạo thất bại');
                        });
                        apiService.post('/api/lichsulamviec/create', $scope.LichSuLamViec, function (result) {

                        }, function () {
                            notificationService.displayWarning('Thêm lịch sử làm việc thất bại');
                        });
                        $scope.AllVienChucChitiet = {};
                        $scope.AllTrinhDoNgoaiNgu = [];
                        $scope.AllThoiGianCongTac = [];
                        $scope.AllQuaTrinhDaoTao = [];
                        $scope.LichSuLamViec = [];
                        getall();


                    }, function () {
                        notificationService.displayWarning('Thêm thất bại');
                    });
                });
            }

        }


        $scope.getSeoTitle = getSeoTitle;

        function getSeoTitle(item) {

           


        }




        $scope.solanlap = [1];
        $scope.solanlap1 = [1];
        $scope.solanlap2 = [1];
        $scope.solanlap3 = [1];
        $scope.click = 0;
        $scope.myFunction = function () {
            $scope.click++;
            $scope.solanlap = [];

            for (var i = 1; i <= $scope.click; i++) {
                $scope.solanlap.push(i);

            }
            return $scope.solanlap;
        }
        $scope.clicks = 0;
        $scope.myFunction1 = function () {

            $scope.clicks++;
            $scope.solanlap1 = [];
            for (var i = 1; i <= $scope.clicks; i++) {
                $scope.solanlap1.push(i);
            }
            return $scope.solanlap1;
        }

        $scope.clickss = 0;
        $scope.myFunction2 = function () {

            $scope.clickss++;
            $scope.solanlap2 = [];
            for (var i = 1; i <= $scope.clickss; i++) {
                $scope.solanlap2.push(i);
            }
            return $scope.solanlap2;
        }

        $scope.myFunction3 = function () {

            $scope.clickss++;
            $scope.solanlap3 = [];
            for (var i = 1; i <= $scope.clickss; i++) {
                $scope.solanlap3.push(i);
            }
            return $scope.solanlap3;
        }

       
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.AllVienChucChitiet.Hinh = fileUrl;
                })
              
            }
            finder.popup();
            //$scope.putupdateimage();


        }

        function GetCoSo() {

            apiService.get('/api/coso/getall', null, function (result) {

                $scope.getALLCoSo = result.data;

            }, function () {
                console.log('Load Thông tin  failed.');
            });
        }
        GetCoSo();
        
    }

   
    
})(angular.module('platformTH_GV.quanlynhansu'));