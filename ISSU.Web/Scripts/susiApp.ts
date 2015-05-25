((): void => {
    'use strict';
    angular.module('susiApp', ['ngRoute'])
        .config(susiApp.Routes.HomeRoutes.configureRoutes)
        .config(susiApp.Routes.NewsRoutes.configureRoutes)
        .config(susiApp.Routes.SUSIRoutes.configureRoutes);   
})();