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

    export interface ICourse {
        ID: number;
        Name: string;
        Teacher: string;
    }

    export interface ICourseResultViewModel {
        ID: number;
        Course: ICourse;
        Grade: number;
        IsTaken: boolean;
        IsElective: boolean;
        Creadits: number;

    }

    export interface IStudentViewModel {
        ID: number;
        FacultyNumber: number;
        Group: number;
        FirstName: string;
        MiddleName: string;
        LastName: string
        Programme: string;
        Year: number;
    }
} 