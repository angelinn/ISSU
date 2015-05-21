var susiApp;
(function (susiApp) {
    var Controllers;
    (function (Controllers) {
        'use strict';
        var HomeController = (function () {
            function HomeController($scope, homeService) {
                this.scope = $scope;
                this.homeService = homeService;
                this.addArticlesToScope();
                this.addWebsitesToScope();
            }
            HomeController.prototype.addArticlesToScope = function () {
                var _this = this;
                this.homeService.getArticles().then(function (data) {
                    _this.scope['articles'] = data;
                    console.log(data);
                });
            };
            HomeController.prototype.addWebsitesToScope = function () {
                var _this = this;
                this.homeService.getWebsites().then(function (data) {
                    _this.scope['websites'] = data;
                });
            };
            HomeController.$inject = ["$scope", 'susiApp.Services.HomeService'];
            return HomeController;
        })();
        Controllers.HomeController = HomeController;
        var NewsController = (function () {
            function NewsController($scope, newsService) {
                this.scope = $scope;
                this.newsService = newsService;
                this.getFirstFew();
            }
            NewsController.prototype.getFirstFew = function () {
                var _this = this;
                this.newsService.getFirstFew().then(function (data) {
                    _this.scope['articles'] = data;
                });
            };
            NewsController.prototype.getArticle = function (id) {
                var _this = this;
                this.newsService.getArticle(id).then(function (data) {
                    _this.scope['currentArticle'] = data;
                });
            };
            NewsController.$inject = ['$scope', 'susiApp.Services.NewsService'];
            return NewsController;
        })();
        Controllers.NewsController = NewsController;
        angular.module('susiApp').controller('susiApp.Controllers.HomeController', HomeController).controller('susiApp.Controllers.NewsController', NewsController);
    })(Controllers = susiApp.Controllers || (susiApp.Controllers = {}));
})(susiApp || (susiApp = {}));
//# sourceMappingURL=susiApp.controllers.js.map