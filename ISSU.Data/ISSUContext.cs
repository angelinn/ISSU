using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using ISSU.Models;

namespace ISSU.Data
{
    public class ISSUContext : IdentityDbContext<ApplicationUser>
    {
        public ISSUContext() : base("ISSUDatabase")
        {  }

        public IDbSet<Website> Websites { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<CourseResult> CourseResults { get; set; }
    }
}
