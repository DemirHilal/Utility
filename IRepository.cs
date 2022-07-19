using System;
using System.Linq;
using System.Linq.Expressions;

namespace Utility
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        T ReadOne(object entityKey);
        IQueryable<T> ReadMany(Expression<Func<T,bool>> expression = null);
        void Update(T entity);
        void Delete(object entityKey);
        void Delete(T t);
        bool Exists(object entityKey);
        bool Exists(T t);
    }
}
