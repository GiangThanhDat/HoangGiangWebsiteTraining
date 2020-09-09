/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.application_users', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('application_users', {
            url: "/application_users",
            templateUrl: "/app/conponents/application_users/applicationUserListView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "applicationUserListController"
        })
            .state('add_application_user', {
                url: "/add_application_user",
                parent: 'base',
                templateUrl: "/app/conponents/application_users/applicationUserAddView.html?v=" + window.appVersion,
                controller: "applicationUserAddController"
            })
            .state('edit_application_user', {
                url: "/edit_application_user/:id",
                templateUrl: "/app/conponents/application_users/applicationUserEditView.html?v=" + window.appVersion,
                controller: "applicationUserEditController",
                parent: 'base',
            });
    }
})();