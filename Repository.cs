using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Utility
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private DbSet<T> set;
        public Repository(DbContext context)
        {
            this.context = context;
            set = context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            set.Add(entity);
            context.SaveChanges();
        }

        public virtual void Delete(object entityKey)
        {
            T entity = ReadOne(entityKey);
            set.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Delete(T t)
        {
            set.Remove(t);
            context.SaveChanges();
        }

        public virtual bool Exists(object entityKey)
        {
            return set.Find(entityKey) != null;
        }

        public virtual bool Exists(T t)
        {
            return set.Contains(t);
        }

        public virtual IQueryable<T> ReadMany(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return set;
            }
            else
            {
                return set.Where(expression);
            }
        }

        public virtual T ReadOne(object entityKey)
        {
            return set.Find(entityKey);
        }

        public virtual void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
