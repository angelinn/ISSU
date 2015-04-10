using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ISSU.Data
{
    public class ISSUContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Website> Websites { get; set; }
    }
}
