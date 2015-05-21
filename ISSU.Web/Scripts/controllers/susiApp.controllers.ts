module susiApp.Controllers {
    'use strict';

    export class HomeController {
        scope: ng.IScope;
        homeService: susiApp.Interfaces.IHomeService;

        static $inject = ["$scope", 'susiApp.Services.HomeService'];
        constructor($scope: ng.IScope, homeService: susiApp.Interfaces.IHomeService) {
            this.scope = $scope;
            this.homeService = homeService;

            this.addArticlesToScope();
            this.addWebsitesToScope();
        }

        addArticlesToScope(): void {
            this.homeService.getArticles()
                .then((data) => {
                this.scope['articles'] = data;
                console.log(data);
            });
        }

        addWebsitesToScope(): void {
            this.homeService.getWebsites()
                .then((data) => {
                this.scope['websites'] = data;
            });
        }
    }

    export class NewsController {
        scope: ng.IScope;
        newsService: susiApp.Interfaces.INewsService;

        static $inject = ['$scope', 'susiApp.Services.NewsService'];

        constructor($scope: ng.IScope, newsService: susiApp.Interfaces.INewsService) {
            this.scope = $scope;
            this.newsService = newsService;

            this.getFirstFew();
        }

        getFirstFew(): void {
            this.newsService.getFirstFew()
                .then((data) => {
                this.scope['articles'] = data;
            });
        }

        getArticle(id: number): void {
            this.newsService.getArticle(id)
                .then((data) => {
                this.scope['currentArticle'] = data;
            });
        }
    }


    angular.module('susiApp')
        .controller('susiApp.Controllers.HomeController', HomeController)
        .controller('susiApp.Controllers.NewsController', NewsController);
}
