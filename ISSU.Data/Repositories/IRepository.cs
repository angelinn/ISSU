using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> SelectAll();

        IQueryable<T> Where(Expression<Func<T, bool>> filter);
        T Select(int id);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Create(T entity);

        void Detach(T entity);
    }
}
