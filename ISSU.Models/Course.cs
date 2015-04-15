using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public double Grade { get; set; }
        public bool Taken { get; set; }
        public int Credits { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
