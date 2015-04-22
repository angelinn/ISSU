using System;

using ISSU.Models;

namespace ISSU.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Student> Users { get; }
        IGenericRepository<Website> Websites { get; }
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<CourseResult> CourseResults { get; }
        IGenericRepository<Article> Articles { get; }
        IGenericRepository<Category> Categories { get; }

        int SaveChanges();
    }
}
