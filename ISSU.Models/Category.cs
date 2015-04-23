using System.Collections.Generic;

namespace ISSU.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private ICollection<Article> articles;
        public virtual ICollection<Article> Articles
        {
            get
            {
                return articles;
            }
            set
            {
                articles = value;
            }
        }
        
    }
}
