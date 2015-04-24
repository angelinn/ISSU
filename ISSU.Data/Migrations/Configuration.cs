using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

using ISSU.Models;
using ISSU.Data.UoW;

namespace ISSU.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ISSUContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ISSU.Data.ISSUContext";

            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ISSUContext context)
        {
             AddRoles(context);
        }

        private void AddRoles(ISSUContext context)
        {
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("Student"));
            roleManager.Create(new IdentityRole("Admin"));
        }

        private void AddWebsites(ISSUContext context)
        {
            context.Websites.Add(new Website() { Title = "Владимир Димитров", Url = @"http://ci.fmi.uni-sofia.bg/VladimirDimitrov" });
        }
    }
}
