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
        //
        // GET: /News/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Article(string id)
        {
            Article yeah = new Article
            {
                Title = "Results have appeared finally.",
                StudentID = 1,
                Text = "Ориентирана към услуги архитектура:\nЛекции: 29 март, 4-5 април\nУпражнения: 9-10 май\nОрганизационна сбирка на МП Информационни системи на 26.03." +
                "(четвъртък) от 17.00 ч. в зала 222, за уточняване разписа на дисциплините Грид и облачни изчисления и Ориентирана към услуги архитектура" +
                "Нанасяне на оценки на 26.03. (четвъртък) от 16.00 до 17:00 ч. в 110." +
                "Изборните дисциплини, за 2014-2015 за магистри Информационни системи са тук. Записвайте се в СУСИ, въпреки, че не извежда кредити. Кредитите ви са по съответната бакалавърска или магистърска програма, която предлага курса.",
                ImageUrl = "/Content/images/art1.jpg",
                Category = new Category() { Name = "Бази данни" },
                Created = DateTime.Now
            };
            return View(yeah);
        }
	}
}