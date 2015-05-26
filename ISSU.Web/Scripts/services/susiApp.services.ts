module susiApp.Services {
    'use strict';

    export class HomeService {
        httpService: ng.IHttpService;
        qService: ng.IQService;

        static $inject = ['$http', '$q'];

        constructor($http: ng.IHttpService, $q: ng.IQService) {
            this.httpService = $http;
            this.qService = $q;
        }

        getArticles(): ng.IPromise<Array<susiApp.Models.IArticleViewModel>> {
            var defer = this.qService.defer<Array<susiApp.Models.IArticleViewModel>>();
            
            this.httpService.get<Array<susiApp.Models.IArticleViewModel>>(
                '/api/home?index=1', {
                    responseType: 'json'
                }).then((response) => {
                defer.resolve(response.data);
            });

            return defer.promise;
        }
        getWebsites(): ng.IPromise<Array<susiApp.Models.IWebsite>> {
            var defer = this.qService.defer<Array<susiApp.Models.IWebsite>>();

            this.httpService.get<Array<susiApp.Models.IWebsite>>(
                '/api/home?websites=1', {
                    responseType: 'json'
                }).then((response) => {
                defer.resolve(response.data);
            });

            return defer.promise;
        }
    }

    export class NewsService implements susiApp.Interfaces.INewsService {
        firstFew: Array<susiApp.Models.IArticleViewModel>;
        article: susiApp.Models.IArticleViewModel;
        httpService: ng.IHttpService;
        qService: ng.IQService;

        static $inject = ['$http', '$q'];

        constructor($http: ng.IHttpService, $q: ng.IQService) { 
            this.httpService = $http;
            this.qService = $q;
        }

        getFirstFew(): ng.IPromise<Array<susiApp.Models.IArticleViewModel>> {
            var defer = this.qService.defer<Array<susiApp.Models.IArticleViewModel>>();

            this.httpService.get<Array<susiApp.Models.IArticleViewModel>>(
                '/api/news', {
                    responseType: 'json'
                }).then((response) => {
                defer.resolve(response.data);
                });

            return defer.promise;
        }

        getArticle(id: number): ng.IPromise<susiApp.Models.IArticleViewModel> {
            var defer = this.qService.defer<susiApp.Models.IArticleViewModel>();

            this.httpService.get<susiApp.Models.IArticleViewModel>(
                '/api/article?id=' + id, {
                    responseType: 'json'
                }).then((response) => {
                defer.resolve(response.data);
            });

            return defer.promise;
        }
    }

    export class SUSIService implements susiApp.Interfaces.ISUSIService {
        httpService: ng.IHttpService;
        qService: ng.IQService;

        static $inject = ['$http', '$q'];

        constructor($http: ng.IHttpService, $q: ng.IQService) {
            this.httpService = $http;
            this.qService = $q;
        }

        getStudentInfo(): ng.IPromise<susiApp.Models.IStudentViewModel> {
            var defer = this.qService.defer<susiApp.Models.IStudentViewModel>();

            this.httpService.get<susiApp.Models.IStudentViewModel>(
                '/api/susi', {
                    responseType: 'json'
                }).then((response) => {
                defer.resolve(response.data);
            });

            return defer.promise;
        }

        getCourses(): ng.IPromise<Array<susiApp.Models.ICourseResultViewModel>> {
            var defer = this.qService.defer<Array<susiApp.Models.ICourseResultViewModel>>();

            this.httpService.get<Array<susiApp.Models.ICourseResultViewModel>>(
                '/api/susi?courses', {
                    responseType: 'json'
                }).then((response) => {
                defer.resolve(response.data);
            });

            return defer.promise;
        }
    }

    export class AdminService {

    }

    angular.module('susiApp')
        .service('susiApp.Services.HomeService', HomeService)
        .service('susiApp.Services.NewsService', NewsService)
        .service('susiApp.Services.SUSIService', SUSIService);
} 