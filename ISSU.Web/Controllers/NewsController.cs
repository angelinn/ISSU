using ISSU.Data.UoW;
using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            List<Article> firstFew = uow.Articles.Where(a => a.ID < ARTICLES_PER_PAGE).ToList();
            return View(firstFew);
        }

        public ActionResult Article(string id)
        {
            Article target = uow.Articles.Select(Convert.ToInt32(id));
            return View(target);
        }

        private const int ARTICLES_PER_PAGE = 4;
        private UnitOfWork uow;
	}
}