using Microsoft.Owin;
using Owin;
using System.Data.Entity;

using ISSU.Data;
using ISSU.Data.Migrations;

[assembly: OwinStartupAttribute(typeof(ISSU.Web.Startup))]
namespace ISSU.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ISSUContext, Configuration>());
        }
    }
}
