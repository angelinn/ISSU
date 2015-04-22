using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

using ISSU.Models;
using ISSU.Data.UoW;
using Newtonsoft.Json;

namespace ISSU.Data
{
    public class CourseUpdater
    {
        public CourseUpdater(UnitOfWork uow, Student currentUser)
        {
            this.uow = uow;
            this.currentUser = currentUser;
        }

        public async Task UpdateAll()
        {
            if (json == null)
                await ParseCoursesAsync();

            await UpdateCoursesAsync();
            await UpdateCourseResultsAsync();
        }

        public async Task UpdateCoursesAsync()
        {
            if (json == null)
                await ParseCoursesAsync();

            foreach (Course course in courses)
            {
                if (uow.Courses.Where(c => c.Name.Equals(course.Name)).SingleOrDefault() == null)
                    uow.Courses.Create(course);
            }
            uow.SaveChanges();
        }

        public async Task<List<CourseResult>> UpdateCourseResultsAsync()
        {
            if (json == null)
                await ParseCoursesAsync();

            List<CourseResult> results = JsonConvert.DeserializeObject<List<CourseResult>>(json);

            Course current = null;
            for (int i = 0; i < courses.Count; ++i)
            {
                current = courses[i];
                Course fromDB = uow.Courses.Where(c => c.Name.Equals(current.Name)).Single();
                results[i].CourseID = fromDB.ID;
                results[i].StudentID = currentUser.ID;
                uow.CourseResults.Create(results[i]);
            }
            currentUser.AuthKeyUpdated = DateTime.Now;
            uow.SaveChanges();

            return results;
        }

        private async Task ParseCoursesAsync()
        {
            json = await new SUSIConnecter().GetCoursesAsync(currentUser.LastAuthKey, currentUser);
            courses = JsonConvert.DeserializeObject<List<Course>>(json);
        }

        private UnitOfWork uow;
        private Student currentUser;
        private string json;
        private List<Course> courses;
    }
}
