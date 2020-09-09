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
        $scope.CoSo = "";
        function getcosonv() {
            var config = {
                params: {
                    msnv: $scope.authentication.userName,
                }
            }
            apiService.get('/api/nhanvien/getbymsnv', config, function (result) {
                $scope.CoSo = result.data[0].MaCoSo;
                gethomnay();
                $scope.gettheongay();

            }, function () {
                console.log('Load  failed.');
            });
        }
        getcosonv();

        function maudepnhat(lenght){
            //var mau = [{ backgroundColor: "#fcba03" }, { backgroundColor: "#fc0303" }, "#41fc03", "#03fcf4", "#0341fc", "#ca03fc", "#fc03c6", "#7d3c59", "#7988e8", "#fcb89d", "#cdfc86", "#185e1c", "#4ad4bf", "#41617a", "#6408a1"]
            var newmau = [];
            var mau = [{ backgroundColor: "#fcba03" }, { backgroundColor: "#fc0303" }, { backgroundColor: "#41fc03" }, { backgroundColor: "#03fcf4" }, { backgroundColor: "#0341fc" }, { backgroundColor: "#ca03fc" }, { backgroundColor: "#fc03c6" }, { backgroundColor: "#7d3c59" }, { backgroundColor: "#7988e8" }, { backgroundColor: "#fcb89d" }, { backgroundColor: "#cdfc86" }, { backgroundColor: "#185e1c" }, { backgroundColor: "#4ad4bf" }, { backgroundColor: "#41617a" }, { backgroundColor: "#6408a1" },]
            for (var i = 0; i < lenght; i++) {
                newmau.push(mau[i])
            }
            return newmau;
        }
        
       







        $scope.nhanvienchartbar = [{ MaSoNhanVien: "", HoVaTen: "Xem tất cả" }]
        $scope.cosochartbar = [{ MaCoSo: "", TenCoSo: "Xem tất cả" }]
        function gettheongay() {
            $scope.labels = [];
            $scope.series = [];

            $scope.data = [
            ];
           
            


            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locnhanvienchartbar == undefined || $scope.locnhanvienchartbar =="") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locnhanvienchartbar;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.loccosochartbar == undefined || $scope.loccosochartbar == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.loccosochartbar;
                    manv = "";
                }
            }


            var config = {
                params: {
                    ngaydau: dauthang,
                    ngaycuoi: cuoithang,
                    dathaydoi: false,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
                }
            }
            
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthutheoselect = 0;
                var result1 = [];
                if (result.data.length > 0) {
                    $scope.isDataAvaiablebar = true;
                }
                else {
                    $scope.isDataAvaiablebar = false;

                }
                angular.forEach(result.data,function (b) {
                    var newresult = [];
                    angular.forEach(b.ChungTuBanHang,function (a) {
                       
                        $scope.danhthutheoselect += a.TongTienThanhToan;
                        $scope.nhanvienchartbar.push({ MaSoNhanVien: a.MaSoNhanVien, HoVaTen: a.HoVaTen });
                        $scope.cosochartbar.push({ MaCoSo: a.MaCoSo, TenCoSo: a.TenCoSo });

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
                //random color
                function dynamicColors() {
                    var r = Math.floor(Math.random() * 255);
                    var g = Math.floor(Math.random() * 255);
                    var b = Math.floor(Math.random() * 255);
                    //var b = 100;
                    return { backgroundColor: "rgba(" + r + "," + g + "," + b + ", 0.5)" };
                    //var letters = '012345'.split('');
                    //var color = '#';
                    //color += letters[Math.round(Math.random() * 5)];
                    //letters = '0123456789ABCDEF'.split('');
                    //for (var i = 0; i < 5; i++) {
                    //    color += letters[Math.round(Math.random() * 15)];
                    //}
                    //var lum = -0.25;
                    //var hex = String('#' + Math.random().toString(16).slice(2, 8).toUpperCase()).replace(/[^0-9a-f]/gi, '');
                    //if (hex.length < 6) {
                    //    hex = hex[0] + hex[0] + hex[1] + hex[1] + hex[2] + hex[2];
                    //}
                    //var rgb = "#",
                    //    c, i;
                    //for (i = 0; i < 3; i++) {
                    //    c = parseInt(hex.substr(i * 2, 2), 16);
                    //    c = Math.round(Math.min(Math.max(0, c + (c * lum)), 255)).toString(16);
                    //    rgb += ("00" + c).substr(c.length);
                    //}
                    //return { backgroundColor: rgb }
                }
                function poolColors(a) {
                    var pool = [];
                    if (a <= 15) {
                        pool = maudepnhat(a)
                    }
                    else {
                        var c = [];
                        for (var i = 0; i < a - 15; i++) {
                            c.push(dynamicColors());
                        }
                        var d = maudepnhat(15)
                        pool = d.concat(c);
                    }
                    return pool;
                }



                $scope.colors = poolColors($scope.series.length)


                //console.log($scope.colors)
                



                

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
        $scope.filterchartbar = function () {
            if ($scope.theongay == true) {
                $scope.gettheongay();
            }
            else if ($scope.theogio == true) {
                $scope.gettheogio();
            }
            else if ($scope.theothu == true) {
                $scope.gettheothu();
            }

        }

        ///top
       



        $scope.nhanvienhomnay = [{ MaSoNhanVien: "", HoVaTen: "Xem tất cả" }]
        $scope.cosohomnay = [{ MaCoSo: "", TenCoSo: "Xem tất cả" }]

        function gethomnay() {
            var sang = moment().startOf('day').format("MM/DD/YYYY hh:mm:ss A");
            var toi = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");

            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locdoanthutheonhanvien == undefined || $scope.locdoanthutheonhanvien == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locdoanthutheonhanvien;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.locdoanthutheocoso == undefined || $scope.locdoanthutheocoso == "") {
                    manv = "";
                    macoso ="";
                }
                else {
                    macoso = $scope.locdoanthutheocoso;
                    manv = "";
                }
            }



            var config = {
                params: {
                    ngaydau: sang,
                    ngaycuoi: toi,
                    dathaydoi: false,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
                }
            }
           
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.demhoadon = 0;
                $scope.danhthuhomnay = 0;
                angular.forEach(result.data, function (item) {
                    angular.forEach(item.ChungTuBanHang, function (i) {
                        $scope.demhoadon += 1;
                        $scope.danhthuhomnay += i.TongTienThanhToan;
                        $scope.nhanvienhomnay.push({ MaSoNhanVien: i.MaSoNhanVien, HoVaTen: i.HoVaTen });
                        $scope.cosohomnay.push({ MaCoSo: i.MaCoSo, TenCoSo: i.TenCoSo });
                    })
                })
               
            }, function () {
                console.log('Load  failed.');
            });
        }
        
        $scope.filtertheocoso = function () {
            gethomnay();
            getthangnay();
            gettrahang();

        }
        $scope.filtertheogiamdoc = function () {
            gethomnay();
            getthangnay();
            gettrahang();
        }


        function gettrahang() {
            var sang = moment().startOf('day').format("MM/DD/YYYY hh:mm:ss A");
            var toi = moment().endOf('day').format("MM/DD/YYYY hh:mm:ss A");

            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locdoanthutheonhanvien == undefined || $scope.locdoanthutheonhanvien == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locdoanthutheonhanvien;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.locdoanthutheocoso == undefined || $scope.locdoanthutheocoso == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.locdoanthutheocoso;
                    manv = "";
                }
            }



            var config = {
                params: {
                    ngaydau: sang,
                    ngaycuoi: toi,
                    dathaydoi: true,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
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
             var manv;
             var macoso;
             if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                 manv = $scope.authentication.userName;
                 macoso = "";
             }
             else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                 if ($scope.locdoanthutheonhanvien == undefined || $scope.locdoanthutheonhanvien == "") {
                     manv = "";
                     macoso = $scope.CoSo;
                 }
                 else {
                     manv = $scope.locdoanthutheonhanvien;
                     macoso = $scope.CoSo;
                 }
             }
             else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                 if ($scope.locdoanthutheocoso == undefined || $scope.locdoanthutheocoso == "") {
                     manv = "";
                     macoso = "";
                 }
                 else {
                     macoso = $scope.locdoanthutheocoso;
                     manv = "";
                 }
             }



             var config = {
                 params: {
                     ngaydau: sang,
                     ngaycuoi: toi,
                     dathaydoi: false,
                     machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                     manv: manv,
                     macoso: macoso,
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
            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locdoanthutheonhanvien == undefined || $scope.locdoanthutheonhanvien == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locdoanthutheonhanvien;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.locdoanthutheocoso == undefined||$scope.locdoanthutheocoso == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.locdoanthutheocoso;
                    manv = "";
                }
            }



            var config = {
                params: {
                    ngaydau: sang,
                    ngaycuoi: toi,
                    dathaydoi: false,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthuhomthangtruoc = 0;
                if (result.data.length>0) {
                    angular.forEach(result.data, function (item) {
                        angular.forEach(item.ChungTuBanHang, function (i) {
                            $scope.danhthuhomthangtruoc += i.TongTienThanhToan
                        })
                    })
                }
               
            }, function () {
                console.log('Load  failed.');
            });
        }
        function getthangnay() {
            var dauthang1 = moment().startOf('month').format("MM/DD/YYYY hh:mm:ss A");
            var cuoithang1 = moment().format("MM/DD/YYYY hh:mm:ss A");

            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locdoanthutheonhanvien == undefined || $scope.locdoanthutheonhanvien == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locdoanthutheonhanvien;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.locdoanthutheocoso == undefined || $scope.locdoanthutheocoso == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.locdoanthutheocoso;
                    manv = "";
                }
            }



            var config = {
                params: {
                    ngaydau: dauthang1,
                    ngaycuoi: cuoithang1,
                    dathaydoi: false,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
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
            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locnhanvienchartbar == undefined || $scope.locnhanvienchartbar == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locnhanvienchartbar;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.loccosochartbar == undefined || $scope.loccosochartbar == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.loccosochartbar;
                    manv = "";
                }
            }
            var config = {
                params: {
                    ngaydau: dauthang,
                    ngaycuoi: cuoithang,
                    dathaydoi: false,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
                }
            }

            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthutheoselect = 0;
                var result1 = [];
                if (result.data.length > 0) {
                    $scope.isDataAvaiablebar = true;
                }
                else {
                    $scope.isDataAvaiablebar = false;

                }
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
            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locnhanvienchartbar == undefined || $scope.locnhanvienchartbar == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locnhanvienchartbar;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.loccosochartbar == undefined || $scope.loccosochartbar == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.loccosochartbar;
                    manv = "";
                }
            }
            var config = {
                params: {
                    ngaydau: dauthang,
                    ngaycuoi: cuoithang,
                    dathaydoi: false,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
                }
            }
            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthutheoselect = 0;
                if (result.data.length > 0) {
                    $scope.isDataAvaiablebar = true;
                }
                else {
                    $scope.isDataAvaiablebar = false;

                }
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

        $scope.nhanvienchartpie = [{ MaSoNhanVien: "", HoVaTen: "Xem tất cả" }]
        $scope.cosochartpie = [{ MaCoSo: "", TenCoSo: "Xem tất cả" }]

        function getcoso() {
            $scope.labelscs = [];
            $scope.datacs = [
            ];
           // $scope.seriescs = [];
            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locnhanvienchartpie == undefined || $scope.locnhanvienchartpie == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locnhanvienchartpie;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.loccosochartpie == undefined || $scope.loccosochartpie == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.loccosochartpie;
                    manv = "";
                }
            }


            var config = {
                params: {
                    ngaydau: dauthangcoso,
                    ngaycuoi: cuoithangcoso,
                    dathaydoi: false,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
                }
            }

            apiService.get('/api/chungtubanhang/gettheongay', config, function (result) {
                $scope.danhthutheoselectcs = 0;
                var result1 = [];
                if (result.data.length > 0) {
                    $scope.isDataAvaiablepie = true;
                }
                else {
                    $scope.isDataAvaiablepie = false;

                }
                 

                result.data.forEach(function (b) {
                    var newresult = [];
                    b.ChungTuBanHang.forEach(function (a) {
                        $scope.danhthutheoselectcs += a.TongTienThanhToan;
                        $scope.nhanvienchartpie.push({ MaSoNhanVien: a.MaSoNhanVien, HoVaTen: a.HoVaTen });
                        $scope.cosochartpie.push({ MaCoSo: a.MaCoSo, TenCoSo: a.TenCoSo });
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
        $scope.filterchartpie = function () {
            $scope.getcoso();
        }
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
        $scope.nhanviencharttop10 = [{ MaSoNhanVien: "", HoVaTen: "Xem tất cả" }]
        $scope.cosocharttop10 = [{ MaCoSo: "", TenCoSo: "Xem tất cả" }]


        function gettop10() {
            $scope.datatop10 = [];
            $scope.labelstop10 = [
            ];
            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locnhanviencharttop10 == undefined || $scope.locnhanviencharttop10 == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locnhanviencharttop10;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.loccosocharttop10 == undefined || $scope.loccosocharttop10 == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.loccosocharttop10;
                    manv = "";
                }
            }


            var config = {
                params: {
                    ngaydau: dauthangtop10,
                    ngaycuoi: cuoithangtop10,
                    dathaydoi: false,
                    orderby: $scope.orderby,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
                }
            }

            apiService.get('/api/chitietchungtubanhang/getthongkechitiet', config, function (result) {
                angular.forEach(result.data, function (item) {
                    $scope.nhanviencharttop10.push({ MaSoNhanVien: item.MaSoNhanVien, HoVaTen: item.HoVaTen })
                    $scope.cosocharttop10.push({ MaCoSo: item.MaCoSo, TenCoSo: item.TenCoSo })

                   
                    $scope.datatop10.push(item.ThanhTien);
                    $scope.labelstop10.push(item.TenHang+' ('+item.TenDonViTinh+')')
                })
                if (result.data.length>0) {
                    $scope.isDataAvaiabletop10 = true;
                }
                else {
                    $scope.isDataAvaiabletop10 = false;
 
                }
            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.gettop10();

       
        $scope.getorderby = function () {
            $scope.datatop10 = [];
            $scope.labelstop10 = [
            ];
            var manv;
            var macoso;
            if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
                manv = $scope.authentication.userName;
                macoso = "";
            }
            else if (78 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 79) {
                if ($scope.locnhanviencharttop10 == undefined || $scope.locnhanviencharttop10 == "") {
                    manv = "";
                    macoso = $scope.CoSo;
                }
                else {
                    manv = $scope.locnhanviencharttop10;
                    macoso = $scope.CoSo;
                }
            }
            else if (98 <= $scope.authentication.ChucVu[0].MaChucVu && $scope.authentication.ChucVu[0].MaChucVu <= 99) {
                if ($scope.loccosocharttop10 == undefined || $scope.loccosocharttop10 == "") {
                    manv = "";
                    macoso = "";
                }
                else {
                    macoso = $scope.loccosocharttop10;
                    manv = "";
                }
            }


            var config = {
                params: {
                    ngaydau: dauthangtop10,
                    ngaycuoi: cuoithangtop10,
                    dathaydoi: false,
                    orderby: $scope.orderby,
                    machucvu: $scope.authentication.ChucVu[0].MaChucVu,
                    manv: manv,
                    macoso: macoso,
                }
            }

            apiService.get('/api/chitietchungtubanhang/getthongkechitiet', config, function (result) {
                angular.forEach(result.data, function (item) {
                    $scope.nhanviencharttop10.push({ MaSoNhanVien: item.MaSoNhanVien, HoVaTen: item.HoVaTen })
                    $scope.cosocharttop10.push({ MaCoSo: item.MaCoSo, TenCoSo: item.TenCoSo })

                    if ($scope.orderby =="doanhthu") {
                        $scope.datatop10.push(item.ThanhTien);
                    }
                    else if ($scope.orderby == "soluong") {
                        $scope.datatop10.push(item.SoLuong);
                    }

                    $scope.labelstop10.push(item.TenHang + ' (' + item.TenDonViTinh + ')')
                })
                if (result.data.length > 0) {
                    $scope.isDataAvaiabletop10 = true;
                }
                else {
                    $scope.isDataAvaiabletop10 = false;

                }

            }, function () {
                console.log('Load  failed.');
            });
        }

        $scope.filtercharttop10 = function () {
            if ($scope.orderby == "doanhthu") {
                $scope.gettop10();
            }
            else if ($scope.orderby == "soluong") {
                $scope.getorderby();
            } 

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
                xAxes: [{
                    //barThickness: 30,  // number (pixels) or 'flex'
                   // maxBarThickness: 30 // number (pixels)
                }]
            },
            datasets: { bar: { maxBarThickness:30 } },





            responsive: true,
             

        }
        
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

                     },
                    // maxBarThickness: 30
                }],
                

            },
            datasets: { bar: { maxBarThickness: 30 } },
            

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
        










        $scope.cosotimeline = [{ MaCoSo: "", TenCoSo: "Xem tất cả" }];
        $scope.timeline = [];
        function gettimeline() {
            apiService.get('/api/chungtubanhang/getlichsu', null, function (result) {
                if ($scope.authentication.ChucVu[0].MaChucVu == 59) {
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
                    $scope.cosotimeline.push({ MaCoSo: item.MaCoSo, TenCoSo:item.TenCoSo })
                    
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








        ///get lý lịch nhân viên
        $scope.GetLyLichNhanVien=function (msnv) {
            var config = {
                params: {
                    msnv: msnv
                }
            }
            apiService.get('/api/nhanvien/getnhanVien', config, function (result) {

                $scope.LyLichNhanVien = result.data;
                var date1 = new Date($scope.LyLichNhanVien.NgayCapCMND);
                $scope.LyLichNhanVien.NgayCapCMND = $filter('date')(date1, "yyyy-MM-dd");
                var date1 = new Date($scope.LyLichNhanVien.NgaySinh);
                $scope.LyLichNhanVien.NgaySinh = $filter('date')(date1, "yyyy-MM-dd");


            }, function () {
                console.log('Load Thông tin  failed.');
            });

            var config2 = {
                params: {
                    msnv: msnv
                }
            }
            apiService.get('/api/nhanvien/getchucvu', config2, function (result) {
                $scope.LyLichNhanVien.TenChucVu = result.data.TenChucVu;

            }, function () {
                console.log('load không thành công.');
            });
        }
        $scope.getBanHang=function (mactbh) {
            var config = {
                params: {
                    mactbh: mactbh
                }
            }
            apiService.get('/api/chungtubanhang/getthongketimeline', config, function (result) {

                $scope.singer = result.data[0];
                $scope.singer.NgayChungTu = $filter('date')($scope.singer.NgayChungTu, "dd/MM/yyyy hh:mm:ss a");
                $scope.singer.NgayHoachToan = $filter('date')($scope.singer.NgayHoachToan, "dd/MM/yyyy hh:mm:ss a");
            }, function () {
                console.log('Load Thông tin  failed.');
            });

            var config2 = {
                params: {
                    MaChungTuBanHang: mactbh
                }
            }
            apiService.get('/api/chitietchungtubanhang/getchitietchungtubanhang', config2, function (result) {

                $scope.XemChiTiet = result.data;
               

                angular.forEach($scope.XemChiTiet, function (item) {
                    if (item.GiaKhuyenMai != null) {
                        item.GiaKhuyenMai = item.GiaKhuyenMai.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }
                    if (item.ThanhTien != null) {
                        item.ThanhTien = item.ThanhTien.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }
                    if (item.TienThueGTGT != null) {
                        item.TienThueGTGT = item.TienThueGTGT.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }
                    if (item.TienChietKhau != null) {
                        item.TienChietKhau = item.TienChietKhau.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                    }
                })
            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.getNhapHang = function (id) {
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('/api/hanghoa/getbyid', config, function (result) {
                $scope.singer3 = result.data;

                

            }, function () {
                console.log('Load  failed.');
            });
        }
        $scope.getNhapKho = function (mapnk) {
            var config = {
                params: {
                    mapnk: mapnk
                }
            }
            apiService.get('/api/phieunhapkho/getthongketimeline', config, function (result) {

                $scope.singer1 = result.data[0];
                $scope.singer1.NgayChungTu = $filter('date')($scope.singer1.NgayChungTu, "dd/MM/yyyy hh:mm:ss a");
                $scope.singer1.NgayHoachToan = $filter('date')($scope.singer1.NgayHoachToan, "dd/MM/yyyy hh:mm:ss a");
            }, function () {
                console.log('Load Thông tin  failed.');
            });

            var config2 = {
                params: {
                    MaPhieuNhapKho: mapnk
                }
            }
            apiService.get('/api/chitietphieunhapkho/getchitietxuatnhapkho', config2, function (result) {

                $scope.ChitietNK = result.data;
                angular.forEach($scope.ChitietNK, function (item) {

                    item.GiaKhuyenMai = item.GiaKhuyenMai.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
                })

            }, function () {
                console.log('Load  failed.');
            });
        }



    }
   
    
})(angular.module('platformTH_GV.tongquan'));