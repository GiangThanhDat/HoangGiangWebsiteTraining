(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService', 'apiService', '$q', '$timeout'];

    function rootController($state, authData, loginService, $scope, authenticationService, apiService, $q, $timeout) {
        $scope.logOut = function () {
            loginService.logOut();
            $state.go('dangnhap');
           
        }
        $scope.authentication = authData.authenticationData;
        $scope.link = $state.current.path

        
        $scope.kiemtrarole = function (name) {
            var a;
            angular.forEach(authData.authenticationData.nameRoles, function (item) {
                if (item.Name == name) {
                    a=item.Name
                }
            });
            return a
        }

        
       

    }
    app.run(function ($rootScope, $interval, apiService,$q) {

      
        $interval(function () {
            var date = new Date();
            if (date.getHours() == 19 && date.getMinutes() == 08 && date.getSeconds()==0) {
                getquetthetheongay();
                getquetthe();
                getallnv();
            }
            //console.log(date.getDate() + "  " + date.getHours() + "   " + date.getMinutes() + "   " + date.getSeconds())
        }, 1000);


      
      var AllQuetTheTheoNgay = [];
        var allNhanVien = [];
      var AllQuetThe = [];

        function getquetthetheongay() {
            apiService.get('/api/quetthetheongay/getall', null, function (result) {
                
                 AllQuetTheTheoNgay = result.data;
                themquetquetthe();
               
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        function getquetthe() {
            apiService.get('/api/quetthe/getall', null, function (result) {

                 AllQuetThe = result.data;
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }

        function themquetquetthe() {
            //if (AllQuetThe.length>1) {
            //    for (var i = 0; i < AllQuetTheTheoNgay.length; i++) {
            //        var a = new Date(AllQuetTheTheoNgay[i].NgayQuetThe).getTime();
            //        var b = new Date(AllQuetThe[i].NgayQuetThe).getTime();

            //        if (a != b) {
            //            apiService.post('/api/quetthe/create', AllQuetTheTheoNgay[i], function (result) {
            //                console.log('Them thanh cong');

            //            }, function () {
            //                console.log('Tải thông tin thất bại');
            //            });
            //        }
            //    }
            //}
            //else {
                apiService.post('/api/quetthe/create', AllQuetTheTheoNgay, function (result) {
                    console.log('Thêm quét thẻ thành công');

                }, function () {
                    console.log('Tải thông tin thất bại');
                });
            //}

        }
        function getallnv() {
            apiService.get('/api/nhanvien/getall', null, function (result) {
                allNhanVien = result.data;
                kiemtravang();
            }, function () {
                console.log('Tải thông tin thất bại');
            });
        }
        function kiemtravang() {

            var mangmoi = [];
            var promises = [];

            angular.forEach(allNhanVien, function (item) {
                var defer = $q.defer();
                var config = {
                    params: {
                        id: item.MaSoNhanVien
                    }
                }
                apiService.get('/api/quetthetheongay/checkvangmat', config, function (result) {
                    if (result.data == null) {
                       mangmoi.push({ MaSoNhanVien: item.MaSoNhanVien });



                    }
                    defer.resolve(item);
                }, function () {
                    console.log('Tải thông tin thất bại');
                });
                promises.push(defer.promise);

            })
            $q.all(promises).then(function () {
                apiService.post('/api/quanlyvangmat/create', mangmoi, function (result) {
                    console.log('Thêm nhân viên vắng thành công');

                }, function () {
                    console.log('Tải thông tin thất bại');
                });


            });


        }





       

    });
})(angular.module('platformTH_GV'));

