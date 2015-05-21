using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISSU.Web.Areas.API.Models
{
    public class APIArticle
    {

        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public DateTime? Created { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}