using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using ISSU.Data.UoW;
using ISSU.Models;
using ISSU.Web.Models;
using ISSU.Data;
using Microsoft.Owin.Security;
using System.Web;

namespace ISSU.Web.Areas.API.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(LoginViewModel model)
        {
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ISSUContext()));
            if (ModelState.IsValid)
            {
                ApplicationUser user = userManager.Find(model.UserName, model.Password);

                if (user != null)
                    return Request.CreateResponse(HttpStatusCode.OK, user);

                return Request.CreateResponse(HttpStatusCode.NotModified, model);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
