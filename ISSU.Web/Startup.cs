using Microsoft.Owin;
using Owin;
using System.Data.Entity;

using ISSU.Data;
using ISSU.Data.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ISSU.Models;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(ISSU.Web.Startup))]
namespace ISSU.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ISSUContext, Configuration>());
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            

            //ISSUContext con = new ISSUContext();
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(con));
            //roleManager.Create(new IdentityRole("Student"));
            //roleManager.Create(new IdentityRole("Admin"));

            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(con));
            //var user = userManager.FindByName("abnedelche");
            //userManager.AddToRole(user.Id, "Student");
        }
    }
}
