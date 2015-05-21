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
    })(Routes = susiApp.Routes || (susiApp.Routes = {}));
})(susiApp || (susiApp = {}));
//# sourceMappingURL=susiApp.routes.js.map