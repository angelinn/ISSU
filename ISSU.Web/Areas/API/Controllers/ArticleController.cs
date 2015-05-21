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
    public class ArticleController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            Article target = new UnitOfWork().Articles.Select(Convert.ToInt32(id));
            return Request.CreateResponse(HttpStatusCode.OK, target);
        }
    }
}
