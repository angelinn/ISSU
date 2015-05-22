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
        var SUSIUserController = (function () {
            function SUSIUserController($scope, susiService) {
                this.scope = $scope;
                this.susiService = susiService;
                this.getUserInfo();
            }
            SUSIUserController.prototype.getUserInfo = function () {
                var _this = this;
                this.susiService.getStudentInfo().then(function (data) {
                    _this.scope['user'] = data;
                });
            };
            SUSIUserController.$inject = ['$scope', 'susiApp.Services.SUSIService'];
            return SUSIUserController;
        })();
        Controllers.SUSIUserController = SUSIUserController;
        var SUSICoursesController = (function () {
            function SUSICoursesController($scope, susiService) {
                this.scope = $scope;
                this.susiService = susiService;
                this.getCourses();
            }
            SUSICoursesController.prototype.getCourses = function () {
                var _this = this;
                this.susiService.getCourses().then(function (data) {
                    _this.scope['courses'] = data;
                    console.log(data);
                });
            };
            SUSICoursesController.$inject = ['$scope', 'susiApp.Services.SUSIService'];
            return SUSICoursesController;
        })();
        Controllers.SUSICoursesController = SUSICoursesController;
        angular.module('susiApp').controller('susiApp.Controllers.HomeController', HomeController).controller('susiApp.Controllers.NewsController', NewsController).controller('susiApp.Controllers.SUSIUserController', SUSIUserController).controller('susiApp.Controllers.SUSICoursesController', SUSICoursesController);
    })(Controllers = susiApp.Controllers || (susiApp.Controllers = {}));
})(susiApp || (susiApp = {}));
//# sourceMappingURL=susiApp.controllers.js.map