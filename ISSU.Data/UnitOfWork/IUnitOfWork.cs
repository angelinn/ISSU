using System;

using ISSU.Models;

namespace ISSU.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Student> Users { get; }
        IGenericRepository<Website> Websites { get; }
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<CourseResult> CourseResults { get; }

        int SaveChanges();
    }
}
