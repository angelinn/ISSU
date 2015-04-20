using System.ComponentModel.DataAnnotations;

namespace ISSU.Models
{
    public class Course
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Teacher { get; set; }
    }
}
