using ISSU.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

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
        }
    }
}
