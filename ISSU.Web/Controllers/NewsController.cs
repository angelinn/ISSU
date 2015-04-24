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

        //
        // GET: /News/
        public ActionResult Index(string id)
        {
            int pageNumber = 1;

            if (!String.IsNullOrEmpty(id))
                pageNumber = Convert.ToInt32(id);

            List<Article> firstFew = uow.Articles
                        .Where(a => a.ID >= ((pageNumber - 1) * ARTICLES_PER_PAGE) 
                            && a.ID < (pageNumber * ARTICLES_PER_PAGE))
                        .ToList();

            ViewBag.PagesCount = GetNumberOfPages(uow.Articles.SelectAll().Count());
            ViewBag.CurrentPage = pageNumber;

            return View(firstFew);
        }

        public ActionResult Article(string id)
        {
            Article target = uow.Articles.Select(Convert.ToInt32(id));
            return View(target);
        }

        private int GetNumberOfPages(int articles)
        {
            return articles / ARTICLES_PER_PAGE;
        }

        private const int ARTICLES_PER_PAGE = 4;
        private UnitOfWork uow;
	}
}