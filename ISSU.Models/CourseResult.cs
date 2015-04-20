namespace ISSU.Models
{
    public class CourseResult
    {
        public int ID { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public double Grade { get; set; }
        public bool IsTaken { get; set; }
        public bool IsElective { get; set; }
        public double Credits { get; set; }
    }
}
