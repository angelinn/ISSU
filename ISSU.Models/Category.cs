using System.Collections.Generic;

namespace ISSU.Models
{
    public class Category
    {
        public string Name;

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
