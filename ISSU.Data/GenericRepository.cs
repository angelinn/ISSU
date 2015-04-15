using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public sealed class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext context;
        private IDbSet<TEntity> dbSet;
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

        public IDbSet<TEntity> DbSet 
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
            DbSet = Context.Set<TEntity>();
        }

        public GenericRepository() : this(new ISSUContext())
        {  }

        public IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> filter = null,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter);

            string[] split = includeProperties.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string includeProperty in split)
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();

        }

        public IQueryable<TEntity> SelectAll()
        {
            return dbSet.AsQueryable();
        }

        public TEntity Select(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            DbEntityEntry entry = context.Entry(item);
            if (entry.State == EntityState.Detached)
                dbSet.Add(item);
            else
                entry.State = EntityState.Added;
        }

        public void Update(TEntity item)
        {
            DbEntityEntry entry = context.Entry(item);
            if (entry.State == EntityState.Detached)
                dbSet.Attach(item);

            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity item)
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
            TEntity item = Select(id);
            if (item == null)
                throw new ArgumentNullException("ID not found.");

            Delete(item);
        }
    }
}
