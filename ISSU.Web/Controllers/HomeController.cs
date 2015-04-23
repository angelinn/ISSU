using ISSU.Data.UoW;
using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISSU.Web.Controllers
{
    [Authorize(Roles="Student, Admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Article> firstFew = new UnitOfWork().Articles
                    .Where(a => a.ID < ARTICLES_PER_PAGE)
                    .ToList();

            firstFew.Sort((a, b) => b.Created.Value.CompareTo(a.Created.Value));
            return View(firstFew);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Websites()
        {
            IEnumerable<Website> sites = new UnitOfWork().Websites.SelectAll().ToList();
            return View(sites);
        }

        private const int ARTICLES_PER_PAGE = 4;
    }
}