using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISSU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Websites()
        {
            Website vlado = new Website() { Title = "Владимир Димитров", Url = @"http://ci.fmi.uni-sofia.bg/VladimirDimitrov" };
            List<Website> list = new List<Website>();
            list.Add(vlado);
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}