using ISSU.Data.UoW;
using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.ComponentModel;
using ISSU.Web.Areas.API.Models;

namespace ISSU.Web.Areas.API.Controllers
{
    public class HomeController : ApiController
    {
        public enum Status
        {
            NotRequested = 0,
            Requested = 1
        }

        public HttpResponseMessage Get(Status websites = Status.NotRequested, Status index = Status.NotRequested)
        {
            if (websites == Status.Requested)
                return Request.CreateResponse(HttpStatusCode.OK, new UnitOfWork().Websites.SelectAll().ToList());
            if (index == Status.Requested)
            {
                var firstFew = new UnitOfWork().Articles
                    .Where(a => a.ID < ARTICLES_PER_PAGE).ToList();

                List<ArticleViewModel> result = new List<ArticleViewModel>();
                firstFew.ForEach(ar => result.Add(new ArticleViewModel(ar)));
                result.Sort((a, b) => b.Created.Value.CompareTo(a.Created.Value));
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        } 

        private const int ARTICLES_PER_PAGE = 4;
    }
}
