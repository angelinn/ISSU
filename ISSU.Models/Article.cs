using System;
using System.ComponentModel.DataAnnotations;

namespace ISSU.Models
{
    public class Article
    {
        //public Article(Article other)
        //{
        //    ID = other.ID;
        //    Title = other.Title;
        //    ImageUrl = other.ImageUrl;
        //    Content = other.Content;
        //    ShortDescription = other.ShortDescription;
        //    Created = other.Created;
        //    StudentID = other.StudentID;
        //    CategoryID = other.CategoryID;

        //    //Student = new Student(other.Student);
        //    //Category = new Category(other.Category);
        //}

        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }

        [Required(ErrorMessage="Полето е задължително")]
        [StringLength(100)]
        public string ShortDescription { get; set; }
        public DateTime? Created { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
