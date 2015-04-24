using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISSU.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
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
