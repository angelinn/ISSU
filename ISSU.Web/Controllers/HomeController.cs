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
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Websites()
        {
            IEnumerable<Website> sites = new UnitOfWork().Websites.SelectAll().ToList();
            return View(sites);
        }
    }
}