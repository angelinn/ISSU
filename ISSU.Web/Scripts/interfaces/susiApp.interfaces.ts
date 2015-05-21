module susiApp.Interfaces {
    'use strict';

    export interface IHomeService {
        getArticles(): ng.IPromise<Array<susiApp.Models.IArticle>>;
        getWebsites(): ng.IPromise<Array<susiApp.Models.IWebsite>>;
    }

    export interface INewsService {
        getFirstFew(): ng.IPromise<Array<susiApp.Models.IArticle>>;
        getArticle(id: number): ng.IPromise<susiApp.Models.IArticle>;
    }
} 