using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using ISSU.Data;
using ISSU.Data.UoW;
using ISSU.Models;
using Newtonsoft.Json;

namespace ISSU.Web.Controllers
{
    public class SUSIController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            GetCurrentUser();
        }

        public SUSIController()
        {
            uow = new UnitOfWork();
        }

        public PartialViewResult SUSIPartial()
        {
            return PartialView("_SUSI");
        }

        public ActionResult AboutPartial()
        {
            return View(currentUser);
        }

        public async Task<ActionResult> CoursesPartial()
        {
            if(currentUser.CoursesUpdated == null)
            {
                CourseUpdater updater = new CourseUpdater(uow, currentUser);

                await updater.UpdateCoursesAsync();
                return View(await updater.UpdateCourseResultsAsync());
            }
            return View(currentUser.CourseResults.ToList());
        }

        private void GetCurrentUser()
        {
            currentUser = uow.Users.Where(s => s.Username.Equals(User.Identity.Name)).SingleOrDefault();
        }

        private Student currentUser;
        private UnitOfWork uow;
	}
}