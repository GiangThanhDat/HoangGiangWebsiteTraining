
(function (app) {
    'use strict';

    app.controller('BanHangController', BanHangController);

    BanHangController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter', '$timeout', '$window','$mdMedia'];
    function BanHangController($scope, apiService, notificationService, $ngBootbox, $filter, $timeout, $window, $mdMedia) {
        $scope.suahoadon = true;

        $scope.getcoso = function () {
            var config = {
                params: {
                    msnv: $scope.authentication.userName,
                }
            }
            apiService.get('/api/nhanvien/getbymsnv', config, function (result) {
                $scope.CoSo = result.data[0]   
            }, function () {
                console.log('Load  failed.');
            });
        }

        $scope.TTCN = [];
        ///themdon
        $scope.clickss = 1;
        $scope.don = [{ 'stt' :1}];
        $scope.donhang = [0]
        $scope.sttdon = 0;
        $scope.donhang[1] = []
        $scope.themdon = function () {
            $scope.clickss++;
            var a = $scope.clickss;
            
            $scope.donhang[a] = [];
            $scope.donhang[a - 1] = $scope.TTCN
            $scope.TTCN = $scope.donhang[a];
            $scope.doimauhoadon(a-1)
            //console.log($scope.donhang)
            $scope.don = [{ 'stt': 1 }];
            for (var i = 2; i <= $scope.clickss; i++) {
                $scope.don.push({ stt: i });
            }
            return $scope.solanlap;
        }

        $scope.chondon = function (i) {
            $scope.sttdon = i+1;
            $scope.TTCN = $scope.donhang[$scope.sttdon];  
            //console.log($scope.TTCN)
        }
        $scope.xoadon = function (item,i) {
            //$scope.donhang.splice(item, 1);
            if ($scope.don.length==1) {
                $scope.don.splice(item, 1);
                $scope.donhang.splice(item, 1);
                //$scope.clickss--;
                $scope.TTCN.length = 0;
                $scope.donhang[1] = [];
                $scope.TTCN = [];
                $scope.don = [{ stt: 1 }];
               // console.log($scope.don)
               // console.log($scope.donhang)
            }
            else {
                $scope.don.splice(item, 1);
                $scope.donhang.splice(i, 1);
                $scope.clickss--;
                //console.log($scope.don)
               // console.log($scope.donhang)
               // $scope.TTCN.length = 0;
               

            }
            
        }
















        $scope.getcoso();
        $scope.TongTien = [{ 'TongTien': 0 }];
        $scope.disable = false;
        $scope.keyword=''
        $scope.getbykeyword = function (id, soluong, name) {
            if (id.length==12) {
                $scope.timthay = false;
                $scope.timthay1 = false;

                var config = {
                    params: {
                        id: id,

                    }
                }
                apiService.get('/api/hanghoa/getbyid', config, function (result) {
                    if (result.data != null) {


                        $scope.timkim = '';
                        $scope.click = null;
                        if (name != undefined) {
                            document.getElementById(name).disabled = true;
                        }


                        $timeout(function () {
                            if (name != undefined) {
                                document.getElementById(name).disabled = false;
                                document.getElementById(name).focus();
                            }

                        }, 2000);


                        var a = $scope.TTCN.findIndex(x => x.MaHang === result.data.MaHang);
                        if (a == -1) {
                            result.data.DonGia = result.data.getdvt[0];
                            result.data.MaDonViTinh = result.data.getdvt[0].MaDonViTinh;
                            if (soluong == undefined || soluong == '') {
                                result.data.SoLuong = 1;
                            }
                            else {
                                result.data.SoLuong = soluong;
                            }
                            result.data.TongTien = (result.data.DonGia.DonGia-result.data.GiaKhuyenMai) * result.data.SoLuong;
                            $scope.TTCN.push(result.data);

                        }
                        else {
                            angular.forEach($scope.TTCN, function (item) {
                                if (item.MaHang == result.data.MaHang) {
                                    item.SoLuong += 1;
                                    item.TongTien = (item.DonGia.DonGia-item.GiaKhuyenMai) * item.SoLuong;

                                }
                            })
                        }
                        ////$scope.TTCN = result.data;

                        //$scope.TongTien[0].TongTien = $scope.SoLuong * $scope.DonGia;
                        $scope.timthay1 = true;
                        $scope.khongtimthay = false
                    }
                    else {
                        //$scope.timthay = false;
                        $scope.timthay1 = false;
                        $scope.khongtimthay = true
                        $timeout(function () {
                            $scope.khongtimthay = false;
                        }, 10000);
                    }


                }, function () {
                    console.log('Load  failed.');
                });
            };
            
        }
        $scope.khongtimthay1 = false;
       

        $scope.timkh = function (id) {
            var config = {
                params: {
                    id: id,
                }
            }
            apiService.get('/api/khachhang/getbyid', config, function (result) {
                if (result.data != null) {
                    $scope.khongtimthay1 = false
                    $scope.KH = result.data;
                }
                else {
                    $scope.khongtimthay1 = true
                    $timeout(function () {
                        $scope.khongtimthay1 = false;
                    }, 10000);
                }
            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.kiemtrama = {}
        $scope.timhoadon = function (id) {
            var config = {
                params: {
                    id: id,
                }
            }
            apiService.get('/api/chungtubanhang/getbyid', config, function (result) {
                if (result.data != null) {
                        $scope.khongtimthay1 = false
                        $scope.TTCN.length = 0;
                        $scope.kiemtrama = result.data;
                        var config2 = {
                            params: {
                                MaChungTuBanHang: result.data.MaChungTuBanHang,
                            }
                        }
                        apiService.get('/api/chitietchungtubanhang/getchitietchungtubanhang', config2, function (result1) {
                            $scope.chitiet = result1.data;
                            $scope.suahoadon = false;

                            angular.forEach(result1.data, function (item) {
                                $scope.getbykeyword(item.MaHang, item.SoLuong);
                            })

                        }, function () {
                            console.log('Load  failed.');
                        });
                    
                }
                else {
                    $scope.khongtimthay1 = true

                    $timeout(function () {
                        $scope.khongtimthay1 = false;
                    }, 10000);
                }


            }, function () {
                console.log('Load  failed.');
            });
        }

        $scope.SoLuong = 1;

        $scope.ttchung = true;
        $scope.thanhtoan = true;
        
        
        $scope.tongtien = function (sl, dg, i,km, tinh) {
            sl = parseInt(sl);
            
            if (tinh != undefined) {
                if (tinh=='cong') {
                    sl += 1;
                    $scope.TTCN[i].SoLuong = sl;
                    $scope.TTCN[i].TongTien = sl * (dg-km);
                }
                else {
                    sl -= 1;
                    $scope.TTCN[i].SoLuong = sl;
                    $scope.TTCN[i].TongTien = sl * (dg - km);

                    if (sl < 1) {
                        $scope.chontextbox = 'change'
                        $scope.TTCN.splice(i, 1);
                        $scope.keyword = '';


                    }
                }
            }
            else {
                $scope.TTCN[i].TongTien = sl * (dg - km);

            }
            
            
           // console.log(sl+'/'+dg+'/'+i)
        }
        $scope.adddvt = function (i, index) {
            $scope.TTCN[index].MaDonViTinh = i;
        }
       
        
        $scope.new = [];
        $scope.test = [];
        $scope.deleteItem = function (id) {
            $scope.TTCN.splice(id, 1);
            $scope.keyword = '';
            $scope.chontextbox = 'change'
            document.getElementById("change").disabled = true;

            $timeout(function () {
                document.getElementById("change").disabled = false;
                document.getElementById('change').focus();
            }, 2000);
        }


        //////////////////////////////////
        


        //thanh toán
       
        $scope.CTBH = {

        }
        function getCTBH() {
            apiService.get('/api/chungtubanhang/getall', null, function (result) {
                if (result.data.length > 0) {
                    $scope.maphieuthu = result.data[result.data.length - 1].MaChungTuBanHang.split('BH')[1];
                }
                else {
                    $scope.maphieuthu = 0;
                }


                var maso = parseInt($scope.maphieuthu);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "BH"
                var ans = pad.substring(0) + ans1
                //alert(ans);
                $scope.CTBH.MaChungTuBanHang = ans;
                $scope.backup = ans;

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        getCTBH();
        $scope.thanhtoanhoadon = function () {
            var now = new Date();
            $scope.time = $filter('date')(now, 'MM-dd-yyyy HH:mm:ss');
            $scope.bill = angular.copy($scope.TTCN);
        }
        $scope.ChiTietThu=[];
        $scope.myfunction = function () {
            var total = 0;
            

            angular.forEach($scope.TTCN, function (item) {
                total += item.TongTien;
            })
            if ($scope.KH == undefined || $scope.KH.MaKhachHang == undefined) {
                $scope.CTBH.MaKhachHang="KH000000"
            }
            else {
                $scope.CTBH.MaKhachHang = $scope.KH.MaKhachHang
            }
            $scope.CTBH.MaSoNhanVien = $scope.authentication.userName;
            $scope.CTBH.TongTienHang = total;
            $scope.CTBH.TongTienThanhToan = total;
            $scope.CTBH.NgayHoachToan = $scope.time.toLocaleString();
            $scope.CTBH.NgayChungTu = $scope.time.toLocaleString();

            $scope.ChiTietThu = angular.copy($scope.bill)
            
            angular.forEach($scope.ChiTietThu, function (item) {
                item.MaChungTuBanHang = $scope.CTBH.MaChungTuBanHang;
                item.ThanhTien = item.TongTien;
            })
            if ($scope.kiemtrama.MaChungTuBanHang) {
                $scope.kiemtrama.DaThayDoi = true;
                $scope.kiemtrama.MaPhieuMoi = $scope.CTBH.MaChungTuBanHang;
                $scope.kiemtrama.NgayThayDoi = $scope.time.toLocaleString();
                $scope.kiemtrama.NhanVienThayDoi = $scope.authentication.userName;
                $scope.kiemtrama.CoSoThayDoi = $scope.CoSo.MaCoSo;
               // $scope.CTBH.MaChungTuBanHang = $scope.kiemtrama.MaChungTuBanHang;

                apiService.put('/api/chungtubanhang/update', $scope.kiemtrama, function (result) {
                    $scope.CTBH.DaThayDoi = false;
                    $scope.kiemtrama.MaPhieuMoi = null;
                    $scope.kiemtrama.NgayThayDoi = null;
                    $scope.kiemtrama.NhanVienThayDoi = null;
                    $scope.kiemtrama.CoSoThayDoi = null;
                    $scope.CTBH.MaPhieuGoc = $scope.kiemtrama.MaChungTuBanHang;

                        apiService.post('/api/chungtubanhang/create', $scope.CTBH, function (result) {
                            notificationService.displaySuccess("Lưu chứng từ bán hàng thành công");
                            //Lưu chi tiết chứng từ
                            apiService.post('/api/chitietchungtubanhang/create', $scope.ChiTietThu, function (result) {
                                notificationService.displaySuccess("Lưu chi tiết thành công");
                                getCTBH();
                                $scope.TTCN.length = 0;
                                $scope.bill.length = 0;
                                $scope.ChiTietThu.length = 0;
                                $scope.CTBH.length = 0;
                                $scope.KH = {};
                            }, function () {
                                notificationService.displayWarning("Lưu chi tiết chứng từ bán hàng không thành công");

                            });

                        }, function () {
                            notificationService.displayWarning("Lưu không thành công");
                        });
                
            }, function () {
                notificationService.displayWarning("Lưu không thành công");
            });
            }
            else {
                $scope.CTBH.DaThayDoi = false;
                apiService.post('/api/chungtubanhang/create', $scope.CTBH, function (result) {
                    notificationService.displaySuccess("Lưu chứng từ bán hàng thành công");
                    //Lưu chi tiết chứng từ
                    apiService.post('/api/chitietchungtubanhang/create', $scope.ChiTietThu, function (result) {
                        notificationService.displaySuccess("Lưu chi tiết thành công");
                        getCTBH();
                        $scope.TTCN.length = 0;
                        $scope.bill.length = 0;
                        $scope.ChiTietThu.length = 0;
                        $scope.CTBH.length = 0;
                        $scope.KH = {};
                    }, function () {
                        notificationService.displayWarning("Lưu chi tiết chứng từ bán hàng không thành công");

                    });

                }, function () {
                    notificationService.displayWarning("Lưu không thành công");
                });
            }


        };
        $scope.an = false;





        

       
        ////của luận
        $scope.custom = 12;

        //$scope.$watch(function () {
        //    return $mdMedia('md');
        //}, function (md) {
        //    if (md) {
        //        $scope.custom = 6;
        //    }
        //});

        $scope.a = function (i) {
            $scope.custom = i;
            $scope.getpagination()

        }

        


        $scope.getpagination = function (page) {
            page = page || 0;
            var config = {
                params: {
                    page: page,
                    pageSize: $scope.custom
                }
            }
            apiService.get('/api/hanghoa/getallhanghoa/', config, function (result) {

                $scope.pagination = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                var dem = [];
                var i
                for (i = 1; i <= $scope.pagesCount; i++) {
                    dem.push(i)

                }

                $scope.dem = dem;

                $scope.range = function () {
                    if (!$scope.pagesCount) { return []; }
                    var step = 2;
                    var doubleStep = step * 2;
                    var start = Math.max(0, $scope.page - step);
                    var end = start + 1 + doubleStep;
                    if (end > $scope.pagesCount) { end = $scope.pagesCount; }

                    var ret = [];
                    for (var i = start; i != end; ++i) {
                        ret.push(i);
                    }

                    return ret;
                };


                $scope.TotalCount = result.data.TotalCount;

                angular.forEach($scope.pagination, function (item) {

                    if (item.getdvt[0].DonGia != null) {
                        item.getdvt[0].DonGia = item.getdvt[0].DonGia.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });

                    }

                })

            }, function () {
                console.log('Load thông tin failed.');
            });

        }

        $scope.getpagination()
       // $scope.gethanghoa();





        //keypad
        var vm = this;
        var clearsl = '';
        $scope.focus = 'change';
        vm.valor = '';
        vm.keys = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        vm.onKeyPressed = onKeyPressed;
        $scope.chontextbox=''
        function onKeyPressed(data) {
            if (data == '<') {
                $scope.keyword = $scope.keyword.slice(0, $scope.keyword.length - 1);
                clearsl=''
            }
            else if(data == 'CLEAR') {
                $scope.keyword = "";
                clearsl = 1;
            }
           
            else {
                $scope.keyword += data;
                clearsl=''
            }



            if ($scope.chontextbox == 'change') {
                $scope.focus = $scope.chontextbox;
                $scope.timkim = $scope.keyword;
                $scope.getbykeyword($scope.keyword, '', 'change');
                document.getElementById($scope.focus).focus();


            }
            else if ($scope.chontextbox == 'soluong') {
                $scope.focus = $scope.chontextbox;
                $scope.TTCN[$scope.i].SoLuong = $scope.keyword;
                document.getElementById($scope.focus + $scope.i).focus();
                $scope.tongtien($scope.keyword, $scope.dg, $scope.i, $scope.km)

            }
            else if ($scope.chontextbox == 'timkh') {
                $scope.focus = $scope.chontextbox;
                $scope.kh = $scope.keyword;
                document.getElementById($scope.focus).focus();
                $scope.timkh($scope.kh)
            }
            else if ($scope.chontextbox == 'khachtra') {
                $scope.focus = $scope.chontextbox;
                $scope.KhachTra = $scope.keyword;
                document.getElementById($scope.focus).focus();
            }
        }
       

        
        $scope.dg=''
        $scope.i=''
        $scope.km=''
        $scope.gettextbox = function (tb,dg,i,km) {
            $scope.keyword = '';
            $scope.chontextbox = tb;
            $scope.dg = dg;
            $scope.i = i;
        }

        $scope.doimauhoadon = function (index) {
            $scope.selected = index;
        }
        $scope.selected = 0
      //them KH
        $scope.addKH = {
        }

        function getallKH() {
            apiService.get('/api/khachhang/getall', null, function (result) {
                $scope.AllKhachHang = result.data;
                var maso = parseInt(result.data[result.data.length - 1].MaKhachHang.split('KH')[1]);

                var str = "" + (maso + 1)
                var pad1 = "000000"
                var ans1 = pad1.substring(0, pad1.length - str.length) + str
                var pad = "KH"
                var ans = pad.substring(0) + ans1



                $scope.addKH = {
                    MaKhachHang: ans, PhanLoai: 'Tổ chức', QuocGia: 'Việt Nam'

                }
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }

        getallKH();
        function getNhomKH() {
            apiService.get('/api/nhomkh_ncc/getall', null, function (result) {
                $scope.NhomKH = result.data;

            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }

        getNhomKH();




        $scope.addKhachHang = function () {
            $ngBootbox.confirm('Bạn có chắc lưu ?').then(function () {
                
                    apiService.post('/api/khachhang/create', $scope.addKH, function (result) {
                        notificationService.displaySuccess("Thêm thành công");
                        getallKH()
                        $scope.addKH = {}
                    }, function () {
                        notificationService.displayWarning('Thêm thất bại');
                    });
            });
        }


    }
   
    
})(angular.module('platformTH_GV.banhangnv'));