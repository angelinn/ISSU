using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ISSU.Data.UoW;
using ISSU.Models;

namespace ISSU.Web.Areas.API.Controllers
{
    public class NewsController : ApiController
    {
        public HttpResponseMessage Get(string id = "")
        {
            int pageNumber = 1;

            if (!String.IsNullOrEmpty(id))
                pageNumber = Convert.ToInt32(id);

            List<Article> firstFew = new UnitOfWork().Articles
                        .Where(a => a.ID >= ((pageNumber - 1) * ARTICLES_PER_PAGE)
                            && a.ID < (pageNumber * ARTICLES_PER_PAGE))
                        .ToList();

            return Request.CreateResponse(HttpStatusCode.OK, firstFew);
        }

        private int GetNumberOfPages(int articles)
        {
            return articles / ARTICLES_PER_PAGE;
        }

        private const int ARTICLES_PER_PAGE = 4;
    }
}
