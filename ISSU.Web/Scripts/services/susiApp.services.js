var susiApp;
(function (susiApp) {
    var Services;
    (function (Services) {
        'use strict';
        var HomeService = (function () {
            function HomeService($http, $q) {
                this.httpService = $http;
                this.qService = $q;
            }
            HomeService.prototype.getArticles = function () {
                var defer = this.qService.defer();
                this.httpService.get('api/home?index=1', {
                    responseType: 'json'
                }).then(function (response) {
                    defer.resolve(response.data);
                });
                return defer.promise;
            };
            HomeService.prototype.getWebsites = function () {
                var defer = this.qService.defer();
                this.httpService.get('api/home?websites=1', {
                    responseType: 'json'
                }).then(function (response) {
                    defer.resolve(response.data);
                });
                return defer.promise;
            };
            HomeService.$inject = ['$http', '$q'];
            return HomeService;
        })();
        Services.HomeService = HomeService;
        var NewsService = (function () {
            function NewsService($http, $q) {
                this.httpService = $http;
                this.qService = $q;
            }
            NewsService.prototype.getFirstFew = function () {
                var defer = this.qService.defer();
                this.httpService.get('/api/news', {
                    responseType: 'json'
                }).then(function (response) {
                    defer.resolve(response.data);
                });
                return defer.promise;
            };
            NewsService.prototype.getArticle = function (id) {
                var defer = this.qService.defer();
                this.httpService.get('api/article?id=' + id, {
                    responseType: 'json'
                }).then(function (response) {
                    defer.resolve(response.data);
                });
                return defer.promise;
            };
            NewsService.$inject = ['$http', '$q'];
            return NewsService;
        })();
        Services.NewsService = NewsService;
        var SUSIService = (function () {
            function SUSIService($http, $q) {
                this.httpService = $http;
                this.qService = $q;
            }
            SUSIService.prototype.getStudentInfo = function () {
                var defer = this.qService.defer();
                this.httpService.get('/api/susi', {
                    responseType: 'json'
                }).then(function (response) {
                    defer.resolve(response.data);
                });
                return defer.promise;
            };
            SUSIService.prototype.getCourses = function () {
                var defer = this.qService.defer();
                this.httpService.get('api/susi?courses', {
                    responseType: 'json'
                }).then(function (response) {
                    defer.resolve(response.data);
                });
                return defer.promise;
            };
            SUSIService.$inject = ['$http', '$q'];
            return SUSIService;
        })();
        Services.SUSIService = SUSIService;
        angular.module('susiApp').service('susiApp.Services.HomeService', HomeService).service('susiApp.Services.NewsService', NewsService).service('susiApp.Services.SUSIService', SUSIService);
    })(Services = susiApp.Services || (susiApp.Services = {}));
})(susiApp || (susiApp = {}));
//# sourceMappingURL=susiApp.services.js.map