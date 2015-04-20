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
            string json = (string)await new SUSIConnecter().GetCoursesAsync(currentUser.LastAuthKey);
            List<Course> courses = UpdateCourses(json);

            return View(UpdateCourseResults(courses, currentUser, json));
        }

        private List<Course> UpdateCourses(string json)
        {
            GetCurrentUser();
            List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(json);
            AddCoursesToDB(courses);
            return courses;
        }

        private List<CourseResult> UpdateCourseResults(List<Course> courses, Student student, string json)
        {
            if (currentUser.Updated == null)
            {
                List<CourseResult> results = JsonConvert.DeserializeObject<List<CourseResult>>(json);
                Course current = null;
                for (int i = 0; i < courses.Count; ++i)
                {
                    current = courses[i];
                    Course fromDB = uow.Courses.Where(c => c.Name.Equals(current.Name)).Single();
                    results[i].CourseID = fromDB.ID;
                    results[i].StudentID = student.ID;

                    uow.CourseResults.Create(results[i]);
                }
                currentUser.Updated = DateTime.Now;
                uow.SaveChanges();

                return results;
            }
            return currentUser.CourseResults.ToList();
        }

        private void AddCoursesToDB(List<Course> courses)
        {
            foreach (Course course in courses)
            {
                if (uow.Courses.Where(c => c.Name.Equals(course.Name)).SingleOrDefault() == null)
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