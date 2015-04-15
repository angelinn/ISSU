using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public interface IUoW : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Website> Websites { get; }
        int SaveChanges();
    }
}
