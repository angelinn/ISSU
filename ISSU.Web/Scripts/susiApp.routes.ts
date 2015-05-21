module susiApp.Routes {

    export class HomeRoutes {
        static $inject = ['$routeProvider'];
        static configureRoutes($routeProvider: ng.route.IRouteProvider) {
            $routeProvider.when('/latest', { controller: 'susiApp.Controllers.HomeController', controllerAs: 'home', templateUrl: '/Home/IndexPartial' });
            $routeProvider.when('/websites', { controller: 'susiApp.Controllers.HomeController', controllerAs: 'home', templateUrl: '/Home/WebsitesPartial' });
            $routeProvider.when('/contact', { controller: 'susiApp.Controllers.HomeController', controllerAs: 'home', templateUrl: '/Home/ContactPartial' });
            $routeProvider.otherwise({ redirectTo: '/latest' });
        }
    }

    export class NewsRoutes {
        static $inject = ['$routeProvider'];
        static configureRoutes($routeProvider: ng.route.IRouteProvider) {
            $routeProvider.when('/news', { controller: 'susiApp.Controllers.NewsController', controllerAs: 'news', templateUrl: '/News/IndexPartial' });
            $routeProvider.when('/article/:id', { controller: 'susiApp.Controllers.NewsController', controllerAs: 'news', templateUrl: '/News/ArticlePartial' });
        }
    }

    export class SUSIRoutes {
        static $inject = ['routeProvider'];
        static configureRoutes($routeProvider: ng.route.IRouteProvider) {
            $routeProvider.when('/susi', { controller: 'susiApp.Controllers.SUSIController', controllerAs: 'susi', templateUrl: '/SUSI/SUSIPartial' });
            $routeProvider.when('/student/about', { controller: 'susiApp.Controllers.SUSIController', controllerAs: 'susi', templateUrl: '/SUSI/AboutPartial' });
            $routeProvider.when('/student/courses', { controller: 'susiApp.Controllers.SUSIController', controllerAs: 'susi', templateUrl: '/SUSI/CourseSPartial' });
        }
    }
}