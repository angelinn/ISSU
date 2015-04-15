using ISSU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public class UoW : IUoW
    {
        private readonly ISSUContext context;
        private readonly Dictionary<Type, object> repositories;

        public UoW(ISSUContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public UoW() : this(new ISSUContext())
        {  }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if(!repositories.ContainsKey(typeof(T)))
            {
                Type type = typeof(GenericRepository<T>);
                repositories.Add(typeof(T), Activator.CreateInstance(type, context));
            }
            return (IRepository<T>)repositories[typeof(T)];
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Website> Websites
        {
            get
            {
                return GetRepository<Website>();
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
    }
}
