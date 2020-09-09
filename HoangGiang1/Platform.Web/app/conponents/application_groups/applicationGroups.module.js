/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('platformTH_GV.application_groups', ['platformTH_GV.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    window.appVersion = angular.element(document.getElementsByTagName('html')).attr('data-ver');

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('application_groups', {
            url: "/application_groups",
            templateUrl: "/app/conponents/application_groups/applicationGroupListView.html?v=" + window.appVersion,
            parent: 'base',
            controller: "applicationGroupListController"
        })
            .state('add_application_group', {
                url: "/add_application_group",
                parent: 'base',
                templateUrl: "/app/conponents/application_groups/applicationGroupAddView.html?v=" + window.appVersion,
                controller: "applicationGroupAddController"
            })
            .state('edit_application_group', {
                url: "/edit_application_group/:id",
                templateUrl: "/app/conponents/application_groups/applicationGroupEditView.html?v=" + window.appVersion,
                controller: "applicationGroupEditController",
                parent: 'base',
            });
    }
})();