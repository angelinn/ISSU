using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ISSU.Data.UoW;
using ISSU.Models;

namespace ISSU.Web.Controllers
{
    public class NewsController : Controller
    {
        public NewsController()
        {
            uow = new UnitOfWork();
        }

        public ActionResult Index()
        {
            ViewBag.PagesCount = GetNumberOfPages(uow.Articles.SelectAll().Count());
            ViewBag.CurrentPage = 100;

            return View();
        }

        public ActionResult Article()
        {
            return View();
        }

        public PartialViewResult IndexPartial() 
        {
            return PartialView("_Index");
        }

        public PartialViewResult ArticlePartial()
        {
            return PartialView("_Article");
        }

        private int GetNumberOfPages(int articles)
        {
            return articles / ARTICLES_PER_PAGE;
        }

        private const int ARTICLES_PER_PAGE = 4;
        private UnitOfWork uow;
	}
}