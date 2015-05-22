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
using ISSU.Web.Areas.API.Models;

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
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.Unauthorized);

            uow.Users.Detach(user);
            user.Password = null;
            user.Username = null;
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        public async Task<HttpResponseMessage> Get(string courses)
        {
            List<CourseResultViewModel> result = new List<CourseResultViewModel>();
            if (currentUser.CoursesUpdated == null)
            {
                CourseUpdater updater = new CourseUpdater(uow, currentUser);
                
                (await updater.UpdateCourseResultsAsync()).ForEach(cr => result.Add(new CourseResultViewModel(cr)));

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            currentUser.CourseResults.ToList().ForEach(cr => result.Add(new CourseResultViewModel(cr)));
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        private void GetCurrentUser()
        {
            currentUser = uow.Users.Where(s => s.Username.Equals(User.Identity.Name)).SingleOrDefault();
        }

        private Student currentUser;
        private UnitOfWork uow;
    }
}
