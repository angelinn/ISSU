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
        public virtual Student Student { get; set; }
    }
}
