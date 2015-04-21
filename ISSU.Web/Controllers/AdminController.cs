using ISSU.Data;
using ISSU.Data.UoW;
using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using ISSU.Data.Encryption;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ISSU.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private UnitOfWork uow;
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        // NOT TESTED
        public async Task<ActionResult> UpdateCourses(string username)
        {
            uow = new UnitOfWork();
            Student target = uow.Users.Where(s => s.Username.Equals(username)).SingleOrDefault();

            if (target == null)
                return Content("user does not exist.");

            await new CourseUpdater(uow, target).UpdateAll();
            return View();
        }

        // NOT TESTED
        public async Task<ActionResult> UpdateStudentInfo(string username)
        {
            uow = new UnitOfWork();
            Student target = uow.Users.Where(s => s.Username.Equals(username)).SingleOrDefault();

            if (target == null)
                return Content("user does not exist.");

            SUSIConnecter connecter = new SUSIConnecter();
            string key = await connecter.LoginAsync(target.Username, PasswordEncrypter.Decrypt(target.Password));
            target = await connecter.GetStudentInfoAsync(key);
            uow.Users.Update(target);

            return View();
        }

        // NOT TESTED
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(Student student)
        {
            uow = new UnitOfWork();
            uow.Users.Update(student);

            return View();
        }

        // Tested and works, needs View()
        public ActionResult AddRole(string roleName)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ISSUContext()));
            roleManager.Create(new IdentityRole(roleName));

            return View();
        }
	}
}