using ISSU.Models;

namespace ISSU.Web.Areas.API.Models
{
    public class CourseResultViewModel
    {
        public int ID { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        public double Grade { get; set; }
        public bool IsTaken { get; set; }
        public bool IsElective { get; set; }
        public double Credits { get; set; }

        public CourseResultViewModel(CourseResult core)
        {
            ID = core.ID;
            CourseID = core.CourseID;
            Course = core.Course;
            Grade = core.Grade;
            IsTaken = core.IsTaken;
            IsElective = core.IsElective;
            Credits = core.Credits;
        }
    }
}