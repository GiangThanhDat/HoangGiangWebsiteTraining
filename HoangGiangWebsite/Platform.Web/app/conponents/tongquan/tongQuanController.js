(function (app) {
    'use strict';

    app.controller('tongQuanController', tongQuanController);

    tongQuanController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function tongQuanController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.theongay = true;
        $scope.theogio = false;
        $scope.theothu = false;
        $scope.select = 'thangnay';
        $scope.textselect = 'tháng này';
        $scope.select1 = 'thangnay';
        $scope.textselect1 = 'tháng này'
        $scope.select2 = 'thangnay';
        $scope.textselect2 = 'tháng này'
        $scope.gettheongay = gettheongay;
        //getselect
        $scope.getTheoNgay = [];
        var dauthang;
        var cuoithang;
        dauthang = moment().startOf('month').format("MM/DD/YYYY hh:mm:ss A");
        cuoithang = moment().endOf('month').format("MM/DD/YYYY hh:mm:ss A");

        $scope.setupngay = function () {
            if ($scope.select == 'thangnay') {
                $scope.textselect = 'tháng này'
                dauthang = moment().startOf('month').format("MM/DD/YYYY hh:mm:ss A");
                cuoithang = moment().endOf('month').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.theongay==true) {
                    $scope.gettheongay();
                }
                else if ($scope.theogio == true) {
                    $scope.gettheogio();
                }
                else if ($scope.theothu == true) {
                    $scope.gettheothu();
                }
            }
            else if ($scope.select == 'homnay') {
                $scope.textselect = 'hôm nay'
                 dauthang = moment().startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                 cuoithang = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.theongay == true) {
                    $scope.gettheongay();
                }
                else if ($scope.theogio == true) {
                    $scope.gettheogio();
                }
                else if ($scope.theothu == true) {
                    $scope.gettheothu();
                }            }
            else if ($scope.select == 'homqua') {
                $scope.textselect = 'hôm qua'
                dauthang = moment().subtract(1, 'day').startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                cuoithang = moment().subtract(1, 'day').endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.theongay == true) {
                    $scope.gettheongay();
                }
                else if ($scope.theogio == true) {
                    $scope.gettheogio();
                }
                else if ($scope.theothu == true) {
                    $scope.gettheothu();
                }            }
            else if ($scope.select == '7ngayqua') {
                $scope.textselect = '7 ngày qua'
                dauthang = moment().subtract(6, 'day').startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                cuoithang = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.theongay == true) {
                    $scope.gettheongay();
                }
                else if ($scope.theogio == true) {
                    $scope.gettheogio();
                }
                else if ($scope.theothu == true) {
                    $scope.gettheothu();
                }            }
            else if ($scope.select == 'thangtruoc') {
                $scope.textselect = 'tháng trước'
                dauthang = moment().subtract(1, 'month').startOf('month').format("MM/DD/YYYY hh:mm:ss A");
                cuoithang = moment().subtract(1, 'month').endOf('month').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.theongay == true) {
                    $scope.gettheongay();
                }
                else if ($scope.theogio == true) {
                    $scope.gettheogio();
                }
                else if ($scope.theothu == true) {
                    $scope.gettheothu();
                }            }


        }
        

       
        function gettheongay() {
            $scope.labels = [];
            $scope.series = [];

            $scope.data = [

            ];
            var config = {
                params: {
                    ngaydau: dauthang,
                    ngaycuoi: cuoithang,
                    dathaydoi: false
                }
            }

            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthutheoselect = 0;
                var result1 = [];
                result.data.forEach(function (b) {
                    var newresult = [];
                    b.ChungTuBanHang.forEach(function (a) {
                        $scope.danhthutheoselect += a.TongTienThanhToan;
                        a.NgayChungTu = $filter('date')(a.NgayChungTu, 'dd');
                        if (!this[a.NgayChungTu]) {
                            this[a.NgayChungTu] = { NgayChungTu: a.NgayChungTu, TongTienThanhToan: 0 };
                            newresult.push(this[a.NgayChungTu]);
                        }
                        this[a.NgayChungTu].TongTienThanhToan += a.TongTienThanhToan;
                    }, Object.create(null));
                    result1.push(newresult);
                    $scope.series.push(b.TenCoSo);
                    
                   
                });
               
                

                $scope.newketqua = [];
                var tencoso=[]
                angular.forEach(result1, function (item) {
                    var ketqua=[]
                    angular.forEach(item, function (a) {
                        ketqua.push(a.TongTienThanhToan);
                        tencoso.push(a.NgayChungTu)
                    })
                    $scope.data.push(ketqua)
                    
                })
               
                $.each(tencoso, function (i, el) {
                    if ($.inArray(el, $scope.labels) === -1) $scope.labels.push(el);
                });
                $scope.labels.sort(function (a, b) {
                    return a.localeCompare(b);
                });
                $scope.datatest = [];
                for (var i = 0; i < result1.length; i++) {
                    var inner = result1[i];
                    var ketqua = [];
                    for (var j = 0; j < $scope.labels.length; j++) {
                        
                        
                           var index = inner.findIndex(record => record.NgayChungTu === $scope.labels[j])
                            if (index>-1) {
                                ketqua.push(inner[index].TongTienThanhToan)
                            }
                            else {
                                ketqua.push(0);
                            }
                    }
                    $scope.datatest.push(ketqua);
                }
            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.gettheongay();


        ///top
        function gethomnay() {
            var sang = moment().startOf('day').format("MM/DD/YYYY hh:mm:ss A");
            var toi = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");
            
            var config = {
                params: {
                    ngaydau: sang,
                    ngaycuoi: toi,
                    dathaydoi: false
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.demhoadon = 0;
                $scope.danhthuhomnay = 0;
                angular.forEach(result.data, function (item) {
                    angular.forEach(item.ChungTuBanHang, function (i) {
                        $scope.demhoadon += 1;
                        $scope.danhthuhomnay+=i.TongTienThanhToan
                    })
                })

            }, function () {
                console.log('Load  failed.');
            });
        }
        gethomnay();
        function gettrahang() {
            var sang = moment().startOf('day').format("MM/DD/YYYY hh:mm:ss A");
            var toi = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");

            var config = {
                params: {
                    ngaydau: sang,
                    ngaycuoi: toi,
                    dathaydoi: true
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {

                $scope.demhoadontrahang = 0;
                $scope.danhthuhomnaytrahang = 0;
                angular.forEach(result.data, function (item) {
                    angular.forEach(item.ChungTuBanHang, function (i) {
                        $scope.demhoadontrahang += 1;
                        $scope.danhthuhomnaytrahang += i.TongTienThanhToan
                    })
                })
                gethomqua();
            }, function () {
                console.log('Load  failed.');
            });
        }
        gettrahang();
         function gethomqua() {
             var sang = moment().subtract(1,'day').startOf('day').format("MM/DD/YYYY hh:mm:ss A");
             var toi = moment().subtract(1, 'day').endOf('day').format("MM/DD/YYYY hh:mm:ss A");
             //console.log(sang+'/'+toi)
            var config = {
                params: {
                    ngaydau: sang,
                    ngaycuoi: toi,
                    dathaydoi: false
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthuhomhomqua = 0;
                angular.forEach(result.data, function (item) {
                    angular.forEach(item.ChungTuBanHang, function (i) {
                        $scope.danhthuhomhomqua += i.TongTienThanhToan
                    })
                })
            }, function () {
                console.log('Load  failed.');
            });
        }
        
        function getthangtruoc() {
            var sang = moment().subtract(1, 'month').startOf('month').format("MM/DD/YYYY hh:mm:ss A");
            var toi = moment().subtract(1, 'month').endOf('month').format("MM/DD/YYYY hh:mm:ss A");
           // console.log(sang+'/'+toi)
            var config = {
                params: {
                    ngaydau: sang,
                    ngaycuoi: toi,
                    dathaydoi: false
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthuhomthangtruoc = 0;
                angular.forEach(result.data, function (item) {
                    angular.forEach(item.ChungTuBanHang, function (i) {
                        $scope.danhthuhomthangtruoc += i.TongTienThanhToan
                    })
                })
            }, function () {
                console.log('Load  failed.');
            });
        }
        function getthangnay() {
            var dauthang1 = moment().startOf('month').format("MM/DD/YYYY hh:mm:ss A");
            var cuoithang1 = moment().format("MM/DD/YYYY hh:mm:ss A");

            var config = {
                params: {
                    ngaydau: dauthang1,
                    ngaycuoi: cuoithang1,
                    dathaydoi: false
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                getthangtruoc();
                $scope.getthangnay = result.data;

            }, function () {
                console.log('Load  failed.');
            });
        }
        getthangnay();







        //bieudo
        $scope.gettheogio = function () {
            $scope.labels = [];
            $scope.data = [
            ];
            $scope.series = [];
            var config = {
                params: {
                    ngaydau: dauthang,
                    ngaycuoi: cuoithang,
                    dathaydoi: false
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthutheoselect = 0;
                var result1 = [];
                result.data.forEach(function (b) {
                    var newresult = [];
                    b.ChungTuBanHang.forEach(function (a) {
                        $scope.danhthutheoselect += a.TongTienThanhToan;
                        a.NgayChungTu = $filter('date')(a.NgayChungTu, 'HH:00');
                        if (!this[a.NgayChungTu]) {
                            this[a.NgayChungTu] = { NgayChungTu: a.NgayChungTu, TongTienThanhToan: 0 };
                            newresult.push(this[a.NgayChungTu]);
                        }
                        this[a.NgayChungTu].TongTienThanhToan += a.TongTienThanhToan;
                    }, Object.create(null));

                    result1.push(newresult);
                    $scope.series.push(b.TenCoSo);
                });
                $scope.newketqua = [];
                var tencoso = []
                angular.forEach(result1, function (item) {
                    var ketqua = []
                    angular.forEach(item, function (a) {
                        ketqua.push(a.TongTienThanhToan);
                        tencoso.push(a.NgayChungTu)
                    })
                    $scope.data.push(ketqua)
                })
                
                $.each(tencoso, function (i, el) {
                    if ($.inArray(el, $scope.labels) === -1) $scope.labels.push(el);
                });
                $scope.labels.sort(function (a, b) {
                    return a.localeCompare(b);
                });
                $scope.datatest = [];
                for (var i = 0; i < result1.length; i++) {
                    var inner = result1[i];
                    var ketqua = [];
                    for (var j = 0; j < $scope.labels.length; j++) {


                        var index = inner.findIndex(record => record.NgayChungTu === $scope.labels[j])
                        if (index > -1) {
                            ketqua.push(inner[index].TongTienThanhToan)
                        }
                        else {
                            ketqua.push(0);
                        }
                    }
                    $scope.datatest.push(ketqua);
                }




            }, function () {
                console.log('Load  failed.');
            });
        }

        $scope.gettheothu = function () {
            $scope.labels = [];
            $scope.data = [
            ];
            $scope.series = [];
            var config = {
                params: {
                    ngaydau: dauthang,
                    ngaycuoi: cuoithang,
                    dathaydoi: false
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthutheoselect = 0;
                var result1 = [];
                result.data.forEach(function (b) {
                    var newresult = [];
                    b.ChungTuBanHang.forEach(function (a) {
                        $scope.danhthutheoselect += a.TongTienThanhToan;
                        var date = moment(a.NgayChungTu).format('d');
                        a.NgayChungTu = 'T' + (parseInt(date) + 1);
                        if (a.NgayChungTu == 'T1') {
                            a.NgayChungTu = 'CN'
                        }
                        if (!this[a.NgayChungTu]) {
                            this[a.NgayChungTu] = { NgayChungTu: a.NgayChungTu, TongTienThanhToan: 0 };
                            newresult.push(this[a.NgayChungTu]);
                        }
                        this[a.NgayChungTu].TongTienThanhToan += a.TongTienThanhToan;
                    }, Object.create(null));

                    result1.push(newresult);
                    $scope.series.push(b.TenCoSo);
                });
                $scope.newketqua = [];
                var tencoso = []
                angular.forEach(result1, function (item) {
                    var ketqua = []
                    angular.forEach(item, function (a) {
                        ketqua.push(a.TongTienThanhToan);
                        tencoso.push(a.NgayChungTu)
                    })
                    $scope.data.push(ketqua)
                })

                $.each(tencoso, function (i, el) {
                    if ($.inArray(el, $scope.labels) === -1) $scope.labels.push(el);
                });
                $scope.labels.sort(function (a, b) {
                    return a.localeCompare(b);
                });
                $scope.datatest = [];
                for (var i = 0; i < result1.length; i++) {
                    var inner = result1[i];
                    var ketqua = [];
                    for (var j = 0; j < $scope.labels.length; j++) {


                        var index = inner.findIndex(record => record.NgayChungTu === $scope.labels[j])
                        if (index > -1) {
                            ketqua.push(inner[index].TongTienThanhToan)
                        }
                        else {
                            ketqua.push(0);
                        }
                    }
                    $scope.datatest.push(ketqua);
                }
            }, function () {
                console.log('Load  failed.');
            });
        }

        ////getcoso
        var dauthangcoso;
        var cuoithangcoso;
        dauthangcoso = moment().startOf('month').format("MM/DD/YYYY hh:mm:ss A");
        cuoithangcoso = moment().endOf('month').format("MM/DD/YYYY hh:mm:ss A");



        $scope.setupngay1 = function () {
            if ($scope.select1 == 'thangnay') {
                $scope.textselect1 = 'tháng này'
                dauthangcoso = moment().startOf('month').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangcoso = moment().endOf('month').format("MM/DD/YYYY hh:mm:ss A");
                $scope.getcoso();
            }
            else if ($scope.select1 == 'homnay') {
                $scope.textselect1 = 'hôm nay'
                dauthangcoso = moment().startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangcoso = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                $scope.getcoso();
            }
            else if ($scope.select1 == 'homqua') {
                $scope.textselect1 = 'hôm qua'
                dauthangcoso = moment().subtract(1, 'day').startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangcoso = moment().subtract(1, 'day').endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                $scope.getcoso();
            }
            else if ($scope.select1 == '7ngayqua') {
                $scope.textselect1 = '7 ngày qua'
                dauthangcoso = moment().subtract(6, 'day').startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangcoso = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                $scope.getcoso();
            }
            else if ($scope.select1 == 'thangtruoc') {
                $scope.textselect1 = 'tháng trước'
                dauthangcoso = moment().subtract(1, 'month').startOf('month').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangcoso = moment().subtract(1, 'month').endOf('month').format("MM/DD/YYYY hh:mm:ss A");
                $scope.getcoso();
            }


        }
        $scope.getcoso = getcoso;

        function getcoso() {
            $scope.labelscs = [];
            $scope.datacs = [
            ];
           // $scope.seriescs = [];
            var config = {
                params: {
                    ngaydau: dauthangcoso,
                    ngaycuoi: cuoithangcoso,
                    dathaydoi: false
                }
            }

            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthutheoselectcs = 0;
                var result1 = [];
                result.data.forEach(function (b) {
                    var newresult = [];
                    b.ChungTuBanHang.forEach(function (a) {
                        $scope.danhthutheoselectcs += a.TongTienThanhToan;
                        a.NgayChungTu = $filter('date')(a.NgayChungTu, 'dd');
                        if (!this[a.NgayChungTu]) {
                            this[a.NgayChungTu] = { NgayChungTu: a.NgayChungTu, TongTienThanhToan: 0 };
                            newresult.push(this[a.NgayChungTu]);
                        }
                        this[a.NgayChungTu].TongTienThanhToan += a.TongTienThanhToan;
                    }, Object.create(null));
                    result1.push(newresult);
                    $scope.labelscs.push(b.TenCoSo);
                   // $scope.seriescs.push(b.TenCoSo);


                });

                $scope.newketqua = [];
                var tencoso = []
                angular.forEach(result1, function (item) {
                    var ketqua = 0;
                    angular.forEach(item, function (a) {
                        ketqua+=(a.TongTienThanhToan);
                    })
                    $scope.datacs.push(ketqua)

                })

                //$.each(tencoso, function (i, el) {
                //    if ($.inArray(el, $scope.labels) === -1) $scope.labels.push(el);
                //});


            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.getcoso();

        //gettop10

        var dauthangtop10;
        var cuoithangtop10;
        dauthangtop10 = moment().startOf('month').format("MM/DD/YYYY hh:mm:ss A");
        cuoithangtop10 = moment().endOf('month').format("MM/DD/YYYY hh:mm:ss A");



        $scope.setupngay2 = function () {
            if ($scope.select2 == 'thangnay') {
                $scope.textselect2 = 'tháng này'
                dauthangtop10 = moment().startOf('month').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangtop10 = moment().endOf('month').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.orderby == "doanhthu") {
                    $scope.gettop10();                }
                else if ($scope.orderby == "soluong") {
                    $scope.getorderby();
                }
                
            }
            else if ($scope.select2 == 'homnay') {
                $scope.textselect2 = 'hôm nay'
                dauthangtop10 = moment().startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangtop10 = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.orderby == "doanhthu") {
                    $scope.gettop10();
                }
                else if ($scope.orderby == "soluong") {
                    $scope.getorderby();
                }            }
            else if ($scope.select2 == 'homqua') {
                $scope.textselect2 = 'hôm qua'
                dauthangtop10 = moment().subtract(1, 'day').startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangtop10 = moment().subtract(1, 'day').endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.orderby == "doanhthu") {
                    $scope.gettop10();
                }
                else if ($scope.orderby == "soluong") {
                    $scope.getorderby();
                }            }
            else if ($scope.select2 == '7ngayqua') {
                $scope.textselect2 = '7 ngày qua'
                dauthangtop10 = moment().subtract(6, 'day').startOf('day').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangtop10 = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.orderby == "doanhthu") {
                    $scope.gettop10();
                }
                else if ($scope.orderby == "soluong") {
                    $scope.getorderby();
                }
            }
            else if ($scope.select2 == 'thangtruoc') {
                $scope.textselect2 = 'tháng trước'
                dauthangtop10 = moment().subtract(1, 'month').startOf('month').format("MM/DD/YYYY hh:mm:ss A");
                cuoithangtop10 = moment().subtract(1, 'month').endOf('month').format("MM/DD/YYYY hh:mm:ss A");
                if ($scope.orderby == "doanhthu") {
                    $scope.gettop10();
                }
                else if ($scope.orderby == "soluong") {
                    $scope.getorderby();
                }            }


        }
        $scope.gettop10 = gettop10;



        $scope.orderby = "doanhthu";


        function gettop10() {
            $scope.datatop10 = [];
            $scope.labelstop10 = [
            ];
            // $scope.seriescs = [];
            var config = {
                params: {
                    ngaydau: dauthangtop10,
                    ngaycuoi: cuoithangtop10,
                    dathaydoi: false,
                    orderby: $scope.orderby,
                }
            }

            apiService.get('/api/chitietchungtubanhang/getthongkechitiet', config, function (result) {
                angular.forEach(result.data, function (item) {
                    $scope.datatop10.push(item.ThanhTien);
                    $scope.labelstop10.push(item.TenHang+' ('+item.TenDonViTinh+')')
                })
             

            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.gettop10();



        $scope.getorderby = function () {
            $scope.datatop10 = [];
            $scope.labelstop10 = [
            ];
            // $scope.seriescs = [];
            var config = {
                params: {
                    ngaydau: dauthangtop10,
                    ngaycuoi: cuoithangtop10,
                    dathaydoi: false,
                    orderby: $scope.orderby,
                }
            }

            apiService.get('/api/chitietchungtubanhang/getthongkechitiet', config, function (result) {
                angular.forEach(result.data, function (item) {
                    $scope.datatop10.push(item.SoLuong);
                    $scope.labelstop10.push(item.TenHang + ' (' + item.TenDonViTinh + ')')
                })


            }, function () {
                console.log('Load  failed.');
            });
        }











        //setting bieudo
        function numFormatter(num) {
            if (num > 999 && num < 1000000) {
                return (num / 1000).toFixed(1) + 'k'; 
            } else if (num > 1000000) {
                return (num / 1000000).toFixed(1) + 'tr';  
            } else if (num < 900) {
                return num; 
            }
        }
        function truncate(input) {
            if (input.length > 20) {
                return input.substring(0, 20) + '...';
            }
            return input;
        }



        $scope.labels = [];
       

        $scope.data = [
           
        ];
        $scope.options = {
           
            legend: {
                display: true,
                position: 'bottom'
            }, tooltips: {
               
                callbacks: {
                    label: function (tooltipItem, data) {
                        var tooltipValue = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        return parseInt(tooltipValue).toLocaleString();
                    }
                }
            },
            scales: {
                yAxes: [{
                    
                    ticks: {
                        callback: function (value, index, values) {
                          
                            return numFormatter(value);
                        },
                        
                    },

                }],
            },


            responsive: true,
             

        }
        //$scope.colors = [
        //    {
        //        backgroundColor: ["rgba(170, 25, 33, 1)","rgba(170, 25, 33, 2)","rgba(170, 25, 33, 3)"]
                
        //    }
        //];


        $scope.optionstop10 = {

           tooltips: {

                callbacks: {
                    label: function (tooltipItem, data) {
                        var tooltipValue = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        return parseInt(tooltipValue).toLocaleString();
                    }
                }
            },
            scales: {
                xAxes: [{

                    ticks: {
                        callback: function (value, index, values) {

                            return numFormatter(value);
                        },

                    }
                }],
                
                 yAxes: [{

                    ticks: {
                        callback: function (value, index, values) {

                            return truncate(value);
                        },

                    }
                }],
                

            },
           
            

            responsive: true,

        }
        $scope.optionscs = {

            legend: {
                display: true,
                position: 'bottom'
            }, tooltips: {

                callbacks: {
                    label: function (tooltipItem, data) {
                        var tooltipValue = data.datasets[tooltipItem.datasetIndex].data[tooltipItem.index];
                        return parseInt(tooltipValue).toLocaleString();
                    }
                }
            },
            

            responsive: true,

        }

       
        ////////////////timeline
        $scope.CoSo ="";
       function getcosonv () {
            var config = {
                params: {
                    msnv: $scope.authentication.userName,
                }
            }
            apiService.get('/api/nhanvien/getbymsnv', config, function (result) {
                $scope.CoSo = result.data[0].MaCoSo
            }, function () {
                console.log('Load  failed.');
            });
        }
        getcosonv();











        $scope.timeline = [];
        function gettimeline() {
            apiService.get('/api/chungtubanhang/getlichsu', null, function (result) {
                if ($scope.authentication.ChucVu[0].MaChucVu==59) {
                    $scope.timeline = $filter('filter')(result.data, {
                        MaSoNhanVien: $scope.authentication.userName
                    });
                }
                else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                    $scope.timeline = $filter('filter')(result.data, {
                        MaCoSo: $scope.CoSo
                    });
                }
                else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                    $scope.timeline = result.data
                    
                }

                angular.forEach($scope.timeline, function (item) {
                    if (item.Tien!=null) {
                        item.Tien = parseInt(item.Tien).toLocaleString();

                    }
                })

            }, function () {
                console.log('Load  failed.');
            });
        }
        gettimeline();

        $scope.gettentimeline = function (ten) {
            var updateten = "";
            if (ten.indexOf("NK")>-1) {
                updateten = "nhập kho";
            }
            else if (ten.indexOf("BH") > -1) {
                updateten = "bán hàng";
            }
            else{
                updateten = "nhập hàng";
            }

            return updateten;
        }
        
    }
   
    
})(angular.module('platformTH_GV.tongquan'));