using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

using ISSU.Models;

namespace ISSU.Data.Migrations
{
    public class AddRolesIfModelChanges : DropCreateDatabaseIfModelChanges<ISSUContext>
    {
        protected override void Seed(ISSUContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("Student"));
            roleManager.Create(new IdentityRole("Admin"));
        }
    }
}
