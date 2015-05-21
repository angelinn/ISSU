using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ISSU.Data.UoW;
using ISSU.Models;
using ISSU.Data;
using System.Threading.Tasks;

namespace ISSU.Web.Areas.API.Controllers
{
    public class SUSIController : ApiController
    {
        public SUSIController()
        {
            uow = new UnitOfWork();
            GetCurrentUser();
        }

        public HttpResponseMessage Get()
        {
            Student user = uow.Users.Where(s => s.Username.Equals(User.Identity.Name)).SingleOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, new { FirstName = user.FirstName, LastName = user.LastName, MiddleName = user.MiddleName, Group = user.Group, FacultyNumber = user.FacultyNumber });
        }

        public async Task<HttpResponseMessage> Get(string courses)
        {
            if (currentUser.CoursesUpdated == null)
            {
                CourseUpdater updater = new CourseUpdater(uow, currentUser);

                await updater.UpdateCoursesAsync();
                return Request.CreateResponse(HttpStatusCode.OK, await updater.UpdateCourseResultsAsync());
            }
            return Request.CreateResponse(HttpStatusCode.OK, currentUser.CourseResults.ToList());
        }

        private void GetCurrentUser()
        {
            currentUser = uow.Users.Where(s => s.Username.Equals(User.Identity.Name)).SingleOrDefault();
        }

        private Student currentUser;
        private UnitOfWork uow;
    }
}
