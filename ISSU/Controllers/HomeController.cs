using ISSU.Models;
using ISSU.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace ISSU.Controllers
{
    public class HomeController : Controller
    {
        private UoW db = new UoW();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddWebsite()
        {
            return View(new Website());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWebsite(Website website)
        {
            db.Websites.Create(website);
            db.SaveChanges();

            return RedirectToAction("Websites");
        }


        public ActionResult Websites()
        {
            return View(db.Websites.SelectAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Susi()
        {
            return View();
        }

        public ActionResult LogInSusi(string username, string password)
        {
            return Content("123");
        }

        private static WebResponse CreateRequest(string method, string address, object data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = method;
            request.ContentType = "application/json";
            //if (method == "POST")
            {
                using (var requestStream = request.GetRequestStream())
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(JsonConvert.SerializeObject(data));
                    //Debug.WriteLine(JsonConvert.SerializeObject(data));
                }
            }
            return request.GetResponse();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}