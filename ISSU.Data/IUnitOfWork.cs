using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Student> Users { get; }
        IGenericRepository<Website> Websites { get; }
        IGenericRepository<Course> Courses { get; }

        int SaveChanges();
    }
}
