using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSU.Web.Areas.API.Models
{
    public class ArticleViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public DateTime? Created { get; set; }
        public string StudentName { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public ArticleViewModel(Article core)
        {
            ID = core.ID;
            Title = core.Title;
            ImageUrl = core.ImageUrl;
            Content = core.Content;
            ShortDescription = core.ShortDescription;
            Created = core.Created;
            StudentName = String.Format("{0} {1}", core.Student.FirstName, core.Student.LastName);
            CategoryID = core.CategoryID;
            CategoryName = core.Category.Name;
        }
    }
}