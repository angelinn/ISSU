module susiApp.Models {

    export interface IWebsite {
        ID: number;
        Title: string;
        Url: string;
    }

    export interface IArticle {
        ID: number;
        Title: string;
        ImageUrl: string;
        Content: string;
        ShortDescription: string;
        Created: Date;
        CategoryID: number;
    }
} 