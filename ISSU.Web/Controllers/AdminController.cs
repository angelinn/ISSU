using ISSU.Data;
using ISSU.Data.UoW;
using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using ISSU.Data.Encryption;

namespace ISSU.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private UnitOfWork uow;

        public AdminController()
        {
            uow = new UnitOfWork();
        }

        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> UpdateCourses(string username)
        {
            Student target = uow.Users.Where(s => s.Username.Equals(username)).SingleOrDefault();

            if (target == null)
                return Content("user does not exist.");

            await new CourseUpdater(uow, target).UpdateAll();
            return RedirectToAction("Courses", "SUSI");
        }

        // Tested and working. Needs View() or Ajax
        public async Task<ActionResult> UpdateStudentInfo(string username)
        {
            Student target = uow.Users.Where(s => s.Username.Equals(username)).SingleOrDefault();

            if (target == null)
                return Content("user does not exist.");

            
            SUSIConnecter connecter = new SUSIConnecter();
            string key = await connecter.LoginAsync(target.Username, PasswordEncrypter.Decrypt(target.Password));
            Student result = await connecter.GetStudentInfoAsync(key);
            Student.CopyPersonalInfo(result, target);
            uow.SaveChanges();

            return View();
        }

        public ActionResult UpdateUser(string username)
        {
            return View(uow.Users.Where(s => s.Username.Equals(username)).Single());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(Student student)
        {
            Student fromDb = uow.Users.Where(s => s.Username.Equals(student.Username)).Single();

            Student.CopyPersonalInfo(student, fromDb);
            fromDb.AuthKeyUpdated = student.AuthKeyUpdated;

            uow.SaveChanges();

            return View();
        }

        // Tested and works, needs View() or Ajax
        public ActionResult AddRole(string roleName)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ISSUContext()));
            roleManager.Create(new IdentityRole(roleName));

            return View();
        }

        public ActionResult AddCategory(string categoryName)
        {
            uow.Categories.Create(new Category() { Name = categoryName });
            uow.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AllUsers()
        {
            return View(uow.Users.SelectAll().ToList());
        }

        public ActionResult CreateArticle()
        {
            List<Category> categories = uow.Categories.SelectAll().ToList();
            List<SelectListItem> result = new List<SelectListItem>();

            foreach (Category category in categories)
            {
                result.Add(new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Name
                });
            }

            ViewBag.Categories = result;
            return View(new Article());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArticle(Article article, string category)
        {
            Student currentUser = uow.Users.Where(s => s.Username.Equals(User.Identity.Name)).Single();
            article.StudentID = currentUser.ID;
            article.Created = DateTime.Now;

            article.CategoryID = uow.Categories.Where(c => c.Name.Equals(category)).Single().ID;
            uow.Articles.Create(article);
            uow.SaveChanges();

            return RedirectToAction("Article", "News", new { id = article.ID });
        }

        public ActionResult CreateWebsite()
        {
            return View(new Website());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWebsite(Website website)
        {
            uow.Websites.Create(website);
            uow.SaveChanges();

            return RedirectToAction("Websites", "Home");
        }
	}
}