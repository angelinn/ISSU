using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace ISSU.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
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

        public IEnumerable<T> Select(Expression<Func<T, bool>> filter = null,
                                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                           string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
                query = query.Where(filter);

            string[] split = includeProperties.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string includeProperty in split)
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query).ToList(); ;

            return query.ToList();

        }

        public IQueryable<T> Where(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter);
        }

        public IQueryable<T> SelectAll()
        {
            return dbSet.AsQueryable();
        }

        public T Select(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(T entity)
        {
            DbEntityEntry entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
                dbSet.Add(entity);
            else
                entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            DbEntityEntry entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
                dbSet.Attach(entity);

            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry entry = context.Entry(entity);
            if (entry.State != EntityState.Deleted)
                entry.State = EntityState.Deleted;
            else
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }

        }

        public void Delete(int id)
        {
            T entity = Select(id);
            if (entity == null)
                throw new ArgumentNullException("ID not found.");

            Delete(entity);
        }

        public void Detach(T entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }

        private DbContext context;
        private IDbSet<T> dbSet;
    }
}
