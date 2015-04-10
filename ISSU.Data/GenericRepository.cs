using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> dbSet;
        public DbContext Context
        {
            get
            {
                return context;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Context can't be null!");

                context = value;
            }
        }

        public IDbSet<T> DbSet 
        {
            get
            {
                return dbSet;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Context can't be null!");

                dbSet = value;
            }
        }
        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public GenericRepository() : this(new ISSUContext())
        {  }

        public IQueryable<T> SelectAll()
        {
            return dbSet.AsQueryable();
        }

        public T Select(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(T item)
        {
            DbEntityEntry entry = context.Entry(item);
            if (entry.State == EntityState.Detached)
                dbSet.Add(item);
            else
                entry.State = EntityState.Added;
        }

        public void Update(T item)
        {
            DbEntityEntry entry = context.Entry(item);
            if (entry.State == EntityState.Detached)
                dbSet.Attach(item);

            entry.State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            DbEntityEntry entry = context.Entry(item);
            if (entry.State != EntityState.Deleted)
                entry.State = EntityState.Deleted;
            else
            {
                dbSet.Attach(item);
                dbSet.Remove(item);
            }

        }

        public void Delete(int id)
        {
            T item = Select(id);
            if (item == null)
                throw new ArgumentNullException("ID not found.");

            Delete(item);
        }
    }
}
