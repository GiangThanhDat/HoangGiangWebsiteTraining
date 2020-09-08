/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.application_roles', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');
    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('application_roles', {
            url: "/application_roles",
            templateUrl: "/app/conponents/application_roles/applicationRoleListView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "applicationRoleListController"
        })
            .state('add_application_role', {
                url: "/add_application_role",
                parent: 'base',
                templateUrl: "/app/conponents/application_roles/applicationRoleAddView.html?v=" + window.appVersion,
                controller: "applicationRoleAddController"
            })
            .state('edit_application_role', {
                url: "/edit_application_role/:id",
                templateUrl: "/app/conponents/application_roles/applicationRoleEditView.html?v=" + window.appVersion,
                controller: "applicationRoleEditController",
                parent: 'base',
            });
    }
})();