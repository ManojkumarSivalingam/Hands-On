require.config({
    baseUrl: '/js',
    paths: {
        'angular': '/scripts/angular.min',
        'ngRoute': '/scripts/angular-route.min',
        'ngResource': '/scripts/angular-resource.min',
        'jquery': '/scripts/jquery-1.10.2.min',
        'bootstrap': '/scripts/bootstrap.min',
        'd3': '/scripts/d3/d3.min',
        'c3': '/scripts/c3.min',
        'ngRadialGauge': '/scripts/ng-radial-gauge-dir'
    },
    shim: {
        'angular': {
            exports: 'angular'
        },
        'ngRoute': {
            deps: ['angular'],
            exports: 'ngRoute'
        },
        'ngResource': {
            deps: ['angular'],
            exports: 'ngResource'
        },
        'jquery': {
            exports: 'jquery'
        },
        'bootstrap': {
            deps: ['jquery'],
            exports: 'bootstrap'
        },
        'd3': {
            exports: 'd3'
        },
        'c3': {
            deps: ['d3'],
            exports: 'c3'
        },
        'ngRadialGauge': {
            deps: ['angular', 'd3'],
            exports: 'ngRadialGauge'
        },
        'app': {
            deps: ['angular', 'ngRoute', 'ngResource', 'ngRadialGauge', 'c3', 'bootstrap'],
            exports: 'app'
        }
    }
});

require(['app'], function () {
    angular.element(document).ready(
        function () {
            angular.bootstrap(document, ['Aditi.SPA.App']);
        });
});