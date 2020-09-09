(function (app) {
    'use strict';
    app.factory('authData', [function () {
        var authDataFactory = {};

        var authentication = {
            IsAuthenticated: false,
            userName: "",
            fullName: "",
            email: "",
            nameRoles: "",
            ChucVu: "",
        };

        authDataFactory.authenticationData = authentication;

        return authDataFactory;
    }]);
})(angular.module('platformTH_GV.common'));