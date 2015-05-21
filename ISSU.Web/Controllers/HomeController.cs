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
            return View();
        }

        public ActionResult Websites()
        {
            return View();
        }

        public PartialViewResult IndexPartial()
        {
            return PartialView("_Index");
        }

        public PartialViewResult WebsitesPartial()
        {
            return PartialView("_Websites");
        }

        private const int ARTICLES_PER_PAGE = 4;
    }
}