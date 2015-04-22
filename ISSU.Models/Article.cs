using System;

namespace ISSU.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Text { get; set; }
        public DateTime? Created { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
