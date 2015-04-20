using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using ISSU.Data;
using ISSU.Models;
using Newtonsoft.Json;

namespace ISSU.Web.Controllers
{
    [Authorize(Roles="Student")]
    public class SUSIController : Controller
    {
        public SUSIController()
        {
            uow = new UnitOfWork();
        }

        //
        // GET: /SUSI/
        public ActionResult Index()
        {
            GetCurrentUser();
            return View();
        }

        public ActionResult About()
        {
            GetCurrentUser();
            return View(currentUser);
        }

        public async Task<ActionResult> Courses()
        {
            GetCurrentUser();
            await GetCourses();

            return Content((string)await new SUSIConnecter().GetCoursesAsync(currentUser.LastAuthKey));
        }

        private async Task<object> GetCourses()
        {
            GetCurrentUser();
            string json = (string)await new SUSIConnecter().GetCoursesAsync(currentUser.LastAuthKey);
            List<CourseResult> results = JsonConvert.DeserializeObject<List<CourseResult>>(json);
            List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(json);

            AddCoursesToDB(courses);
            AddCourseResults(courses, results, currentUser.ID);

            return new { courses = courses, res = results };
        }

        private void AddCourseResults(List<Course> courses, List<CourseResult> results, int studentID)
        {
            for (int i = 0; i < courses.Count; ++i)
            {
                Course fromDB = uow.Courses.Where(c => c.Name == courses[i].Name).Single();
                results[i].CourseID = fromDB.ID;
                results[i].StudentID = studentID;
            }
            uow.SaveChanges();
        }

        private void AddCoursesToDB(List<Course> courses)
        {
            foreach (Course course in courses)
            {
                if (uow.Courses.Where(c => c.Name == course.Name).SingleOrDefault() == null)
                    uow.Courses.Create(course);
            }
            uow.SaveChanges();
        }

        private void GetCurrentUser()
        {
            currentUser = uow.Users.Where(s => s.Username == User.Identity.Name).Single();
        }

        private Student currentUser;
        private UnitOfWork uow;
	}
}