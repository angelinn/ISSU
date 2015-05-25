var susiApp;
(function (susiApp) {
    var Routes;
    (function (Routes) {
        var HomeRoutes = (function () {
            function HomeRoutes() {
            }
            HomeRoutes.configureRoutes = function ($routeProvider) {
                $routeProvider.when('/latest', { controller: 'susiApp.Controllers.HomeController', controllerAs: 'home', templateUrl: '/Home/IndexPartial' });
                $routeProvider.when('/websites', { controller: 'susiApp.Controllers.HomeController', controllerAs: 'home', templateUrl: '/Home/WebsitesPartial' });
                $routeProvider.when('/contact', { controller: 'susiApp.Controllers.HomeController', controllerAs: 'home', templateUrl: '/Home/ContactPartial' });
                $routeProvider.otherwise({ redirectTo: '/latest' });
            };
            HomeRoutes.$inject = ['$routeProvider'];
            return HomeRoutes;
        })();
        Routes.HomeRoutes = HomeRoutes;
        var NewsRoutes = (function () {
            function NewsRoutes() {
            }
            NewsRoutes.configureRoutes = function ($routeProvider) {
                $routeProvider.when('/news', { controller: 'susiApp.Controllers.NewsController', controllerAs: 'news', templateUrl: '/News/IndexPartial' });
                $routeProvider.when('/article/:id', { controller: 'susiApp.Controllers.NewsController', controllerAs: 'news', templateUrl: '/News/ArticlePartial' });
            };
            NewsRoutes.$inject = ['$routeProvider'];
            return NewsRoutes;
        })();
        Routes.NewsRoutes = NewsRoutes;
        var SUSIRoutes = (function () {
            function SUSIRoutes() {
            }
            SUSIRoutes.configureRoutes = function ($routeProvider) {
                $routeProvider.when('/susi', { templateUrl: '/SUSI/SUSIPartial' });
                $routeProvider.when('/student/about', { controller: 'susiApp.Controllers.SUSIUserController', controllerAs: 'susi', templateUrl: '/SUSI/AboutPartial' });
                $routeProvider.when('/student/courses', { controller: 'susiApp.Controllers.SUSICoursesController', controllerAs: 'susi', templateUrl: '/SUSI/CoursesPartial' });
            };
            SUSIRoutes.$inject = ['$routeProvider'];
            return SUSIRoutes;
        })();
        Routes.SUSIRoutes = SUSIRoutes;
    })(Routes = susiApp.Routes || (susiApp.Routes = {}));
})(susiApp || (susiApp = {}));
//# sourceMappingURL=susiApp.routes.js.map