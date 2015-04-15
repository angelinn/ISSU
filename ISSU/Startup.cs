using ISSU.Data;
using ISSU.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISSU.Startup))]
namespace ISSU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AddRolesToDatabase();
        }

        private void AddRolesToDatabase()
        {
            RoleManager<IdentityRole> manager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            manager.Create(new IdentityRole("User"));
            manager.Create(new IdentityRole("Admin"));
        }
    }
}
