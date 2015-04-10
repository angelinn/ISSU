using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSU.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> SelectAll();
        T Select(int id);
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        void Create(T item);
    }
}
