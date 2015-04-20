using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ISSUContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public UnitOfWork() : this(new ISSUContext())
        {  }

        public IGenericRepository<Student> Users
        {
            get
            {
                return GetRepository<Student>();
            }
        }

        public IGenericRepository<Website> Websites
        {
            get
            {
                return GetRepository<Website>();
            }
        }

        public IGenericRepository<Course> Courses
        {
            get
            {
                return GetRepository<Course>();
            }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                Type type = typeof(GenericRepository<T>);
                repositories.Add(typeof(T), Activator.CreateInstance(type, context));
            }
            return (IGenericRepository<T>)repositories[typeof(T)];
        }

        private ISSUContext context;
        private Dictionary<Type, object> repositories;
    }
}
